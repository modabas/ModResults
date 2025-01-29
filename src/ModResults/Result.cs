using System.Diagnostics.CodeAnalysis;

namespace ModResults;

/// <summary>
/// A business result that represents the outcome of an operation, encapsulating either success or failure states, along with associated error messages and additional information.
/// </summary>
public sealed partial class Result : IModResult<Failure>
{
  private readonly bool _isOk;

  /// <summary>
  /// Gets if state of result instance is Ok.
  /// </summary>
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public bool IsOk
  {
    get => _isOk;
    init => _isOk = value;
  }

  /// <summary>
  /// Gets if state of result instance is Failed.
  /// </summary>
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailed => !IsOk;

  /// <summary>
  /// Contains failure info for a failed <see cref="Result"/> instance. Not null when <see cref="IsFailed"/> is true.
  /// </summary>
  public Failure? Failure { get; init; }

  private readonly Statements _statements =
    new(Definitions.EmptyFacts, Definitions.EmptyWarnings);

  /// <summary>
  /// Contains facts and warnings for the result.
  /// </summary>
  public Statements Statements { get { return _statements; } init { _statements = value; } }

  private Result()
  {
    _isOk = true;
  }

  private Result(FailureType failureType, IEnumerable<Error> errors)
  {
    _isOk = false;
    Failure = new Failure(failureType, errors.ToList().AsReadOnly());
  }

  private Result(FailureType failureType)
  {
    _isOk = false;
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

  /// <summary>
  /// Creates a <see cref="Result"/> in Ok state.
  /// </summary>
  /// <returns></returns>
  public static Result Ok()
  {
    return new Result();
  }

  /// <summary>
  /// Creates a <see cref="Result{TValue}"/> in Ok state containing input value.
  /// </summary>
  /// <typeparam name="TValue">Type of the input value.</typeparam>
  /// <param name="value">Value that will be encapsulated in an Ok <see cref="Result{TValue}"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Ok<TValue>(TValue value)
    where TValue : notnull
  {
    return Result<TValue>.Ok(value);
  }

  /// <summary>
  /// Creates a <see cref="Result{TValue, TFailure}"/> in Ok state containing input value.
  /// </summary>
  /// <typeparam name="TValue">Type of the input value.</typeparam>
  /// <typeparam name="TFailure">Type of the failure property of result object.</typeparam>
  /// <param name="value">Value that will be encapsulated in an Ok <see cref="Result{TValue, TFailure}"/>.</param>
  /// <returns></returns>
  public static Result<TValue, TFailure> Ok<TValue, TFailure>(TValue value)
    where TValue : notnull
    where TFailure : notnull
  {
    return Result<TValue, TFailure>.Ok(value);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> from another result instance whose failure property is of type <see cref="ModResults.Failure"/>, copying over Statements and any Failure information.
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
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

/// <summary>
/// A business result that represents the outcome of an operation, encapsulating either successful value of type <typeparamref name="TValue"/> or failure states, along with associated error messages and additional information.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public sealed partial class Result<TValue> : IModResult<TValue, Failure>
  where TValue : notnull
{
  /// <summary>
  /// Gets if state of result instance is Ok.
  /// </summary>
  [MemberNotNullWhen(returnValue: true, nameof(Value))]
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public bool IsOk => !IsFailed;

  /// <summary>
  /// Gets if state of result instance is Failed.
  /// </summary>
  [MemberNotNullWhen(returnValue: false, nameof(Value))]
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailed => Value is null;

  /// <summary>
  /// Contains encapsulated value for an Ok <see cref="Result{TValue}"/> instance. Not null when <see cref="IsOk"/> is true.
  /// </summary>
  public TValue? Value { get; init; }

  /// <summary>
  /// Contains failure info for a failed <see cref="Result{TValue}"/> instance. Not null when <see cref="IsFailed"/> is true.
  /// </summary>
  public Failure? Failure { get; init; }

  private readonly Statements _statements =
    new(Definitions.EmptyFacts, Definitions.EmptyWarnings);

  /// <summary>
  /// Contains facts and warnings for the result.
  /// </summary>
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

  /// <summary>
  /// Creates a <see cref="Result{TValue}"/> in Ok state containing input value.
  /// </summary>
  /// <param name="value">Value that will be encapsulated in an Ok <see cref="Result{TValue}"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Ok(TValue value)
  {
    return new Result<TValue>(value);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> from another result instance whose failure property is of type <see cref="ModResults.Failure"/>, copying over Statements and any Failure information.
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
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

  /// <summary>
  /// Creates a <see cref="Result{TValue}"/> in Ok state containing input value.
  /// </summary>
  /// <param name="value">Value that will be encapsulated in an Ok <see cref="Result{TValue}"/>.</param>
  public static implicit operator Result<TValue>(TValue value)
  {
    return Ok(value);
  }

  /// <summary>
  /// Converts a <see cref="Result{TValue}"/> to a <see cref="Result"/>.
  /// </summary>
  /// <param name="resultOfTValue">Source <see cref="Result{TValue}"/>.</param>
  public static implicit operator Result(Result<TValue> resultOfTValue)
  {
    return resultOfTValue.ToResult();
  }

  public static implicit operator Result<TValue>(Result<TValue, Failure> resultOfTValueAndFailure)
  {
    return resultOfTValueAndFailure.ToResultOfTValue();
  }
}
