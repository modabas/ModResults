## Convert Result&lt;TValue&gt; to Result

Converting a Result&lt;TValue&gt; object to Result is straightforward, and can be achieved by calling parameterless ToResult() method of Result&lt;TValue&gt; instance or can be left to implicit operator.

Any Failure information, Errors, Facts and Warnings are automatically copied to output Result.

## Convert a Result instance to Result&lt;TValue&gt; or a Result&lt;TSourceValue&gt; instance to Result&lt;TValue&gt;

These types of conversions require a TValue object creation for Ok state of output Result&lt;TValue&gt; object.

There are various overloads of [ToResult() and ToResultAsync()](../src/ModResults/ResultConversionExtensions.cs) extension methods that accepts TValue object factory functions and additional parameters for such conversions. Any Failure information, Errors, Facts and Warnings are automatically copied to output Result.

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
