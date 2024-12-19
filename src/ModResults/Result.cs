using System.Diagnostics.CodeAnalysis;

namespace ModResults;
public sealed partial class Result : IModResult<Failure>
{
  private readonly bool _isOk;

  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public bool IsOk
  {
    get => _isOk;
    init => _isOk = value;
  }

  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailed => !IsOk;

  public Failure? Failure { get; init; }

  private readonly Statements _statements =
    new(Definitions.EmptyFacts, Definitions.EmptyWarnings);
  public Statements Statements { get { return _statements; } init { _statements = value; } }

  private Result(bool isOk)
  {
    _isOk = isOk;
  }

  private Result(FailureType failureType, IEnumerable<Error> errors) : this(false)
  {
    Failure = new Failure(failureType, errors.ToList().AsReadOnly());
  }

  private Result(FailureType failureType) : this(false)
  {
    Failure = new Failure(failureType, Definitions.EmptyErrors);
  }

  //intended as single public constructor to be used from json deserialization
  public Result(
    bool isOk,
    Failure? failure,
    Statements statements)
  {
    if (!isOk)
    {
      //by design Failure cannot be null if result is failed
      if (failure is null)
      {
        throw new ArgumentNullException(nameof(failure));
      }
      Failure = failure;
    }
    _isOk = isOk;
    Statements = statements;
  }

  public static Result Ok()
  {
    return new Result(true);
  }

  public static Result<TValue> Ok<TValue>(TValue value)
  {
    return Result<TValue>.Ok(value);
  }

  public static Result<TValue, TFailure> Ok<TValue, TFailure>(TValue value)
  {
    return Result<TValue, TFailure>.Ok(value);
  }

  public static Result Fail(IModResult<Failure> result)
  {
    if (result.Failure is null)
    {
      return new Result(FailureType.Unspecified)
        .WithStatementsFrom(result);
    }
    return new Result(result.Failure.Type, result.Failure.Errors)
      .WithStatementsFrom(result);
  }
}

public sealed partial class Result<TValue> : IModResult<TValue, Failure>
{
  [MemberNotNullWhen(returnValue: true, nameof(Value))]
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public bool IsOk => !IsFailed;

  [MemberNotNullWhen(returnValue: false, nameof(Value))]
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailed => Value is null;

  public TValue? Value { get; init; }

  public Failure? Failure { get; init; }

  private readonly Statements _statements =
    new(Definitions.EmptyFacts, Definitions.EmptyWarnings);
  public Statements Statements { get { return _statements; } init { _statements = value; } }

  private Result(TValue value)
  {
    Value = value;
  }

  private Result(FailureType failureType, IEnumerable<Error> errors)
  {
    Failure = new Failure(failureType, errors.ToList().AsReadOnly());
  }

  private Result(FailureType failureType)
  {
    Failure = new Failure(failureType, Definitions.EmptyErrors);
  }

  //intended as single public constructor to be used from json deserialization
  public Result(
    TValue? value,
    Failure? failure,
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

  public static Result<TValue> Ok(TValue value)
  {
    return new Result<TValue>(value);
  }

  public static Result<TValue> Fail(IModResult<Failure> result)
  {
    if (result.Failure is null)
    {
      return new Result<TValue>(FailureType.Unspecified)
        .WithStatementsFrom(result);
    }
    return new Result<TValue>(result.Failure.Type, result.Failure.Errors)
        .WithStatementsFrom(result);
  }

  public static implicit operator Result<TValue>(TValue value)
  {
    return Ok(value);
  }

  public static implicit operator Result(Result<TValue> resultOfTValue)
  {
    return resultOfTValue.ToResult();
  }

  public static implicit operator Result<TValue>(Result<TValue, Failure> resultOfTValueAndFailure)
  {
    return resultOfTValueAndFailure.ToResultOfTValue();
  }
}
