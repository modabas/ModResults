namespace ModResults;

public static partial class ResultConversionExtensions
{
  extension(Result result)
  {
    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the provided value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueOnOk">Value to be encapsulated by returning <see cref="Result{TValue}"/> if source result in Ok state.</param>
    /// <returns></returns>
    public Result<TValue> AsResult<TValue>(
      TValue valueOnOk)
      where TValue : notnull
    {
      return result.Map<Result<TValue>>(
        okResult => new Result<TValue>(true, valueOnOk, null, okResult.PeekStatements()),
        failResult => Result<TValue>.Fail(failResult));
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <returns></returns>
    public Result<TValue> AsResult<TValue>(
      Func<TValue> valueFuncOnOk)
      where TValue : notnull
    {
      return result.AsResult(WrapFactoryCallback, valueFuncOnOk);

      //allows AsResult<TValue> and AsResult<TState, TValue> to share an implementation.
      static TValue WrapFactoryCallback(Func<TValue> callback) => callback();
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <returns></returns>
    public Result<TValue> AsResult<TState, TValue>(
      Func<TState, TValue> valueFuncOnOk,
      TState state)
      where TValue : notnull
    {
      return result.Map(
        static (okResult, state) => new Result<TValue>(
          true,
          state.OkFactory(state.OriginalState),
          null,
          okResult.PeekStatements()),
        static (failResult, _) => Result<TValue>.Fail(failResult),
        new { OkFactory = valueFuncOnOk, OriginalState = state });
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TValue>> AsResultAsync<TValue>(
      Func<CancellationToken, Task<TValue>> valueFuncOnOk,
      CancellationToken ct)
      where TValue : notnull
    {
      return result.AsResultAsync(WrapFactoryCallback, valueFuncOnOk, ct);

      //allows AsResultAsync<TValue> and AsResultAsync<TState, TValue> to share an implementation.
      static Task<TValue> WrapFactoryCallback(Func<CancellationToken, Task<TValue>> callback, CancellationToken ct) => callback(ct);
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a <see cref="Result{TValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result"/> is in Ok state, the returned <see cref="Result{TValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result"/> is in Fail state, the returned <see cref="Result{TValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TValue>> AsResultAsync<TState, TValue>(
      Func<TState, CancellationToken, Task<TValue>> valueFuncOnOk,
      TState state,
      CancellationToken ct)
      where TValue : notnull
    {
      return result.MapAsync(
        static async (okResult, state, ct) => new Result<TValue>(
          true,
          await state.OkFactory(state.OriginalState, ct).ConfigureAwait(false),
          null,
          okResult.PeekStatements()),
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
      return new(result.IsOk, result.Failure, result.PeekStatements());
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <returns></returns>
    public Result<TTargetValue> AsResult<TTargetValue>(
      Func<TSourceValue, TTargetValue> valueFuncOnOk)
      where TTargetValue : notnull
    {
      return result.AsResult(WrapFactoryCallback, valueFuncOnOk);

      //allows AsResult<TSourceValue, TTargetValue> and AsResult<TSourceValue, TState, TTargetValue> to share an implementation.
      static TTargetValue WrapFactoryCallback(TSourceValue value, Func<TSourceValue, TTargetValue> callback) => callback(value);
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <returns></returns>
    public Result<TTargetValue> AsResult<TState, TTargetValue>(
      Func<TSourceValue, TState, TTargetValue> valueFuncOnOk,
      TState state)
      where TTargetValue : notnull
    {
      return result.Map(
        static (okResult, state) => new Result<TTargetValue>(
          true,
          state.OkFactory(okResult.Value!, state.OriginalState),
          null,
          okResult.PeekStatements()),
        static (failResult, _) => Result<TTargetValue>.Fail(failResult),
        new { OkFactory = valueFuncOnOk, OriginalState = state });
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TTargetValue>> AsResultAsync<TTargetValue>(
      Func<TSourceValue, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
      CancellationToken ct)
      where TTargetValue : notnull
    {
      return result.AsResultAsync(WrapFactoryCallback, valueFuncOnOk, ct);

      //allows AsResultAsync<TSourceValue, TTargetValue> and AsResultAsync<TSourceValue, TState, TTargetValue> to share an implementation.
      static Task<TTargetValue> WrapFactoryCallback(TSourceValue value, Func<TSourceValue, CancellationToken, Task<TTargetValue>> callback, CancellationToken ct) => callback(value, ct);
    }

    /// <summary>
    /// Converts a <see cref="Result{TSourceValue}"/> to a <see cref="Result{TTargetValue}"/>, wrapping Failure and Statement objects of the source result.
    /// If source <see cref="Result{TSourceValue}"/> is in Ok state, the returned <see cref="Result{TTargetValue}"/> will be in Ok state with the result of value function as value.
    /// If source <see cref="Result{TSourceValue}"/> is in Fail state, the returned <see cref="Result{TTargetValue}"/> will be in Fail state with the same <see cref="Failure"/> information.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TTargetValue"></typeparam>
    /// <param name="valueFuncOnOk">The function used to generate value if source result in Ok state.</param>
    /// <param name="state">Argument value to pass into value function.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public Task<Result<TTargetValue>> AsResultAsync<TState, TTargetValue>(
      Func<TSourceValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
      TState state,
      CancellationToken ct)
      where TTargetValue : notnull
    {
      return result.MapAsync(
        static async (okResult, state, ct) => new Result<TTargetValue>(
          true,
          await state.OkFactory(okResult.Value!, state.OriginalState, ct).ConfigureAwait(false),
          null,
          okResult.PeekStatements()),
        static (failResult, _, _) => Task.FromResult(Result<TTargetValue>.Fail(failResult)),
        new { OkFactory = valueFuncOnOk, OriginalState = state },
        ct);
    }
  }

  extension<TValue>(Result<TValue, Failure> result) where TValue : notnull
  {
    public Result AsResult()
    {
      return new(result.IsOk, result.Failure, result.PeekStatements());
    }

    public Result<TValue> AsResultOfTValue()
    {
      return new(result.IsOk, result.Value, result.Failure, result.PeekStatements());
    }
  }
}
