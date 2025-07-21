namespace ModResults;
public static partial class ResultMapExtensions
{
  /// <summary>
  /// Converts a <see cref="Result"/> to a <typeparamref name="TReturn"/> instance.
  /// </summary>
  /// <typeparam name="TReturn"></typeparam>
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <returns></returns>
  public static TReturn Map<TReturn>(
    this Result result,
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
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <param name="state">Argument value to pass into both value functions.</param>
  /// <returns></returns>
  public static TReturn Map<TState, TReturn>(
    this Result result,
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
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
  public static async Task<TReturn> MapAsync<TReturn>(
    this Result result,
    Func<Result, CancellationToken, Task<TReturn>> mapFuncOnOk,
    Func<Result, CancellationToken, Task<TReturn>> mapFuncOnFail,
    CancellationToken ct)
  {
    return result.IsOk ? await mapFuncOnOk(result, ct) :
      await mapFuncOnFail(result, ct);
  }

  /// <summary>
  /// Converts a <see cref="Result"/> to a <typeparamref name="TReturn"/> instance.
  /// </summary>
  /// <typeparam name="TState"></typeparam>
  /// <typeparam name="TReturn"></typeparam>
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <param name="state">Argument value to pass into both value functions.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
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

  /// <summary>
  /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <typeparam name="TReturn"></typeparam>
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <returns></returns>
  public static TReturn Map<TValue, TReturn>(
    this Result<TValue> result,
    Func<Result<TValue>, TReturn> mapFuncOnOk,
    Func<Result<TValue>, TReturn> mapFuncOnFail)
    where TValue : notnull
  {
    return result.IsOk ? mapFuncOnOk(result) : mapFuncOnFail(result);
  }

  /// <summary>
  /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <typeparam name="TState"></typeparam>
  /// <typeparam name="TReturn"></typeparam>
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <param name="state">Argument value to pass into both value functions.</param>
  /// <returns></returns>
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

  /// <summary>
  /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <typeparam name="TReturn"></typeparam>
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
  public static async Task<TReturn> MapAsync<TValue, TReturn>(
    this Result<TValue> result,
    Func<Result<TValue>, CancellationToken, Task<TReturn>> mapFuncOnOk,
    Func<Result<TValue>, CancellationToken, Task<TReturn>> mapFuncOnFail,
    CancellationToken ct)
    where TValue : notnull
  {
    return result.IsOk ? await mapFuncOnOk(result, ct) :
      await mapFuncOnFail(result, ct);
  }

  /// <summary>
  /// Converts a <see cref="Result{TValue}"/> to a <typeparamref name="TReturn"/> instance.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <typeparam name="TState"></typeparam>
  /// <typeparam name="TReturn"></typeparam>
  /// <param name="result"></param>
  /// <param name="mapFuncOnOk">The function used to generate return if in Ok state.</param>
  /// <param name="mapFuncOnFail">The function used to generate return if in Fail state.</param>
  /// <param name="state">Argument value to pass into both value functions.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
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
