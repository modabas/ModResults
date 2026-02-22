namespace ModResults;

public static partial class ResultMapExtensions
{
  extension<TValue, TFailure>(Result<TValue, TFailure> result)
    where TValue : notnull
    where TFailure : notnull
  {
    /// <summary>
    /// Converts a <see cref="Result{TValue, TFailure}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <returns></returns>
    public TReturn Map<TReturn>(
      Func<Result<TValue, TFailure>, TReturn> mapFuncOnOk,
      Func<Result<TValue, TFailure>, TReturn> mapFuncOnFail)
    {
      return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue, TFailure}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="state">Argument value to pass into both value functions.</param>
    /// <returns></returns>
    public TReturn Map<TState, TReturn>(
      Func<Result<TValue, TFailure>, TState, TReturn> mapFuncOnOk,
      Func<Result<TValue, TFailure>, TState, TReturn> mapFuncOnFail,
      TState state)
    {
      return result.IsOk ? mapFuncOnOk(result, state) :
        mapFuncOnFail(result, state);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue, TFailure}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<TReturn> MapAsync<TReturn>(
      Func<Result<TValue, TFailure>, CancellationToken, Task<TReturn>> mapFuncOnOk,
      Func<Result<TValue, TFailure>, CancellationToken, Task<TReturn>> mapFuncOnFail,
      CancellationToken ct)
    {
      return result.IsOk ? mapFuncOnOk(result, ct) :
        mapFuncOnFail(result, ct);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue, TFailure}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="state">Argument value to pass into both value functions.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<TReturn> MapAsync<TState, TReturn>(
      Func<Result<TValue, TFailure>, TState, CancellationToken, Task<TReturn>> mapFuncOnOk,
      Func<Result<TValue, TFailure>, TState, CancellationToken, Task<TReturn>> mapFuncOnFail,
      TState state,
      CancellationToken ct)
    {
      return result.IsOk ? mapFuncOnOk(result, state, ct) :
        mapFuncOnFail(result, state, ct);
    }
  }
}
