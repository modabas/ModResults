namespace ModResults;
public static partial class ResultMapExtensions
{
  public static TReturn Map<TValue, TFailure, TReturn>(
    this Result<TValue, TFailure> result,
    Func<Result<TValue, TFailure>, TReturn> mapFuncOnOk,
    Func<Result<TValue, TFailure>, TReturn> mapFuncOnFail)
  {
    return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
  }

  public static TReturn Map<TValue, TFailure, TState, TReturn>(
    this Result<TValue, TFailure> result,
    Func<Result<TValue, TFailure>, TState, TReturn> mapFuncOnOk,
    Func<Result<TValue, TFailure>, TState, TReturn> mapFuncOnFail,
    TState state)
  {
    return result.IsOk ? mapFuncOnOk(result, state) :
      mapFuncOnFail(result, state);
  }

  public static async Task<TReturn> MapAsync<TValue, TFailure, TState, TReturn>(
    this Result<TValue, TFailure> result,
    Func<Result<TValue, TFailure>, TState, CancellationToken, Task<TReturn>> mapFuncOnOk,
    Func<Result<TValue, TFailure>, TState, CancellationToken, Task<TReturn>> mapFuncOnFail,
    TState state,
    CancellationToken ct)
  {
    return result.IsOk ? await mapFuncOnOk(result, state, ct) :
      await mapFuncOnFail(result, state, ct);
  }
}
