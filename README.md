# ModResults

[![Nuget downloads](https://img.shields.io/nuget/v/ModResults.svg)](https://www.nuget.org/packages/ModResults/)
[![Nuget](https://img.shields.io/nuget/dt/ModResults)](https://www.nuget.org/packages/ModResults/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/modabas/ModResults/blob/master/LICENSE.txt)

Result Pattern that provides a structured way to represent success or failure with optional details, enhancing readability and maintainability in codebases and designed to be used either in-process or over the network.

It is robust, leveraging nullability annotations, immutability (init properties), and factory methods for clarity.

Contains [Result and Result&lt;TValue&gt;](./src/ModResults/Result.cs) implementations with a default [Failure](./src/ModResults/Failure.cs) implementation which are ready to be used out of the box.

Also contains a [Result&lt;TValue, TFailure&gt;](./src/ModResults/[Core]/Result.cs) implementation, but this requires further development for a custom failure class at least.

# ModResults.FluentValidations

Default implementations to convert failed FluentValidations.Results.ValidationResult instances to invalid Result and Result&lt;TValue&gt; objects.

# ModResults.MinimalApis

Default implementations to convert Result and Result&lt;TValue&gt; instances in either Ok or any [FailureType](./src/ModResults/FailureType.cs) state to Microsoft.AspNetCore.Http.IResult.

# ModResults.Orleans

Surrogate and converter implementations for Result and Result&lt;TValue&gt; objects to be used in Microsoft.Orleans projects.

## Usage

### Creating a Result or Result&lt;TValue&gt; instance

Creating an Ok Result instance is done by calling Result.Ok() or Result&lt;TValue&gt;.Ok(TValue value) static methods. Result&lt;TValue&gt; also has an implicit operator to convert an instance of type TValue to a Result&lt;TValue&gt; in Ok state.

Creating a Failed Result instance is done by calling [corresponding static method](./src/ModResults/FailedResult.cs) for each FailureType (i.e. Result.NotFound() or Result&lt;TValue&gt;.NotFound() for creating a Result object in Failed state with FailureType NotFound).

``` csharp
public async Task<Result<GetBookByIdResponse>> GetBookById(GetBookByIdRequest req, CancellationToken ct)
{
    var entity = await db.Books.FirstOrDefaultAsync(b => b.Id == req.Id, ct);

    return entity is null ?
      Result<GetBookByIdResponse>.NotFound() :
      Result.Ok(new GetBookByIdResponse(
        Id: entity.Id,
        Title: entity.Title,
        Author: entity.Author,
        Price: entity.Price));
}
```

### Checking state of a Result or Result&lt;TValue&gt; instance

State of a result instance is either Ok or Failed. State can be checked from result.IsOk and result.IsFailed boolean properties.

If state is ok, Result&lt;TValue&gt; instance contains a not null Value property of type TValue.

If state is failed, Result and Result&lt;TValue&gt; instances contain a not null Failure property of type Failure.

``` csharp
public async Task<Result> PerformGetBookById(GetBookByIdRequest req, CancellationToken ct)
{
    var result = await GetBookById(req, ct);
    if (result.IsOk)
    {
        Console.WriteLine($"GetBookById is successful. Book title is {result.Value.Title}");
    }
    else
    {
        Console.WriteLine($"GetBookById has failed.");
    }
    return result
}
```

### Adding information to Result instances

All types of Result implementations contain a Statement property which encapsulates collections of [Fact](./src/ModResults/[Core]/Fact.cs) and [Warning](./src/ModResults/[Core]/Warning.cs) classes.

See various [WithFact](./src/ModResults/ResultFactExtensions.cs) and [WithWarning](./src/ModResults/ResultWarningExtensions.cs) extension methods to add fact and warning information to result instances.

Default Failure implementation used in Result and Result&lt;TValue&gt; objects a collection of [Error](./src/ModResults/Error.cs) class.

See various static methods of Result objects to create a [Failed Result](./src/ModResults/FailedResult.cs) containing Error information. Errors can only be attached to a Failed Result instance during Result instance creation and cannot be mutated afterwards.

``` csharp
public async Task<Result<GetBookByIdResponse>> GetBookById(GetBookByIdRequest req, CancellationToken ct)
{
    var entity = await db.Books.FirstOrDefaultAsync(b => b.Id == req.Id, ct);

    return entity is null ?
      Result<GetBookByIdResponse>.NotFound($"Book with id: {0} not found.", req.Id)
        .WithFact($"dbContextId: {db.ContextId}") :
      Result.Ok(new GetBookByIdResponse(
        Id: entity.Id,
        Title: entity.Title,
        Author: entity.Author,
        Price: entity.Price))
      .WithFact($"dbContextId: {db.ContextId}");
}
```

### Creating a Failed Result or Result&lt;TValue&gt; instance from an exception

Creating a Failed Result instance from an exception is done by calling [corresponding static method](./src/ModResults/FailedResult.cs) with an exception input parameter for each FailureType, or can be left to implicit operator which creates a Failed Result with FailureType CriticalError by default.

Exception object is converted to an [Error](./src/ModResults/Error.cs) object and added to Error collection of [Failure](./src/ModResults/Failure.cs).

``` csharp
public async Task<Result<GetBookByIdResponse>> GetBookById(GetBookByIdRequest req, CancellationToken ct)
{
    try
    {
        var entity = await db.Books.FirstOrDefaultAsync(b => b.Id == req.Id, ct);

        return entity is null ?
          Result<GetBookByIdResponse>.NotFound() :
          Result.Ok(new GetBookByIdResponse(
            Id: entity.Id,
            Title: entity.Title,
            Author: entity.Author,
            Price: entity.Price));
    }
    catch (Exception ex)
    {
        return ex;
    }
}
```

### Converting Result&lt;TValue&gt; to Result

Converting a Result&lt;TValue&gt; object to Result is straightforward, and can be achieved by calling parameterless ToResult() method of Result&lt;TValue&gt; instance or can be left to implicit operator.

Any Failure information, Errors, Facts and Warnings are automatically copied to output Result.

### Converting a Result instance to Result&lt;TValue&gt; or a Result&lt;TSourceValue&gt; instance to Result&lt;TValue&gt;

These types of conversions require a TValue object creation for Ok state of output Result&lt;TValue&gt; object. Any Failure information, Errors, Facts and Warnings are automatically copied to output Result.

There are various overloads of [ToResult() and ToResultAsync()](./src/ModResults/ResultExtensions.cs) extension methods that accepts TValue object factory functions and additional parameters for such conversions.

``` csharp
public record Request(string Name);

public record Response(string Reply);

public Result<Response> GetResponse(Request req, CancellationToken ct)
{
    Result<string> result = await GetMeAResultOfString(req.Name, ct);
    return result.ToResult(x => new Response(x));
}

private async Task<Result<string>> GetMeAResultOfString(string name, CancellationToken ct)
{
    //some async stuff
    await Task.CompletedTask;

    return $"Hello {name}";
}
```

### Mapping Result and Result&lt;TValue&gt; instances to another object type (usually not a Result)

These types of conversions require two seperate output object factory functions for Ok state and Failed state of input Result object.

There are various overloads of [Map() and MapAsync()](./src/ModResults/ResultMapExtensions.cs) extension methods that accepts object factory functions and additional parameters for such conversions.

ToResult extension methods described previously, also use these Map methods underneath.

``` csharp
  public static Result<TTargetValue> ToResult<TValue, TState, TTargetValue>(
    this Result<TValue> result,
    Func<TValue, TState, TTargetValue> valueFuncOnOk,
    TState state)
  {
    return result.Map<TValue, TState, Result<TTargetValue>>(
      (okResult, state) => Result<TTargetValue>.Ok(
        valueFuncOnOk(
          okResult.Value!,
          state))
        .WithStatementsFrom(okResult),
      (failResult, _) => Result<TTargetValue>.Fail(failResult),
      state);
  }
}
```

### Converting Result or Result&lt;TValue&gt; object to Minimal Apis [Microsoft.AspNetCore.Http.IResult](https://source.dot.net/#Microsoft.AspNetCore.Http.Abstractions/HttpResults/IResult.cs,a98b52b37fb3344b)

ModResults.MinimalApis project contains ToResponse() method implementations to convert Result and Result&lt;TValue&gt; instances in either Ok or Failed state to Microsoft.AspNetCore.Http.IResult.

``` csharp
public record GetBookByIdRequest(Guid Id);

public record GetBookByIdResponse(Guid Id, string Title, string Author, decimal Price);

app.MapPost("GetBookById/{Id}",
    async Task<IResult> (
    [AsParameters] GetBookByIdRequest req,
    [FromServices] IBookService svc,
    CancellationToken cancellationToken) =>
{
    Result<GetBookByIdResponse> result = await svc.GetBookById(req.Id, cancellationToken);
    return result.ToResponse();
}).Produces<GetBookByIdResponse>();

```
