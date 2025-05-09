# Convert Result or Result&lt;TValue&gt; object to Minimal Apis [Microsoft.AspNetCore.Http.IResult](https://source.dot.net/#Microsoft.AspNetCore.Http.Abstractions/HttpResults/IResult.cs,a98b52b37fb3344b)

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
