namespace ModResults;

public static partial class ResultConversionExtensions
{
  extension<TSourceValue, TFailure>(Result<TSourceValue, TFailure> result)
    where TSourceValue : notnull
    where TFailure : notnull
  {
    public Result<TTargetValue, TFailure> ToResult<TTargetValue>(
    Func<TSourceValue, TTargetValue> valueFuncOnOk)
    where TTargetValue : notnull
    {
      return result.ToResult(WrapFactoryCallback, valueFuncOnOk);

      //allows ToResult<TSourceValue, TFailure, TTargetValue> and ToResult<TSourceValue, TFailure, TState, TTargetValue> to share an implementation.
      static TTargetValue WrapFactoryCallback(TSourceValue value, Func<TSourceValue, TTargetValue> callback) => callback(value);
    }

    public Result<TTargetValue, TFailure> ToResult<TState, TTargetValue>(
      Func<TSourceValue, TState, TTargetValue> valueFuncOnOk,
      TState state)
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

    public Task<Result<TTargetValue, TFailure>> ToResultAsync<TTargetValue>(
      Func<TSourceValue, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
      CancellationToken ct)
      where TTargetValue : notnull
    {
      return result.ToResultAsync(WrapFactoryCallback, valueFuncOnOk, ct);

      //allows ToResultAsync<TSourceValue, TFailure, TTargetValue> and ToResultAsync<TSourceValue, TFailure, TState, TTargetValue> to share an implementation.
      static Task<TTargetValue> WrapFactoryCallback(TSourceValue value, Func<TSourceValue, CancellationToken, Task<TTargetValue>> callback, CancellationToken ct) => callback(value, ct);
    }

    public async Task<Result<TTargetValue, TFailure>> ToResultAsync<TState, TTargetValue>(
      Func<TSourceValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
      TState state,
      CancellationToken ct)
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
}
