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
      return FailedResult.Error();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Error(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<Error> errors)
    {
      return FailedResult.Error(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Error(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Error(exceptions);
    }
    #endregion

    #region "Forbidden"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Forbidden()
    {
      return FailedResult.Forbidden();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Forbidden(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<Error> errors)
    {
      return FailedResult.Forbidden(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Forbidden(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Forbidden(exceptions);
    }
    #endregion

    #region "Unauthorized"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Unauthorized()
    {
      return FailedResult.Unauthorized();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Unauthorized(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<Error> errors)
    {
      return FailedResult.Unauthorized(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unauthorized(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Unauthorized(exceptions);
    }
    #endregion

    #region "Invalid"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Invalid()
    {
      return FailedResult.Invalid();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Invalid(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<Error> errors)
    {
      return FailedResult.Invalid(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Invalid(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Invalid(exceptions);
    }
    #endregion

    #region "NotFound"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <returns></returns>
    public static Result NotFound()
    {
      return FailedResult.NotFound();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<string> errorMessages)
    {
      return FailedResult.NotFound(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<Error> errors)
    {
      return FailedResult.NotFound(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result NotFound(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.NotFound(exceptions);
    }
    #endregion

    #region "Conflict"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Conflict()
    {
      return FailedResult.Conflict();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Conflict(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<Error> errors)
    {
      return FailedResult.Conflict(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Conflict(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Conflict(exceptions);
    }
    #endregion

    #region "CriticalError"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result CriticalError()
    {
      return FailedResult.CriticalError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<string> errorMessages)
    {
      return FailedResult.CriticalError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<Error> errors)
    {
      return FailedResult.CriticalError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result CriticalError(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.CriticalError(exceptions);
    }
    #endregion

    #region "Unavailable"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <returns></returns>
    public static Result Unavailable()
    {
      return FailedResult.Unavailable();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Unavailable(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<Error> errors)
    {
      return FailedResult.Unavailable(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result Unavailable(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Unavailable(exceptions);
    }
    #endregion

    #region "GatewayError"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result GatewayError()
    {
      return FailedResult.GatewayError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<string> errorMessages)
    {
      return FailedResult.GatewayError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<Error> errors)
    {
      return FailedResult.GatewayError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result GatewayError(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.GatewayError(exceptions);
    }
    #endregion

    #region "RateLimited"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <returns></returns>
    public static Result RateLimited()
    {
      return FailedResult.RateLimited();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<string> errorMessages)
    {
      return FailedResult.RateLimited(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<Error> errors)
    {
      return FailedResult.RateLimited(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result RateLimited(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.RateLimited(exceptions);
    }
    #endregion

    #region "TimedOut"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <returns></returns>
    public static Result TimedOut()
    {
      return FailedResult.TimedOut();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<string> errorMessages)
    {
      return FailedResult.TimedOut(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<Error> errors)
    {
      return FailedResult.TimedOut(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result TimedOut(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.TimedOut(exceptions);
    }
    #endregion

    #region "PaymentRequired"
    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <returns></returns>
    public static Result PaymentRequired()
    {
      return FailedResult.PaymentRequired();
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<string> errorMessages)
    {
      return FailedResult.PaymentRequired(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<Error> errors)
    {
      return FailedResult.PaymentRequired(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.PaymentRequired(exceptions);
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
      return FailedResult.Error();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Error(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<Error> errors)
    {
      return FailedResult.Error(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Error(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Error(exceptions);
    }
    #endregion

    #region "Forbidden"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Forbidden()
    {
      return FailedResult.Forbidden();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Forbidden(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<Error> errors)
    {
      return FailedResult.Forbidden(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Forbidden(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Forbidden(exceptions);
    }
    #endregion

    #region "Unauthorized"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Unauthorized()
    {
      return FailedResult.Unauthorized();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Unauthorized(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<Error> errors)
    {
      return FailedResult.Unauthorized(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unauthorized(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Unauthorized(exceptions);
    }
    #endregion

    #region "Invalid"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Invalid()
    {
      return FailedResult.Invalid();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Invalid(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<Error> errors)
    {
      return FailedResult.Invalid(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Invalid(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Invalid(exceptions);
    }
    #endregion

    #region "NotFound"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> NotFound()
    {
      return FailedResult.NotFound();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<string> errorMessages)
    {
      return FailedResult.NotFound(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<Error> errors)
    {
      return FailedResult.NotFound(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> NotFound(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.NotFound(exceptions);
    }
    #endregion

    #region "Conflict"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Conflict()
    {
      return FailedResult.Conflict();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Conflict(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<Error> errors)
    {
      return FailedResult.Conflict(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Conflict(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Conflict(exceptions);
    }
    #endregion

    #region "CriticalError"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> CriticalError()
    {
      return FailedResult.CriticalError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<string> errorMessages)
    {
      return FailedResult.CriticalError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<Error> errors)
    {
      return FailedResult.CriticalError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> CriticalError(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.CriticalError(exceptions);
    }
    #endregion

    #region "Unavailable"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> Unavailable()
    {
      return FailedResult.Unavailable();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<string> errorMessages)
    {
      return FailedResult.Unavailable(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<Error> errors)
    {
      return FailedResult.Unavailable(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> Unavailable(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.Unavailable(exceptions);
    }
    #endregion

    #region "GatewayError"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> GatewayError()
    {
      return FailedResult.GatewayError();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<string> errorMessages)
    {
      return FailedResult.GatewayError(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<Error> errors)
    {
      return FailedResult.GatewayError(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> GatewayError(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.GatewayError(exceptions);
    }
    #endregion

    #region "RateLimited"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> RateLimited()
    {
      return FailedResult.RateLimited();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<string> errorMessages)
    {
      return FailedResult.RateLimited(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<Error> errors)
    {
      return FailedResult.RateLimited(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> RateLimited(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.RateLimited(exceptions);
    }
    #endregion

    #region "TimedOut"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> TimedOut()
    {
      return FailedResult.TimedOut();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<string> errorMessages)
    {
      return FailedResult.TimedOut(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<Error> errors)
    {
      return FailedResult.TimedOut(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> TimedOut(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.TimedOut(exceptions);
    }
    #endregion

    #region "PaymentRequired"
    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired()
    {
      return FailedResult.PaymentRequired();
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<string> errorMessages)
    {
      return FailedResult.PaymentRequired(errorMessages);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<Error> errors)
    {
      return FailedResult.PaymentRequired(errors);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static Result<TValue> PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      return FailedResult.PaymentRequired(exceptions);
    }
    #endregion
  }
}
