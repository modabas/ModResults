namespace ModResults;

/// <summary>
/// A business result that represents the outcome of an operation, encapsulating either success or failure states, along with associated error messages and additional information.
/// </summary>
public sealed class Result : BaseBusinessResult<Result>
{
  private Result()
  {
    IsOk = true;
    Failure = null;
  }

  private Result(FailureType failureType, IReadOnlyList<Error>? errors)
  {
    IsOk = false;
    Failure = new Failure(failureType, errors);
  }

  private Result(FailureType failureType, IEnumerable<Error> errors)
  {
    IsOk = false;
    Failure = Failure.Create(failureType, errors);
  }

  private Result(FailureType failureType)
  {
    IsOk = false;
    Failure = Failure.Create(failureType);
  }

  internal static Result Create(FailureType failureType, IEnumerable<Error> errors)
  {
    return new(failureType, errors);
  }

  internal static Result Create(FailureType failureType)
  {
    return new(failureType);
  }

  /// <summary>
  /// This constructor is intended as single public constructor to be used from Json deserialization.
  /// Use provided static methods to create instances of <see cref="Result"/>.
  /// </summary>
  /// <param name="isOk"></param>
  /// <param name="failure"></param>
  /// <param name="statements"></param>
  /// <exception cref="ArgumentNullException"></exception>
  public Result(
    bool isOk,
    Failure? failure,
    Statements? statements)
  {
    //by design Failure cannot be null if isOk is false
    if (!isOk && failure is null)
    {
      throw new ArgumentNullException(nameof(failure));
    }
    IsOk = isOk;
    Failure = failure;
    Statements = statements!;
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
  /// Creates a failed <see cref="Result"/> from another result instance whose failure property is of type <see cref="ModResults.Failure"/>.
  /// If source result has no Failure (in Ok state), the returned FailureResult will have a Failure with type set to Unspecified and no errors.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="wrapSourceProperties">If <see langword="true"/>, wraps Failure and Statement objects of the source result; otherwise, copies over Statement and any Failure information from source.</param>
  /// <returns></returns>
  public static Result Fail(BaseResult<Failure> result, bool wrapSourceProperties = true)
  {
    if (wrapSourceProperties)
    {
      return new(
        false,
        result.Failure is null ? Failure.Create(FailureType.Unspecified) : result.Failure,
        result.PeekStatements());
    }
    else
    {
      if (result.Failure is null)
      {
        return new Result(FailureType.Unspecified)
          .WithStatementsFrom(result);
      }
      if (result.Failure.HasErrors())
      {
        return new Result(result.Failure.Type, result.Failure.Errors)
          .WithStatementsFrom(result);
      }
      return new Result(result.Failure.Type, null)
        .WithStatementsFrom(result);
    }
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/> containing an error constructed from specified exception.
  /// </summary>
  /// <param name="exception">The <see cref="Exception"/> that will used to construct an error instance from.</param>
  public static implicit operator Result(Exception exception)
  {
    return Result.CriticalError(exception);
  }

  /// <summary>
  /// Creates a <see cref="Result"/> in Failed state with input failure type.
  /// </summary>
  /// <param name="failureType">Failure type that will be encapsulated in a Failed <see cref="Result"/>.</param>
  public static implicit operator Result(FailureType failureType)
  {
    return new Result(failureType);
  }

  /// <summary>
  /// Creates a <see cref="Result"/> in Failed state from input <see cref="FailureResult"/> .
  /// </summary>
  /// <param name="failedResult"><see cref="FailureResult"/> instance that will be converted to a Failed <see cref="Result"/>.</param>
  public static implicit operator Result(FailureResult failedResult)
  {
    return failedResult.AsResult();
  }
}

/// <summary>
/// A business result that represents the outcome of an operation, encapsulating either successful value of type <typeparamref name="TValue"/> or failure states, along with associated error messages and additional information.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public sealed class Result<TValue> : BaseBusinessResult<Result<TValue>, TValue>
  where TValue : notnull
{
  private Result(TValue value)
  {
    IsOk = true;
    Value = value;
  }

  private Result(FailureType failureType, IReadOnlyList<Error>? errors)
  {
    IsOk = false;
    Failure = new Failure(failureType, errors);
  }

  private Result(FailureType failureType, IEnumerable<Error> errors)
  {
    IsOk = false;
    Failure = Failure.Create(failureType, errors);
  }

  private Result(FailureType failureType)
  {
    IsOk = false;
    Failure = Failure.Create(failureType);
  }

  internal static Result<TValue> Create(FailureType failureType, IEnumerable<Error> errors)
  {
    return new(failureType, errors);
  }

  internal static Result<TValue> Create(FailureType failureType)
  {
    return new(failureType);
  }

  /// <summary>
  /// This constructor is intended as single public constructor to be used from Json deserialization.
  /// Use provided static methods to create instances of <see cref="Result{TValue}"/>.
  /// </summary>
  /// <param name="isOk"></param>
  /// <param name="value"></param>
  /// <param name="failure"></param>
  /// <param name="statements"></param>
  /// <exception cref="ArgumentNullException"></exception>
  public Result(
    bool isOk,
    TValue? value,
    Failure? failure,
    Statements? statements)
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
    Statements = statements!;
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
  /// Creates a failed <see cref="Result{TValue}"/> from another result instance whose failure property is of type <see cref="ModResults.Failure"/>.
  /// If source result has no Failure (in Ok state), the returned FailureResult will have a Failure with type set to Unspecified and no errors.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="wrapSourceProperties">If <see langword="true"/>, wraps Failure and Statement objects of the source result; otherwise, copies over Statement and any Failure information from source.</param>
  /// <returns></returns>
  public static Result<TValue> Fail(BaseResult<Failure> result, bool wrapSourceProperties = true)
  {
    if (wrapSourceProperties)
    {
      return new(
        false,
        default,
        result.Failure is null ? Failure.Create(FailureType.Unspecified) : result.Failure,
        result.PeekStatements());
    }
    else
    {
      if (result.Failure is null)
      {
        return new Result<TValue>(FailureType.Unspecified)
          .WithStatementsFrom(result);
      }
      if (result.Failure.HasErrors())
      {
        return new Result<TValue>(result.Failure.Type, result.Failure.Errors)
          .WithStatementsFrom(result);
      }
      return new Result<TValue>(result.Failure.Type, null)
        .WithStatementsFrom(result);
    }
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
    return resultOfTValue.AsResult();
  }

  public static implicit operator Result<TValue>(Result<TValue, Failure> resultOfTValueAndFailure)
  {
    return resultOfTValueAndFailure.AsResultOfTValue();
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/> containing an error constructed from specified exception.
  /// </summary>
  /// <param name="exception">The <see cref="Exception"/> that will used to construct an error instance from.</param>
  public static implicit operator Result<TValue>(Exception exception)
  {
    return Result<TValue>.CriticalError(exception);
  }

  /// <summary>
  /// Creates a <see cref="Result{TValue}"/> in Failed state with input failure type.
  /// </summary>
  /// <param name="failureType">Failure type that will be encapsulated in a Failed <see cref="Result{TValue}"/>.</param>
  public static implicit operator Result<TValue>(FailureType failureType)
  {
    return new Result<TValue>(failureType);
  }

  /// <summary>
  /// Creates a <see cref="Result{TValue}"/> in Failed state from input <see cref="FailureResult"/>.
  /// </summary>
  /// <param name="failedResult"><see cref="FailureResult"/> instance that will be converted to a Failed <see cref="Result{TValue}"/>.</param>
  public static implicit operator Result<TValue>(FailureResult failedResult)
  {
    return failedResult.AsResult<TValue>();
  }
}
