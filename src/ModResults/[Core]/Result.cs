using System.Diagnostics.CodeAnalysis;

namespace ModResults;

public sealed class Result<TValue, TFailure> : IModResult<TValue, TFailure>
{
  [MemberNotNullWhen(returnValue: true, nameof(Value))]
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public bool IsOk => !IsFailed;

  [MemberNotNullWhen(returnValue: false, nameof(Value))]
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailed => Value is null;

  public TValue? Value { get; init; }

  public TFailure? Failure { get; init; }

  private readonly Statements _statements =
    new(Definitions.EmptyFacts, Definitions.EmptyWarnings);
  public Statements Statements { get { return _statements; } init { _statements = value; } }

  private Result(TValue value)
  {
    Value = value;
  }

  private Result(TFailure failure)
  {
    Failure = failure;
  }

  //intended as single public constructor to be used from json deserialization
  public Result(
    TValue? value,
    TFailure? failure,
    Statements statements)
  {
    if (value is null)
    {
      //by design Failure cannot be null if value is null
      if (failure is null)
      {
        throw new ArgumentNullException(nameof(failure));
      }
      Failure = failure;
    }
    Value = value;
    Statements = statements;
  }

  public static Result<TValue, TFailure> Ok(TValue value)
  {
    return new Result<TValue, TFailure>(value);
  }

  public static Result<TValue, TFailure> Fail(TFailure failure)
  {
    return new Result<TValue, TFailure>(failure);
  }

  public static Result<TValue, TFailure> Fail<TState>(IModResult<TFailure> result,
    Func<IModResult<TFailure>, TState, TFailure>? failureFuncOnOk,
    TState state)
  {
    if (result.Failure is null)
    {
      if (failureFuncOnOk is null)
      {
        throw new ArgumentNullException(nameof(failureFuncOnOk));
      }
      return new Result<TValue, TFailure>(failureFuncOnOk(result, state))
        .WithStatementsFrom(result);
    }
    return new Result<TValue, TFailure>(result.Failure)
        .WithStatementsFrom(result);
  }

  public static Result<TValue, TFailure> Fail(IModResult<TFailure> result,
    Func<IModResult<TFailure>, TFailure>? failureFuncOnOk = null)
  {
    if (result.Failure is null)
    {
      if (failureFuncOnOk is null)
      {
        throw new ArgumentNullException(nameof(failureFuncOnOk));
      }
      return new Result<TValue, TFailure>(failureFuncOnOk(result))
        .WithStatementsFrom(result);
    }
    return new Result<TValue, TFailure>(result.Failure)
        .WithStatementsFrom(result);
  }

  public static implicit operator Result<TValue, TFailure>(TValue value)
  {
    return Ok(value);
  }
}
