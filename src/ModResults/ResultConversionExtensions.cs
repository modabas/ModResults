namespace ModResults;

public static partial class ResultConversionExtensions
{
  extension(Result result)
  {
    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the provided value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueOnOk">Value to be encapsulated by returning <see cref="Result{TValue}"/> if source result in Ok state.</param>
    /// <returns></returns>
    public Result<TValue> ToResult<TValue>(
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
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <returns></returns>
    public Result<TValue> ToResult<TValue>(
      Func<TValue> valueFuncOnOk)
      where TValue : notnull
    {
      return result.ToResult(WrapFactoryCallback, valueFuncOnOk);

      //allows ToResult<TValue> and ToResult<TState, TValue> to share an implementation.
      static TValue WrapFactoryCallback(Func<TValue> callback) => callback();
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <returns></returns>
    public Result<TValue> ToResult<TState, TValue>(
      Func<TState, TValue> valueFuncOnOk,
      TState state)
      where TValue : notnull
    {
      return result.Map(
        static (okResult, state) => Result<TValue>.Ok(state.OkFactory(state.OriginalState))
          .WithStatementsFrom(okResult),
        static (failResult, _) => Result<TValue>.Fail(failResult),
        new { OkFactory = valueFuncOnOk, OriginalState = state });
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TValue>> ToResultAsync<TValue>(
      Func<CancellationToken, Task<TValue>> valueFuncOnOk,
      CancellationToken ct)
      where TValue : notnull
    {
      return result.ToResultAsync(WrapFactoryCallback, valueFuncOnOk, ct);

      //allows ToResultAsync<TValue> and ToResultAsync<TState, TValue> to share an implementation.
      static Task<TValue> WrapFactoryCallback(Func<CancellationToken, Task<TValue>> callback, CancellationToken ct) => callback(ct);
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, copying over Statements.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TValue>> ToResultAsync<TState, TValue>(
      Func<TState, CancellationToken, Task<TValue>> valueFuncOnOk,
      TState state,
      CancellationToken ct)
      where TValue : notnull
    {
      return result.MapAsync(
        static async (okResult, state, ct) => Result<TValue>
          .Ok(await state.OkFactory(state.OriginalState, ct).ConfigureAwait(false))
          .WithStatementsFrom(okResult),
        static (failResult, _, _) => Task.FromResult(Result<TValue>.Fail(failResult)),
        new { OkFactory = valueFuncOnOk, OriginalState = state },
        ct);
    }
  }

  extension<TSourceValue>(Result<TSourceValue> result) where TSourceValue : notnull
  {
    /// <summary>
    /// Returns a <see cref="Result"/> that wraps the same state, Failure and Statements as the source <see cref="Result{TSourceValue}"/>.
    /// </summary>
    /// <returns></returns>
    public Result AsResult()
    {
      return new(result.IsOk, result.Failure, result.Statements);
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result"/>, copying over Statements.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <returns></returns>
    public Result ToResult()
    {
      return result.Map<TSourceValue, Result>(
        okResult => Result.Ok().WithStatementsFrom(okResult),
        failResult => Result.Fail(failResult));
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <returns></returns>
    public Result<TTargetValue> ToResult<TTargetValue>(
      Func<TSourceValue, TTargetValue> valueFuncOnOk)
      where TTargetValue : notnull
    {
      return result.ToResult(WrapFactoryCallback, valueFuncOnOk);

      //allows ToResult<TSourceValue, TTargetValue> and ToResult<TSourceValue, TState, TTargetValue> to share an implementation.
      static TTargetValue WrapFactoryCallback(TSourceValue value, Func<TSourceValue, TTargetValue> callback) => callback(value);
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <returns></returns>
    public Result<TTargetValue> ToResult<TState, TTargetValue>(
      Func<TSourceValue, TState, TTargetValue> valueFuncOnOk,
      TState state)
      where TTargetValue : notnull
    {
      return result.Map(
        static (okResult, state) => Result<TTargetValue>.Ok(
          state.OkFactory(
            okResult.Value!,
            state.OriginalState))
          .WithStatementsFrom(okResult),
        static (failResult, _) => Result<TTargetValue>.Fail(failResult),
        new { OkFactory = valueFuncOnOk, OriginalState = state });
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TTargetValue>> ToResultAsync<TTargetValue>(
      Func<TSourceValue, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
      CancellationToken ct)
      where TTargetValue : notnull
    {
      return result.ToResultAsync(WrapFactoryCallback, valueFuncOnOk, ct);

      //allows ToResultAsync<TSourceValue, TTargetValue> and ToResultAsync<TSourceValue, TState, TTargetValue> to share an implementation.
      static Task<TTargetValue> WrapFactoryCallback(TSourceValue value, Func<TSourceValue, CancellationToken, Task<TTargetValue>> callback, CancellationToken ct) => callback(value, ct);
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, copying over Statements.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TTargetValue>> ToResultAsync<TState, TTargetValue>(
      Func<TSourceValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
      TState state,
      CancellationToken ct)
      where TTargetValue : notnull
    {
      return result.MapAsync(
        static async (okResult, state, ct) => Result<TTargetValue>.Ok(
          await state.OkFactory(
            okResult.Value!,
            state.OriginalState,
            ct).ConfigureAwait(false))
          .WithStatementsFrom(okResult),
        static (failResult, _, _) => Task.FromResult(Result<TTargetValue>.Fail(failResult)),
        new { OkFactory = valueFuncOnOk, OriginalState = state },
        ct);
    }
  }

  extension<TValue>(Result<TValue, Failure> result) where TValue : notnull
  {
    public Result AsResult()
    {
      return new(result.IsOk, result.Failure, result.Statements);
    }

    public Result<TValue> AsResultOfTValue()
    {
      return new(result.IsOk, result.Value, result.Failure, result.Statements);
    }

    public Result ToResult()
    {
      return result.Map<TValue, Failure, Result>(
        okResult => Result.Ok().WithStatementsFrom(okResult),
        failResult => Result.Fail(failResult));
    }

    public Result<TValue> ToResultOfTValue()
    {
      return result.Map<TValue, Failure, Result<TValue>>(
        okResult => Result<TValue>.Ok(result.Value!).WithStatementsFrom(okResult),
        failResult => Result<TValue>.Fail(failResult));
    }
  }
}
