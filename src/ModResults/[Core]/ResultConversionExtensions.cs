namespace ModResults;
public static partial class ResultConversionExtensions
{
  public static Result<TTargetValue, TFailure> ToResult<TValue, TFailure, TTargetValue>(
    this Result<TValue, TFailure> result,
    Func<TValue, TTargetValue> valueFuncOnOk)
    where TValue : notnull
    where TFailure : class
    where TTargetValue : notnull
  {
    return result.Map<TValue, TFailure, Result<TTargetValue, TFailure>>(
      okResult => Result<TTargetValue, TFailure>.Ok(valueFuncOnOk(okResult.Value!))
        .WithStatementsFrom(okResult),
      failResult => Result<TTargetValue, TFailure>.Fail(failResult));
  }

  public static Result<TTargetValue, TFailure> ToResult<TValue, TFailure, TState, TTargetValue>(
    this Result<TValue, TFailure> result,
    Func<TValue, TState, TTargetValue> valueFuncOnOk,
    TState state)
    where TValue : notnull
    where TFailure : class
    where TTargetValue : notnull
  {
    return result.Map<TValue, TFailure, TState, Result<TTargetValue, TFailure>>(
      (okResult, state) => Result<TTargetValue, TFailure>.Ok(
        valueFuncOnOk(
          okResult.Value!,
          state))
        .WithStatementsFrom(okResult),
      (failResult, _) => Result<TTargetValue, TFailure>.Fail(failResult),
      state);
  }

  public static async Task<Result<TTargetValue, TFailure>> ToResultAsync<TValue, TFailure, TState, TTargetValue>(
    this Result<TValue, TFailure> result,
    Func<TValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    TState state,
    CancellationToken ct)
    where TValue : notnull
    where TFailure : class
    where TTargetValue : notnull
  {
    return await result.MapAsync<TValue, TFailure, TState, Result<TTargetValue, TFailure>>(
      async (okResult, state, ct) => Result<TTargetValue, TFailure>.Ok(
        await valueFuncOnOk(
          okResult.Value!,
          state,
          ct))
        .WithStatementsFrom(okResult),
      (failResult, _, _) => Task.FromResult(Result<TTargetValue, TFailure>.Fail(failResult)),
      state,
      ct);
  }
}
