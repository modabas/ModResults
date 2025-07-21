namespace ModResults;
public static partial class ResultConversionExtensions
{
  /// <summary>
  /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the provided value.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueOnOk">Value to be encapsulated by returning <see cref="Result{TValue}"/> if in Ok state.</param>
  /// <returns></returns>
  public static Result<TValue> ToResult<TValue>(
    this Result result,
    TValue valueOnOk)
    where TValue : notnull
  {
    return result.Map<Result<TValue>>(
      okResult => Result<TValue>.Ok(valueOnOk)
        .WithStatementsFrom(okResult),
      failResult => Result<TValue>.Fail(failResult));
  }

  /// <summary>
  /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <returns></returns>
  public static Result<TValue> ToResult<TValue>(
    this Result result,
    Func<TValue> valueFuncOnOk)
    where TValue : notnull
  {
    return result.Map<Result<TValue>>(
      (okResult) => Result<TValue>.Ok(valueFuncOnOk())
        .WithStatementsFrom(okResult),
      (failResult) => Result<TValue>.Fail(failResult));
  }

  /// <summary>
  /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TState"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <param name="state">Argument value to pass into value function.</param>
  /// <returns></returns>
  public static Result<TValue> ToResult<TState, TValue>(
    this Result result,
    Func<TState, TValue> valueFuncOnOk,
    TState state)
    where TValue : notnull
  {
    return result.Map<TState, Result<TValue>>(
      (okResult, state) => Result<TValue>.Ok(valueFuncOnOk(state))
        .WithStatementsFrom(okResult),
      (failResult, _) => Result<TValue>.Fail(failResult),
      state);
  }

  /// <summary>
  /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
  public static async Task<Result<TValue>> ToResultAsync<TValue>(
    this Result result,
    Func<CancellationToken, Task<TValue>> valueFuncOnOk,
    CancellationToken ct)
    where TValue : notnull
  {
    return await result.MapAsync<Result<TValue>>(
      async (okResult, ct) => Result<TValue>.Ok(await valueFuncOnOk(ct))
        .WithStatementsFrom(okResult),
      (failResult, _) => Task.FromResult(Result<TValue>.Fail(failResult)),
      ct);
  }

  /// <summary>
  /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TState"></typeparam>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <param name="state">Argument value to pass into value function.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
  public static async Task<Result<TValue>> ToResultAsync<TState, TValue>(
    this Result result,
    Func<TState, CancellationToken, Task<TValue>> valueFuncOnOk,
    TState state,
    CancellationToken ct)
    where TValue : notnull
  {
    return await result.MapAsync<TState, Result<TValue>>(
      async (okResult, state, ct) => Result<TValue>.Ok(await valueFuncOnOk(state, ct))
        .WithStatementsFrom(okResult),
      (failResult, _, _) => Task.FromResult(Result<TValue>.Fail(failResult)),
      state,
      ct);
  }

  /// <summary>
  /// Converts a <see cref="Result{TValue}"/> to a <see cref="Result"/>, copying over Statements.
  /// If source <see cref="Result{TValue}"/> is in Fail state, the returned <see cref="Result"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <returns></returns>
  public static Result ToResult<TValue>(
    this Result<TValue> result)
    where TValue : notnull
  {
    return result.Map<TValue, Result>(
      okResult => Result.Ok().WithStatementsFrom(okResult),
      failResult => Result.Fail(failResult));
  }

  /// <summary>
  /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
  /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TSourceValue"></typeparam>
  /// <typeparam name="TTargetValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <returns></returns>
  public static Result<TTargetValue> ToResult<TSourceValue, TTargetValue>(
    this Result<TSourceValue> result,
    Func<TSourceValue, TTargetValue> valueFuncOnOk)
    where TSourceValue : notnull
    where TTargetValue : notnull
  {
    return result.Map<TSourceValue, Result<TTargetValue>>(
      okResult => Result<TTargetValue>.Ok(valueFuncOnOk(okResult.Value!))
        .WithStatementsFrom(okResult),
      failResult => Result<TTargetValue>.Fail(failResult));
  }

  /// <summary>
  /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
  /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TSourceValue"></typeparam>
  /// <typeparam name="TState"></typeparam>
  /// <typeparam name="TTargetValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <param name="state">Argument value to pass into value function.</param>
  /// <returns></returns>
  public static Result<TTargetValue> ToResult<TSourceValue, TState, TTargetValue>(
    this Result<TSourceValue> result,
    Func<TSourceValue, TState, TTargetValue> valueFuncOnOk,
    TState state)
    where TSourceValue : notnull
    where TTargetValue : notnull
  {
    return result.Map<TSourceValue, TState, Result<TTargetValue>>(
      (okResult, state) => Result<TTargetValue>.Ok(
        valueFuncOnOk(
          okResult.Value!,
          state))
        .WithStatementsFrom(okResult),
      (failResult, _) => Result<TTargetValue>.Fail(failResult),
      state);
  }

  /// <summary>
  /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
  /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TSourceValue"></typeparam>
  /// <typeparam name="TTargetValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
  public static async Task<Result<TTargetValue>> ToResultAsync<TSourceValue, TTargetValue>(
    this Result<TSourceValue> result,
    Func<TSourceValue, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    CancellationToken ct)
    where TSourceValue : notnull
    where TTargetValue : notnull
  {
    return await result.MapAsync<TSourceValue, Result<TTargetValue>>(
      async (okResult, ct) => Result<TTargetValue>.Ok(
        await valueFuncOnOk(
          okResult.Value!,
          ct))
        .WithStatementsFrom(okResult),
      (failResult, _) => Task.FromResult(Result<TTargetValue>.Fail(failResult)),
      ct);
  }

  /// <summary>
  /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
  /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
  /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
  /// </summary>
  /// <typeparam name="TSourceValue"></typeparam>
  /// <typeparam name="TState"></typeparam>
  /// <typeparam name="TTargetValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="valueFuncOnOk">The function used to generate value if in Ok state.</param>
  /// <param name="state">Argument value to pass into value function.</param>
  /// <param name="ct"></param>
  /// <returns></returns>
  public static async Task<Result<TTargetValue>> ToResultAsync<TSourceValue, TState, TTargetValue>(
    this Result<TSourceValue> result,
    Func<TSourceValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    TState state,
    CancellationToken ct)
    where TSourceValue : notnull
    where TTargetValue : notnull
  {
    return await result.MapAsync<TSourceValue, TState, Result<TTargetValue>>(
      async (okResult, state, ct) => Result<TTargetValue>.Ok(
        await valueFuncOnOk(
          okResult.Value!,
          state,
          ct))
        .WithStatementsFrom(okResult),
      (failResult, _, _) => Task.FromResult(Result<TTargetValue>.Fail(failResult)),
      state,
      ct);
  }

  public static Result ToResult<TValue>(
    this Result<TValue, Failure> result)
    where TValue : notnull
  {
    return result.Map<TValue, Failure, Result>(
      okResult => Result.Ok().WithStatementsFrom(okResult),
      failResult => Result.Fail(failResult));
  }

  public static Result<TValue> ToResultOfTValue<TValue>(
    this Result<TValue, Failure> result)
    where TValue : notnull
  {
    return result.Map<TValue, Failure, Result<TValue>>(
      okResult => Result<TValue>.Ok(result.Value!).WithStatementsFrom(okResult),
      failResult => Result<TValue>.Fail(failResult));
  }
}
