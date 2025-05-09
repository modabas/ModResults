## Create a Failed Result or Result&lt;TValue&gt; instance from an exception

A Failed Result instance can be created from an exception by calling [corresponding static method](../src/ModResults/FailedResult.cs) with an exception input parameter for each FailureType, or can be left to implicit operator which creates a Failed Result with FailureType CriticalError by default.

Exception object is converted to an [Error](../src/ModResults/Error.cs) object and added to Error collection of [Failure](../src/ModResults/Failure.cs).

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
