# ModResults

[![Nuget downloads](https://img.shields.io/nuget/v/ModResults.svg)](https://www.nuget.org/packages/ModResults/)
[![Nuget](https://img.shields.io/nuget/dt/ModResults)](https://www.nuget.org/packages/ModResults/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/modabas/ModResults/blob/master/LICENSE.txt)

Result Pattern that provides a structured way to represent success or failure with optional details, enhancing readability and maintainability in codebases and designed to be used either in-process or over the network.

It is robust, leveraging nullability annotations, immutability (init properties), and factory methods for clarity.

Contains [Result and Result&lt;TValue&gt;](./src/ModResults/Result.cs) implementations with a default [Failure](./src/ModResults/Failure.cs) implementation which are ready to be used in projects.

Also contains a [Result&lt;TValue, TFailure&gt;](./src/ModResults/[Core]/Result.cs) implementation, but this requires further development for a custom failure object and various extension methods to be able to create failed result objects for various possibly different failure types.

# ModResults.FluentValidations

Default implementations to convert failed FluentValidations.Results.ValidationResult instances to invalid Result and Result&lt;TValue&gt; objects.

# ModResults.MinimalApis

Default implementations to convert Result and Result&lt;TValue&gt; instances in either Ok or any [FailureType](./src/ModResults/FailureType.cs) state to Microsoft.AspNetCore.Http.IResult.

# ModResults.Orleans

Surrogate and converter implementations for Result and Result&lt;TValue&gt; objects to be used in Microsoft.Orleans projects.

## Usage

### Creating a Result or Result&lt;TValue&gt; object

Creating an ok Result instance is done by calling Result.Ok() or Result&lt;TValue&gt;.Ok(TValue value) static methods.

Creating a failed Result instance is done by calling [corresponding static method](./src/ModResults/FailedResult.cs) for each FailureType (i.e. Result.NotFound() or Result&lt;TValue&gt;.NotFound() for creating a failed Result object with FailureType NotFound).

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

### Checking state of a Result or Result&lt;TValue&gt; object

State of a result instance is either ok or failed. State can be checked from result.IsOk and result.IsFailed boolean properties.

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

### Converting Result&lt;TValue&gt; to Result

Converting a Result&lt;TValue&gt; object to Result is straightforward, and can be achieved by calling parameterless ToResult() method of Result&lt;TValue&gt; instance or can be left to implicit operator.

### Converting Result to Result&lt;TValue&gt; or Result&lt;TSourceValue&gt; to Result&lt;TValue&gt;

These types of conversions require a TValue object creation for Ok state of output Result&lt;TValue&gt; object. There are various overloads of ToResult() and ToResultAsync() extension method that accepts TValue object factory functions and additional parameters for such conversions.

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
