namespace ModResults;
public static partial class ResultExtensions
{
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

  public static Result ToResult<TValue>(
    this Result<TValue> result)
    where TValue : notnull
  {
    return result.Map<TValue, Result>(
      okResult => Result.Ok().WithStatementsFrom(okResult),
      failResult => Result.Fail(failResult));
  }

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
