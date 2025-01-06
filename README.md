# ModResults

[![Nuget downloads](https://img.shields.io/nuget/v/ModResults.svg)](https://www.nuget.org/packages/ModResults/)
[![Nuget](https://img.shields.io/nuget/dt/ModResults)](https://www.nuget.org/packages/ModResults/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/modabas/ModResults/blob/main/LICENSE.txt)

Result Pattern that provides a structured way to represent success or failure with optional details, enhancing readability and maintainability in codebases and designed to be used either in-process or over the network. It is robust, leveraging nullability annotations, immutability (init properties), and factory methods for clarity.

ModResult package contains [Result and Result&lt;TValue&gt;](./src/ModResults/Result.cs) implementations with a default [Failure](./src/ModResults/Failure.cs) implementation which are ready to be used out of the box. It also contains a [Result&lt;TValue, TFailure&gt;](./src/ModResults/[Core]/Result.cs) implementation, but this requires further development for a custom failure class at least.

Additional packages provide out of the box extensions for Result objects to be used in various scenarios:
- To create invalid Result and Result&lt;TValue&gt; instances from failed [FluentValidations.Results.ValidationResult](https://github.com/FluentValidation/FluentValidation) objects, ModResults.FluentValidations package contains default implementations.

- To convert Result and Result&lt;TValue&gt; instances in either Ok or any [FailureType](./src/ModResults/FailureType.cs) state to Microsoft.AspNetCore.Http.IResult, ModResults.MinimalApis package provide default implementations.

- To be able to use Result and Result&lt;TValue&gt; objects in [Microsoft.Orleans](https://github.com/dotnet/orleans) projects, surrogate and converter implementations required by Orleans serializer are implemented in ModResults.Orleans package.

## How To

### Create a Result or Result&lt;TValue&gt; instance

An Ok Result instance can be created by calling Result.Ok() or Result&lt;TValue&gt;.Ok(TValue value) static methods. Result&lt;TValue&gt; also has an implicit operator to convert an instance of type TValue to a Result&lt;TValue&gt; in Ok state.

A Failed Result instance can be created by calling [corresponding static method](./src/ModResults/FailedResult.cs) for each FailureType (i.e. Result.NotFound() or Result&lt;TValue&gt;.NotFound() for creating a Result object in Failed state with FailureType NotFound).

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

### Check state of a Result or Result&lt;TValue&gt; instance

State of a result is either Ok or Failed. State of a result instance can be checked from IsOk and IsFailed boolean properties.

If state is Ok, Result&lt;TValue&gt; instance contains a not null Value property of type TValue.

If state is Failed, Result and Result&lt;TValue&gt; instances contain a not null Failure property of type Failure.

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

### Add information to Result instances

All types of Result implementations contain a Statement property which encapsulates collections of [Fact](./src/ModResults/[Core]/Fact.cs) and [Warning](./src/ModResults/[Core]/Warning.cs) classes.

See various [WithFact](./src/ModResults/ResultFactExtensions.cs) and [WithWarning](./src/ModResults/ResultWarningExtensions.cs) extension methods to add fact and warning information to result instances.

Default [Failure](./src/ModResults/Failure.cs) implementation used in Result and Result&lt;TValue&gt; objects, has a Type property holding [FailureType](./src/ModResults/FailureType.cs) and also contains a collection of [Errors](./src/ModResults/Error.cs).

See various static methods of Result objects to [create a Failed Result](./src/ModResults/FailedResult.cs) containing Error information. Errors can only be attached to a Failed Result instance during Result instance creation and cannot be added or removed afterwards.

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

### Create a Failed Result or Result&lt;TValue&gt; instance from an exception

A Failed Result instance can be created from an exception by calling [corresponding static method](./src/ModResults/FailedResult.cs) with an exception input parameter for each FailureType, or can be left to implicit operator which creates a Failed Result with FailureType CriticalError by default.

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

### Convert Result&lt;TValue&gt; to Result

Converting a Result&lt;TValue&gt; object to Result is straightforward, and can be achieved by calling parameterless ToResult() method of Result&lt;TValue&gt; instance or can be left to implicit operator.

Any Failure information, Errors, Facts and Warnings are automatically copied to output Result.

### Convert a Result instance to Result&lt;TValue&gt; or a Result&lt;TSourceValue&gt; instance to Result&lt;TValue&gt;

These types of conversions require a TValue object creation for Ok state of output Result&lt;TValue&gt; object.

There are various overloads of [ToResult() and ToResultAsync()](./src/ModResults/ResultExtensions.cs) extension methods that accepts TValue object factory functions and additional parameters for such conversions. Any Failure information, Errors, Facts and Warnings are automatically copied to output Result.

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

### Map Result and Result&lt;TValue&gt; instances to another object type (usually not a Result)

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

### Convert Result or Result&lt;TValue&gt; object to Minimal Apis [Microsoft.AspNetCore.Http.IResult](https://source.dot.net/#Microsoft.AspNetCore.Http.Abstractions/HttpResults/IResult.cs,a98b52b37fb3344b)

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

If you are using Minimal Apis and want to map a Result or Result&lt;TValue&gt; to api response, do have a look at WebServiceEndpoint implementation in [ModEndpoints](https://github.com/modabas/ModEndpoints) project which can organize ASP.NET Core Minimal Apis in REPR format endpoints and is integrated with result pattern out of box, which will also handle response mapping.
