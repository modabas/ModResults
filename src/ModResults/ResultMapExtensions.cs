namespace ModResults;
public static partial class ResultMapExtensions
{
  public static TReturn Map<TReturn>(
    this Result result,
    Func<Result, TReturn> mapFuncOnOk,
    Func<Result, TReturn> mapFuncOnFail)
  {
    return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
  }

  public static TReturn Map<TState, TReturn>(
    this Result result,
    Func<Result, TState, TReturn> mapFuncOnOk,
    Func<Result, TState, TReturn> mapFuncOnFail,
    TState state)
  {
    return result.IsOk ? mapFuncOnOk(result, state) :
      mapFuncOnFail(result, state);
  }

  public static async Task<TReturn> MapAsync<TState, TReturn>(
    this Result result,
    Func<Result, TState, CancellationToken, Task<TReturn>> mapFuncOnOk,
    Func<Result, TState, CancellationToken, Task<TReturn>> mapFuncOnFail,
    TState state,
    CancellationToken ct)
  {
    return result.IsOk ? await mapFuncOnOk(result, state, ct) :
      await mapFuncOnFail(result, state, ct);
  }

  public static TReturn Map<TValue, TReturn>(
    this Result<TValue> result,
    Func<Result<TValue>, TReturn> mapFuncOnOk,
    Func<Result<TValue>, TReturn> mapFuncOnFail)
    where TValue : notnull
  {
    return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
  }

  public static TReturn Map<TValue, TState, TReturn>(
    this Result<TValue> result,
    Func<Result<TValue>, TState, TReturn> mapFuncOnOk,
    Func<Result<TValue>, TState, TReturn> mapFuncOnFail,
    TState state)
    where TValue : notnull
  {
    return result.IsOk ? mapFuncOnOk(result, state) :
      mapFuncOnFail(result, state);
  }

  public static async Task<TReturn> MapAsync<TValue, TState, TReturn>(
    this Result<TValue> result,
    Func<Result<TValue>, TState, CancellationToken, Task<TReturn>> mapFuncOnOk,
    Func<Result<TValue>, TState, CancellationToken, Task<TReturn>> mapFuncOnFail,
    TState state,
    CancellationToken ct)
    where TValue : notnull
  {
    return result.IsOk ? await mapFuncOnOk(result, state, ct) :
      await mapFuncOnFail(result, state, ct);
  }
}
