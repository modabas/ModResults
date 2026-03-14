namespace ModResults;

public static class FailureResultExtensions
{
  extension(FailureResult result)
  {
    #region "ToResult"
    /// <summary>
    /// Converts a <see cref="FailureResult"/> to a <see cref="Result"/>, copying over Failure and Statements information.
    /// </summary>
    /// <returns></returns>
    public Result ToResult() => result;

    /// <summary>
    /// Converts a <see cref="FailureResult"/> to a <see cref="Result{TValue}"/>, copying over Failure and Statements information.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public Result<TValue> ToResult<TValue>() where TValue : notnull => result;
    #endregion

    #region "Error"
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult Error()
    {
      return FailureResult.Create(FailureType.Error);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Error(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Error;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Error(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.Error, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Error(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Error;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Forbidden
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult Forbidden()
    {
      return FailureResult.Create(FailureType.Forbidden);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Forbidden(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Forbidden;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Forbidden(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.Forbidden, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Forbidden(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Forbidden;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Unauthorized
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult Unauthorized()
    {
      return FailureResult.Create(FailureType.Unauthorized);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Unauthorized(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unauthorized;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Unauthorized(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.Unauthorized, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Unauthorized(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unauthorized;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Invalid
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult Invalid()
    {
      return FailureResult.Create(FailureType.Invalid);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Invalid(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Invalid;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Invalid(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.Invalid, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Invalid(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Invalid;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region NotFound
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult NotFound()
    {
      return FailureResult.Create(FailureType.NotFound);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult NotFound(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.NotFound;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult NotFound(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.NotFound, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult NotFound(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.NotFound;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Conflict
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult Conflict()
    {
      return FailureResult.Create(FailureType.Conflict);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Conflict(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Conflict;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Conflict(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.Conflict, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Conflict(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Conflict;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region CriticalError
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult CriticalError()
    {
      return FailureResult.Create(FailureType.CriticalError);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult CriticalError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.CriticalError;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult CriticalError(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.CriticalError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult CriticalError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.CriticalError;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Unavailable
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult Unavailable()
    {
      return FailureResult.Create(FailureType.Unavailable);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Unavailable(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unavailable;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Unavailable(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.Unavailable, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult Unavailable(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unavailable;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region GatewayError
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult GatewayError()
    {
      return FailureResult.Create(FailureType.GatewayError);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult GatewayError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.GatewayError;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult GatewayError(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.GatewayError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult GatewayError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.GatewayError;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region RateLimited
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult RateLimited()
    {
      return FailureResult.Create(FailureType.RateLimited);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult RateLimited(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.RateLimited;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult RateLimited(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.RateLimited, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult RateLimited(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.RateLimited;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region TimedOut
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult TimedOut()
    {
      return FailureResult.Create(FailureType.TimedOut);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult TimedOut(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.TimedOut;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult TimedOut(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.TimedOut, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult TimedOut(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.TimedOut;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region PaymentRequired
    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <returns></returns>
    public static FailureResult PaymentRequired()
    {
      return FailureResult.Create(FailureType.PaymentRequired);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult PaymentRequired(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.PaymentRequired;
      return FailureResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult PaymentRequired(params IEnumerable<Error> errors)
    {
      return FailureResult.Create(FailureType.PaymentRequired, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailureResult PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.PaymentRequired;
      return FailureResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion
  }
}
