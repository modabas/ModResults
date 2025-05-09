## Add information to Result instances

All types of Result implementations contain a Statement property which encapsulates collections of [Fact](../src/ModResults/[Core]/Fact.cs) and [Warning](../src/ModResults/[Core]/Warning.cs) classes.

See various [WithFact](../src/ModResults/ResultFactExtensions.cs) and [WithWarning](../src/ModResults/ResultWarningExtensions.cs) extension methods to add fact and warning information to result instances.

Default [Failure](../src/ModResults/Failure.cs) implementation used in Result and Result&lt;TValue&gt; objects, has a Type property holding [FailureType](../src/ModResults/FailureType.cs) and also contains a collection of [Errors](../src/ModResults/Error.cs).

See various static methods of Result objects to [create a Failed Result](../src/ModResults/FailedResult.cs) containing Error information. Errors can only be attached to a Failed Result instance during Result instance creation and cannot be added or removed afterwards.

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
