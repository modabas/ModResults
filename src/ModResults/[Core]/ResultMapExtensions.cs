namespace ModResults;

public static partial class ResultMapExtensions
{
  public static TReturn Map<TValue, TFailure, TReturn>(
    this Result<TValue, TFailure> result,
    Func<Result<TValue, TFailure>, TReturn> mapFuncOnOk,
    Func<Result<TValue, TFailure>, TReturn> mapFuncOnFail)
    where TValue : notnull
    where TFailure : notnull
  {
    return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
  }

  public static TReturn Map<TValue, TFailure, TState, TReturn>(
    this Result<TValue, TFailure> result,
    Func<Result<TValue, TFailure>, TState, TReturn> mapFuncOnOk,
    Func<Result<TValue, TFailure>, TState, TReturn> mapFuncOnFail,
    TState state)
    where TValue : notnull
    where TFailure : notnull
  {
    return result.IsOk ? mapFuncOnOk(result, state) :
      mapFuncOnFail(result, state);
  }

  public static Task<TReturn> MapAsync<TValue, TFailure, TReturn>(
    this Result<TValue, TFailure> result,
    Func<Result<TValue, TFailure>, CancellationToken, Task<TReturn>> mapFuncOnOk,
    Func<Result<TValue, TFailure>, CancellationToken, Task<TReturn>> mapFuncOnFail,
    CancellationToken ct)
    where TValue : notnull
    where TFailure : notnull
  {
    return result.IsOk ? mapFuncOnOk(result, ct) :
      mapFuncOnFail(result, ct);
  }

  public static Task<TReturn> MapAsync<TValue, TFailure, TState, TReturn>(
    this Result<TValue, TFailure> result,
    Func<Result<TValue, TFailure>, TState, CancellationToken, Task<TReturn>> mapFuncOnOk,
    Func<Result<TValue, TFailure>, TState, CancellationToken, Task<TReturn>> mapFuncOnFail,
    TState state,
    CancellationToken ct)
    where TValue : notnull
    where TFailure : notnull
  {
    return result.IsOk ? mapFuncOnOk(result, state, ct) :
      mapFuncOnFail(result, state, ct);
  }
}
