namespace ModResults;
public static partial class ResultExtensions
{
  public static Result<TTargetValue> ToResult<TTargetValue>(
    this Result result,
    TTargetValue valueOnOk)
    where TTargetValue : notnull
  {
    return result.Map<Result<TTargetValue>>(
      okResult => Result<TTargetValue>.Ok(valueOnOk)
        .WithStatementsFrom(okResult),
      failResult => Result<TTargetValue>.Fail(failResult));
  }

  public static Result<TTargetValue> ToResult<TState, TTargetValue>(
    this Result result,
    Func<TState, TTargetValue> valueFuncOnOk,
    TState state)
    where TTargetValue : notnull
  {
    return result.Map<TState, Result<TTargetValue>>(
      (okResult, state) => Result<TTargetValue>.Ok(valueFuncOnOk(state))
        .WithStatementsFrom(okResult),
      (failResult, _) => Result<TTargetValue>.Fail(failResult),
      state);
  }

  public static async Task<Result<TTargetValue>> ToResultAsync<TState, TTargetValue>(
    this Result result,
    Func<TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    TState state,
    CancellationToken ct)
    where TTargetValue : notnull
  {
    return await result.MapAsync<TState, Result<TTargetValue>>(
      async (okResult, state, ct) => Result<TTargetValue>.Ok(await valueFuncOnOk(state, ct))
        .WithStatementsFrom(okResult),
      (failResult, _, _) => Task.FromResult(Result<TTargetValue>.Fail(failResult)),
      state,
      ct);
  }

  public static Result ToResult<TValue>(
    this Result<TValue> result)
    where TValue : notnull
  {
    return result.Map<TValue, Result>(
      okResult => Result.Ok().WithStatementsFrom(okResult),
      failResult => Result.Fail(failResult));
  }

  public static Result<TTargetValue> ToResult<TValue, TTargetValue>(
    this Result<TValue> result,
    Func<TValue, TTargetValue> valueFuncOnOk)
    where TValue : notnull
    where TTargetValue : notnull
  {
    return result.Map<TValue, Result<TTargetValue>>(
      okResult => Result<TTargetValue>.Ok(valueFuncOnOk(okResult.Value!))
        .WithStatementsFrom(okResult),
      failResult => Result<TTargetValue>.Fail(failResult));
  }

  public static Result<TTargetValue> ToResult<TValue, TState, TTargetValue>(
    this Result<TValue> result,
    Func<TValue, TState, TTargetValue> valueFuncOnOk,
    TState state)
    where TValue : notnull
    where TTargetValue : notnull
  {
    return result.Map<TValue, TState, Result<TTargetValue>>(
      (okResult, state) => Result<TTargetValue>.Ok(
        valueFuncOnOk(
          okResult.Value!,
          state))
        .WithStatementsFrom(okResult),
      (failResult, _) => Result<TTargetValue>.Fail(failResult),
      state);
  }

  public static async Task<Result<TTargetValue>> ToResultAsync<TValue, TState, TTargetValue>(
    this Result<TValue> result,
    Func<TValue, TState, CancellationToken, Task<TTargetValue>> valueFuncOnOk,
    TState state,
    CancellationToken ct)
    where TValue : notnull
    where TTargetValue : notnull
  {
    return await result.MapAsync<TValue, TState, Result<TTargetValue>>(
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
