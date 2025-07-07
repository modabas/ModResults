namespace ModResults;

//Failed initializers
public partial class Result
{
  #region "Error"
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <returns></returns>
  public static Result Error()
  {
    return new Result(FailureType.Error);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Error(params string[] errorMessages)
  {
    var failureType = FailureType.Error;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Error(params Error[] errors)
  {
    return new Result(FailureType.Error, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Error(params Exception[] exceptions)
  {
    var failureType = FailureType.Error;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Forbidden
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <returns></returns>
  public static Result Forbidden()
  {
    return new Result(FailureType.Forbidden);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Forbidden(params string[] errorMessages)
  {
    var failureType = FailureType.Forbidden;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Forbidden(params Error[] errors)
  {
    return new Result(FailureType.Forbidden, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Forbidden(params Exception[] exceptions)
  {
    var failureType = FailureType.Forbidden;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unauthorized
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <returns></returns>
  public static Result Unauthorized()
  {
    return new Result(FailureType.Unauthorized);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Unauthorized(params string[] errorMessages)
  {
    var failureType = FailureType.Unauthorized;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Unauthorized(params Error[] errors)
  {
    return new Result(FailureType.Unauthorized, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Unauthorized(params Exception[] exceptions)
  {
    var failureType = FailureType.Unauthorized;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Invalid
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <returns></returns>
  public static Result Invalid()
  {
    return new Result(FailureType.Invalid);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Invalid(params string[] errorMessages)
  {
    var failureType = FailureType.Invalid;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Invalid(params Error[] errors)
  {
    return new Result(FailureType.Invalid, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Invalid(params Exception[] exceptions)
  {
    var failureType = FailureType.Invalid;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region NotFound
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <returns></returns>
  public static Result NotFound()
  {
    return new Result(FailureType.NotFound);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result NotFound(params string[] errorMessages)
  {
    var failureType = FailureType.NotFound;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result NotFound(params Error[] errors)
  {
    return new Result(FailureType.NotFound, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result NotFound(params Exception[] exceptions)
  {
    var failureType = FailureType.NotFound;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Conflict
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <returns></returns>
  public static Result Conflict()
  {
    return new Result(FailureType.Conflict);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Conflict(params string[] errorMessages)
  {
    var failureType = FailureType.Conflict;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Conflict(params Error[] errors)
  {
    return new Result(FailureType.Conflict, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Conflict(params Exception[] exceptions)
  {
    var failureType = FailureType.Conflict;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region CriticalError
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <returns></returns>
  public static Result CriticalError()
  {
    return new Result(FailureType.CriticalError);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result CriticalError(params string[] errorMessages)
  {
    var failureType = FailureType.CriticalError;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result CriticalError(params Error[] errors)
  {
    return new Result(FailureType.CriticalError, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result CriticalError(params Exception[] exceptions)
  {
    var failureType = FailureType.CriticalError;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unavailable
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <returns></returns>
  public static Result Unavailable()
  {
    return new Result(FailureType.Unavailable);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Unavailable(params string[] errorMessages)
  {
    var failureType = FailureType.Unavailable;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Unavailable(params Error[] errors)
  {
    return new Result(FailureType.Unavailable, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result Unavailable(params Exception[] exceptions)
  {
    var failureType = FailureType.Unavailable;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region GatewayError
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <returns></returns>
  public static Result GatewayError()
  {
    return new Result(FailureType.GatewayError);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result GatewayError(params string[] errorMessages)
  {
    var failureType = FailureType.GatewayError;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result GatewayError(params Error[] errors)
  {
    return new Result(FailureType.GatewayError, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result GatewayError(params Exception[] exceptions)
  {
    var failureType = FailureType.GatewayError;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region RateLimited
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <returns></returns>
  public static Result RateLimited()
  {
    return new Result(FailureType.RateLimited);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result RateLimited(params string[] errorMessages)
  {
    var failureType = FailureType.RateLimited;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result RateLimited(params Error[] errors)
  {
    return new Result(FailureType.RateLimited, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result RateLimited(params Exception[] exceptions)
  {
    var failureType = FailureType.RateLimited;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region TimedOut
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <returns></returns>
  public static Result TimedOut()
  {
    return new Result(FailureType.TimedOut);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result TimedOut(params string[] errorMessages)
  {
    var failureType = FailureType.TimedOut;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result TimedOut(params Error[] errors)
  {
    return new Result(FailureType.TimedOut, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result TimedOut(params Exception[] exceptions)
  {
    var failureType = FailureType.TimedOut;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region PaymentRequired
  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <returns></returns>
  public static Result PaymentRequired()
  {
    return new Result(FailureType.PaymentRequired);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result PaymentRequired(params string[] errorMessages)
  {
    var failureType = FailureType.PaymentRequired;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result PaymentRequired(params Error[] errors)
  {
    return new Result(FailureType.PaymentRequired, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result PaymentRequired(params Exception[] exceptions)
  {
    var failureType = FailureType.PaymentRequired;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

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
}


//Failed initializers
public partial class Result<TValue>
{
  #region "Error"
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> Error()
  {
    return new Result<TValue>(FailureType.Error);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Error(params string[] errorMessages)
  {
    var failureType = FailureType.Error;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Error(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Error, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Error(params Exception[] exceptions)
  {
    var failureType = FailureType.Error;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Forbidden
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> Forbidden()
  {
    return new Result<TValue>(FailureType.Forbidden);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Forbidden(params string[] errorMessages)
  {
    var failureType = FailureType.Forbidden;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Forbidden(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Forbidden, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Forbidden(params Exception[] exceptions)
  {
    var failureType = FailureType.Forbidden;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unauthorized
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> Unauthorized()
  {
    return new Result<TValue>(FailureType.Unauthorized);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Unauthorized(params string[] errorMessages)
  {
    var failureType = FailureType.Unauthorized;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Unauthorized(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Unauthorized, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Unauthorized(params Exception[] exceptions)
  {
    var failureType = FailureType.Unauthorized;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Invalid
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> Invalid()
  {
    return new Result<TValue>(FailureType.Invalid);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Invalid(params string[] errorMessages)
  {
    var failureType = FailureType.Invalid;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Invalid(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Invalid, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Invalid(params Exception[] exceptions)
  {
    var failureType = FailureType.Invalid;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region NotFound
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> NotFound()
  {
    return new Result<TValue>(FailureType.NotFound);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> NotFound(params string[] errorMessages)
  {
    var failureType = FailureType.NotFound;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> NotFound(params Error[] errors)
  {
    return new Result<TValue>(FailureType.NotFound, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> NotFound(params Exception[] exceptions)
  {
    var failureType = FailureType.NotFound;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Conflict
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> Conflict()
  {
    return new Result<TValue>(FailureType.Conflict);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Conflict(params string[] errorMessages)
  {
    var failureType = FailureType.Conflict;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Conflict(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Conflict, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Conflict(params Exception[] exceptions)
  {
    var failureType = FailureType.Conflict;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region CriticalError
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> CriticalError()
  {
    return new Result<TValue>(FailureType.CriticalError);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> CriticalError(params string[] errorMessages)
  {
    var failureType = FailureType.CriticalError;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> CriticalError(params Error[] errors)
  {
    return new Result<TValue>(FailureType.CriticalError, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> CriticalError(params Exception[] exceptions)
  {
    var failureType = FailureType.CriticalError;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unavailable
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> Unavailable()
  {
    return new Result<TValue>(FailureType.Unavailable);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Unavailable(params string[] errorMessages)
  {
    var failureType = FailureType.Unavailable;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Unavailable(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Unavailable, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> Unavailable(params Exception[] exceptions)
  {
    var failureType = FailureType.Unavailable;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region GatewayError
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> GatewayError()
  {
    return new Result<TValue>(FailureType.GatewayError);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> GatewayError(params string[] errorMessages)
  {
    var failureType = FailureType.GatewayError;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> GatewayError(params Error[] errors)
  {
    return new Result<TValue>(FailureType.GatewayError, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> GatewayError(params Exception[] exceptions)
  {
    var failureType = FailureType.GatewayError;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region RateLimited
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> RateLimited()
  {
    return new Result<TValue>(FailureType.RateLimited);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> RateLimited(params string[] errorMessages)
  {
    var failureType = FailureType.RateLimited;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> RateLimited(params Error[] errors)
  {
    return new Result<TValue>(FailureType.RateLimited, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> RateLimited(params Exception[] exceptions)
  {
    var failureType = FailureType.RateLimited;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region TimedOut
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> TimedOut()
  {
    return new Result<TValue>(FailureType.TimedOut);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> TimedOut(params string[] errorMessages)
  {
    var failureType = FailureType.TimedOut;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> TimedOut(params Error[] errors)
  {
    return new Result<TValue>(FailureType.TimedOut, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> TimedOut(params Exception[] exceptions)
  {
    var failureType = FailureType.TimedOut;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region PaymentRequired
  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <returns></returns>
  public static Result<TValue> PaymentRequired()
  {
    return new Result<TValue>(FailureType.PaymentRequired);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> PaymentRequired(params string[] errorMessages)
  {
    var failureType = FailureType.PaymentRequired;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> PaymentRequired(params Error[] errors)
  {
    return new Result<TValue>(FailureType.PaymentRequired, errors);
  }

  /// <summary>
  /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
  /// </summary>
  /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
  /// <returns></returns>
  public static Result<TValue> PaymentRequired(params Exception[] exceptions)
  {
    var failureType = FailureType.PaymentRequired;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

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
}
