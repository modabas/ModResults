namespace ModResults;

//Failed initializers
public static class ResultFailureExtensions
{
  extension(Result)
  {
    #region "Error"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Error()
    {
      return Result.Create(FailureType.Error);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Error;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.Error, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Error;
      return Result.Create(
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
      return Result.Create(FailureType.Forbidden);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Forbidden;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.Forbidden, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Forbidden;
      return Result.Create(
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
      return Result.Create(FailureType.Unauthorized);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unauthorized;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.Unauthorized, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unauthorized;
      return Result.Create(
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
      return Result.Create(FailureType.Invalid);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Invalid;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.Invalid, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Invalid;
      return Result.Create(
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
      return Result.Create(FailureType.NotFound);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.NotFound;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.NotFound, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.NotFound;
      return Result.Create(
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
      return Result.Create(FailureType.Conflict);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Conflict;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.Conflict, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Conflict;
      return Result.Create(
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
      return Result.Create(FailureType.CriticalError);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.CriticalError;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.CriticalError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.CriticalError;
      return Result.Create(
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
      return Result.Create(FailureType.Unavailable);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unavailable;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.Unavailable, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unavailable;
      return Result.Create(
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
      return Result.Create(FailureType.GatewayError);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.GatewayError;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.GatewayError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.GatewayError;
      return Result.Create(
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
      return Result.Create(FailureType.RateLimited);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.RateLimited;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.RateLimited, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.RateLimited;
      return Result.Create(
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
      return Result.Create(FailureType.TimedOut);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.TimedOut;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.TimedOut, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.TimedOut;
      return Result.Create(
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
      return Result.Create(FailureType.PaymentRequired);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.PaymentRequired;
      return Result.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<Error> errors)
    {
      return Result.Create(FailureType.PaymentRequired, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.PaymentRequired;
      return Result.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion
  }

  extension<TValue>(Result<TValue>) where TValue : notnull
  {
    #region "Error"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Error()
    {
      return Result<TValue>.Create(FailureType.Error);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Error;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.Error, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Error;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.Forbidden);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Forbidden;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.Forbidden, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Forbidden;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.Unauthorized);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unauthorized;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.Unauthorized, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unauthorized;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.Invalid);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Invalid;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.Invalid, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Invalid;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.NotFound);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.NotFound;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.NotFound, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.NotFound;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.Conflict);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Conflict;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.Conflict, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Conflict;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.CriticalError);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.CriticalError;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.CriticalError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.CriticalError;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.Unavailable);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unavailable;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.Unavailable, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unavailable;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.GatewayError);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.GatewayError;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.GatewayError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.GatewayError;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.RateLimited);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.RateLimited;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.RateLimited, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.RateLimited;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.TimedOut);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.TimedOut;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.TimedOut, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.TimedOut;
      return Result<TValue>.Create(
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
      return Result<TValue>.Create(FailureType.PaymentRequired);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.PaymentRequired;
      return Result<TValue>.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<Error> errors)
    {
      return Result<TValue>.Create(FailureType.PaymentRequired, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.PaymentRequired;
      return Result<TValue>.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion
  }
}
