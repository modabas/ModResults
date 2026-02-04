namespace ModResults;

public static partial class ResultConversionExtensions
{
  public static Result<TTargetValue, TFailure> ToResult<TSourceValue, TFailure, TTargetValue>(
    this Result<TSourceValue, TFailure> result,
    Func<TSourceValue, TTargetValue> valueFuncOnOk)
    where TSourceValue : notnull
    where TFailure : notnull
    where TTargetValue : notnull
  {
    return result.ToResult(WrapFactoryCallback, valueFuncOnOk);

    //allows ToResult<TSourceValue, TFailure, TTargetValue> and ToResult<TSourceValue, TFailure, TState, TTargetValue> to share an implementation.
    static TTargetValue WrapFactoryCallback(TSourceValue value, Func<TSourceValue, TTargetValue> callback) => callback(value);
  }

  public static Result<TTargetValue, TFailure> ToResult<TSourceValue, TFailure, TState, TTargetValue>(
    this Result<TSourceValue, TFailure> result,
    Func<TSourceValue, TState, TTargetValue> valueFuncOnOk,
    TState state)
    where TSourceValue : notnull
    where TFailure : notnull
    where TTargetValue : notnull
  {
    return result.Map(
      static (okResult, state) => Result<TTargetValue, TFailure>.Ok(
        state.OkFactory(
          okResult.Value!,
          state.OriginalState))
        .WithStatementsFrom(okResult),
      static (failResult, _) => Result<TTargetValue, TFailure>.Fail(failResult),
      new { OkFactory = valueFuncOnOk, OriginalState = state });
  }

  public static Task<Result<TTargetValue, TFailure>> ToResultAsync<TSourceValue, TFailure, TTargetValue>(
    this Result<TSourceValue, TFailure> result,
    Func<TSourceValue, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    CancellationToken ct)
    where TSourceValue : notnull
    where TFailure : notnull
    where TTargetValue : notnull
  {
    return result.ToResultAsync(WrapFactoryCallback, valueFuncOnOk, ct);

    //allows ToResultAsync<TSourceValue, TFailure, TTargetValue> and ToResultAsync<TSourceValue, TFailure, TState, TTargetValue> to share an implementation.
    static Task<TTargetValue> WrapFactoryCallback(TSourceValue value, Func<TSourceValue, CancellationToken, Task<TTargetValue>> callback, CancellationToken ct) => callback(value, ct);
  }

  public static async Task<Result<TTargetValue, TFailure>> ToResultAsync<TSourceValue, TFailure, TState, TTargetValue>(
    this Result<TSourceValue, TFailure> result,
    Func<TSourceValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    TState state,
    CancellationToken ct)
    where TSourceValue : notnull
    where TFailure : notnull
    where TTargetValue : notnull
  {
    return await result.MapAsync(
      static async (okResult, state, ct) => Result<TTargetValue, TFailure>.Ok(
        await state.OkFactory(
          okResult.Value!,
          state.OriginalState,
          ct).ConfigureAwait(false))
        .WithStatementsFrom(okResult),
      static (failResult, _, _) => Task.FromResult(Result<TTargetValue, TFailure>.Fail(failResult)),
      new { OkFactory = valueFuncOnOk, OriginalState = state },
      ct).ConfigureAwait(false);
  }
}
