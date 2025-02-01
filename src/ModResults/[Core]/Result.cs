using System.Diagnostics.CodeAnalysis;

namespace ModResults;

public sealed class Result<TValue, TFailure> : IModResult<TValue, TFailure>
  where TValue : notnull
  where TFailure : notnull
{
  [MemberNotNullWhen(returnValue: true, nameof(Value))]
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public bool IsOk { get; init; }

  [MemberNotNullWhen(returnValue: false, nameof(Value))]
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailed => !IsOk;

  public TValue? Value { get; init; }

  public TFailure? Failure { get; init; }

  private readonly Statements _statements =
    new(Definitions.EmptyFacts, Definitions.EmptyWarnings);
  public Statements Statements { get { return _statements; } init { _statements = value; } }

  private Result(TValue value)
  {
    IsOk = true;
    Value = value;
  }

  private Result(TFailure failure)
  {
    IsOk = false;
    Failure = failure;
  }

  //intended as single public constructor to be used from json deserialization
  public Result(
    bool isOk,
    TValue? value,
    TFailure? failure,
    Statements statements)
  {
    //by design Value cannot be null if isOk is true
    if (isOk && value is null)
    {
      throw new ArgumentNullException(nameof(value));
    }
    //by design Failure cannot be null if isOk is false
    if (!isOk && failure is null)
    {
      throw new ArgumentNullException(nameof(failure));
    }
    IsOk = isOk;
    Value = value;
    Failure = failure;
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
