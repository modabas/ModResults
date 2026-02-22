namespace ModResults;

public static partial class ResultMapExtensions
{
  extension(Result result)
  {
    /// <summary>
    /// Converts a <see cref="Result"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <returns></returns>
    public TReturn Map<TReturn>(
      Func<Result, TReturn> mapFuncOnOk,
      Func<Result, TReturn> mapFuncOnFail)
    {
      return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="state">Argument value to pass into both value functions.</param>
    /// <returns></returns>
    public TReturn Map<TState, TReturn>(
      Func<Result, TState, TReturn> mapFuncOnOk,
      Func<Result, TState, TReturn> mapFuncOnFail,
      TState state)
    {
      return result.IsOk ? mapFuncOnOk(result, state) :
        mapFuncOnFail(result, state);
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<TReturn> MapAsync<TReturn>(
      Func<Result, CancellationToken, Task<TReturn>> mapFuncOnOk,
      Func<Result, CancellationToken, Task<TReturn>> mapFuncOnFail,
      CancellationToken ct)
    {
      return result.IsOk ? mapFuncOnOk(result, ct) :
        mapFuncOnFail(result, ct);
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="state">Argument value to pass into both value functions.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<TReturn> MapAsync<TState, TReturn>(
      Func<Result, TState, CancellationToken, Task<TReturn>> mapFuncOnOk,
      Func<Result, TState, CancellationToken, Task<TReturn>> mapFuncOnFail,
      TState state,
      CancellationToken ct)
    {
      return result.IsOk ? mapFuncOnOk(result, state, ct) :
        mapFuncOnFail(result, state, ct);
    }
  }

  extension<TValue>(Result<TValue> result) where TValue : notnull
  {
    /// <summary>
    /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <returns></returns>
    public TReturn Map<TReturn>(
      Func<Result<TValue>, TReturn> mapFuncOnOk,
      Func<Result<TValue>, TReturn> mapFuncOnFail)
    {
      return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="state">Argument value to pass into both value functions.</param>
    /// <returns></returns>
    public TReturn Map<TState, TReturn>(
      Func<Result<TValue>, TState, TReturn> mapFuncOnOk,
      Func<Result<TValue>, TState, TReturn> mapFuncOnFail,
      TState state)
    {
      return result.IsOk ? mapFuncOnOk(result, state) :
        mapFuncOnFail(result, state);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<TReturn> MapAsync<TReturn>(
      Func<Result<TValue>, CancellationToken, Task<TReturn>> mapFuncOnOk,
      Func<Result<TValue>, CancellationToken, Task<TReturn>> mapFuncOnFail,
      CancellationToken ct)
    {
      return result.IsOk ? mapFuncOnOk(result, ct) :
        mapFuncOnFail(result, ct);
    }

    /// <summary>
    /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <param name="mapFuncOnOk">The function used to generate return if source result in Ok state.</param>
    /// <param name="mapFuncOnFail">The function used to generate return if source result is in Fail state.</param>
    /// <param name="state">Argument value to pass into both value functions.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<TReturn> MapAsync<TState, TReturn>(
      Func<Result<TValue>, TState, CancellationToken, Task<TReturn>> mapFuncOnOk,
      Func<Result<TValue>, TState, CancellationToken, Task<TReturn>> mapFuncOnFail,
      TState state,
      CancellationToken ct)
    {
      return result.IsOk ? mapFuncOnOk(result, state, ct) :
        mapFuncOnFail(result, state, ct);
    }
  }
}
