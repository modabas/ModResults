## Map Result and Result&lt;TValue&gt; instances to another object type (usually not a Result)

Map functions convert a Result or Result&lt;TValue&gt; to a specified type parameter TReturn instance.

These types of conversions require two seperate output TReturn value functions for Ok state and Failed state of input Result object.

There are various overloads of [Map() and MapAsync()](../src/ModResults/ResultMapExtensions.cs) extension methods that accepts value functions and additional arguments to pass into both value functions for such conversions.

ToResult extension methods described previously, also use these Map methods underneath.

``` csharp
  public static async Task<Result<TTargetValue>> ToResultAsync<TSourceValue, TState, TTargetValue>(
    this Result<TSourceValue> result,
    Func<TSourceValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    TState state,
    CancellationToken ct)
    where TSourceValue : notnull
    where TTargetValue : notnull
  {
    return await result.MapAsync(
      static async (okResult, state, ct) => Result<TTargetValue>.Ok(
        await state.OkFactory(
          okResult.Value!,
          state.OriginalState,
          ct))
        .WithStatementsFrom(okResult),
      static (failResult, _, _) => Task.FromResult(Result<TTargetValue>.Fail(failResult)),
      new { OkFactory = valueFuncOnOk, OriginalState = state },
      ct);
  }
```

