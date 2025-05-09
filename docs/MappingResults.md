## Map Result and Result&lt;TValue&gt; instances to another object type (usually not a Result)

Map functions convert a Result or Result&lt;TValue&gt; to a specified type parameter TReturn instance.

These types of conversions require two seperate output TReturn value functions for Ok state and Failed state of input Result object.

There are various overloads of [Map() and MapAsync()](../src/ModResults/ResultMapExtensions.cs) extension methods that accepts value functions and additional arguments to pass into both value functions for such conversions.

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

