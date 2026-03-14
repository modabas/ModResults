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
      return FailureResult.Error();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Error(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<Error> errors)
    {
      return FailureResult.Error(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Error(exceptions);
    }
    #endregion

    #region "Forbidden"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Forbidden()
    {
      return FailureResult.Forbidden();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Forbidden(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<Error> errors)
    {
      return FailureResult.Forbidden(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Forbidden(exceptions);
    }
    #endregion

    #region "Unauthorized"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Unauthorized()
    {
      return FailureResult.Unauthorized();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Unauthorized(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<Error> errors)
    {
      return FailureResult.Unauthorized(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Unauthorized(exceptions);
    }
    #endregion

    #region "Invalid"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Invalid()
    {
      return FailureResult.Invalid();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Invalid(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<Error> errors)
    {
      return FailureResult.Invalid(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Invalid(exceptions);
    }
    #endregion

    #region "NotFound"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <returns></returns>
    public static Result NotFound()
    {
      return FailureResult.NotFound();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<string> errorMessages)
    {
      return FailureResult.NotFound(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<Error> errors)
    {
      return FailureResult.NotFound(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.NotFound(exceptions);
    }
    #endregion

    #region "Conflict"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Conflict()
    {
      return FailureResult.Conflict();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Conflict(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<Error> errors)
    {
      return FailureResult.Conflict(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Conflict(exceptions);
    }
    #endregion

    #region "CriticalError"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result CriticalError()
    {
      return FailureResult.CriticalError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<string> errorMessages)
    {
      return FailureResult.CriticalError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<Error> errors)
    {
      return FailureResult.CriticalError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.CriticalError(exceptions);
    }
    #endregion

    #region "Unavailable"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Unavailable()
    {
      return FailureResult.Unavailable();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Unavailable(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<Error> errors)
    {
      return FailureResult.Unavailable(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Unavailable(exceptions);
    }
    #endregion

    #region "GatewayError"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result GatewayError()
    {
      return FailureResult.GatewayError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<string> errorMessages)
    {
      return FailureResult.GatewayError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<Error> errors)
    {
      return FailureResult.GatewayError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.GatewayError(exceptions);
    }
    #endregion

    #region "RateLimited"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <returns></returns>
    public static Result RateLimited()
    {
      return FailureResult.RateLimited();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<string> errorMessages)
    {
      return FailureResult.RateLimited(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<Error> errors)
    {
      return FailureResult.RateLimited(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.RateLimited(exceptions);
    }
    #endregion

    #region "TimedOut"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <returns></returns>
    public static Result TimedOut()
    {
      return FailureResult.TimedOut();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<string> errorMessages)
    {
      return FailureResult.TimedOut(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<Error> errors)
    {
      return FailureResult.TimedOut(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.TimedOut(exceptions);
    }
    #endregion

    #region "PaymentRequired"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <returns></returns>
    public static Result PaymentRequired()
    {
      return FailureResult.PaymentRequired();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<string> errorMessages)
    {
      return FailureResult.PaymentRequired(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<Error> errors)
    {
      return FailureResult.PaymentRequired(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.PaymentRequired(exceptions);
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
      return FailureResult.Error();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Error(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<Error> errors)
    {
      return FailureResult.Error(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Error(exceptions);
    }
    #endregion

    #region "Forbidden"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Forbidden()
    {
      return FailureResult.Forbidden();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Forbidden(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<Error> errors)
    {
      return FailureResult.Forbidden(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Forbidden(exceptions);
    }
    #endregion

    #region "Unauthorized"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Unauthorized()
    {
      return FailureResult.Unauthorized();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Unauthorized(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<Error> errors)
    {
      return FailureResult.Unauthorized(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Unauthorized(exceptions);
    }
    #endregion

    #region "Invalid"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Invalid()
    {
      return FailureResult.Invalid();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Invalid(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<Error> errors)
    {
      return FailureResult.Invalid(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Invalid(exceptions);
    }
    #endregion

    #region "NotFound"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> NotFound()
    {
      return FailureResult.NotFound();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<string> errorMessages)
    {
      return FailureResult.NotFound(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<Error> errors)
    {
      return FailureResult.NotFound(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.NotFound(exceptions);
    }
    #endregion

    #region "Conflict"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Conflict()
    {
      return FailureResult.Conflict();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Conflict(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<Error> errors)
    {
      return FailureResult.Conflict(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Conflict(exceptions);
    }
    #endregion

    #region "CriticalError"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> CriticalError()
    {
      return FailureResult.CriticalError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<string> errorMessages)
    {
      return FailureResult.CriticalError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<Error> errors)
    {
      return FailureResult.CriticalError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.CriticalError(exceptions);
    }
    #endregion

    #region "Unavailable"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Unavailable()
    {
      return FailureResult.Unavailable();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<string> errorMessages)
    {
      return FailureResult.Unavailable(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<Error> errors)
    {
      return FailureResult.Unavailable(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.Unavailable(exceptions);
    }
    #endregion

    #region "GatewayError"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> GatewayError()
    {
      return FailureResult.GatewayError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<string> errorMessages)
    {
      return FailureResult.GatewayError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<Error> errors)
    {
      return FailureResult.GatewayError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.GatewayError(exceptions);
    }
    #endregion

    #region "RateLimited"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> RateLimited()
    {
      return FailureResult.RateLimited();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<string> errorMessages)
    {
      return FailureResult.RateLimited(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<Error> errors)
    {
      return FailureResult.RateLimited(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.RateLimited(exceptions);
    }
    #endregion

    #region "TimedOut"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> TimedOut()
    {
      return FailureResult.TimedOut();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<string> errorMessages)
    {
      return FailureResult.TimedOut(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<Error> errors)
    {
      return FailureResult.TimedOut(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.TimedOut(exceptions);
    }
    #endregion

    #region "PaymentRequired"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired()
    {
      return FailureResult.PaymentRequired();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<string> errorMessages)
    {
      return FailureResult.PaymentRequired(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<Error> errors)
    {
      return FailureResult.PaymentRequired(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      return FailureResult.PaymentRequired(exceptions);
    }
    #endregion
  }
}
