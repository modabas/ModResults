namespace ModResults;

public static class FailedResultExtensions
{
  extension(FailedResult result)
  {
    #region "ToResult"
    /// <summary>
    /// Converts a <see cref="FailedResult"/> to a <see cref="Result"/>, copying over Failure and Statements information.
    /// </summary>
    /// <returns></returns>
    public Result ToResult() => result;

    /// <summary>
    /// Converts a <see cref="FailedResult"/> to a <see cref="Result{TValue}"/>, copying over Failure and Statements information.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public Result<TValue> ToResult<TValue>() where TValue : notnull => result;
    #endregion

    #region "IsFailedWith"
    /// <summary>
    /// Checks if the result is failed with a specific <see cref="FailureType"/>.
    /// </summary>
    /// <param name="failureType"></param>
    /// <returns></returns>
    public bool IsFailedWith(FailureType failureType)
    {
      return result.Failure.Type == failureType;
    }

    /// <summary>
    /// Checks if the result has an <see cref="ModResults.Error"/> with the specified code.
    /// </summary>
    /// <param name="errorCode">Error code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool IsFailedWith(
      string errorCode,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      return result.HasError(errorCode, comparisonType);
    }

    /// <summary>
    /// Checks if the result has an <see cref="ModResults.Error"/> constructed from an exception of the specified type.
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public bool IsFailedWith<TException>(
      bool includeAssignableTo = false)
      where TException : Exception
    {
      return result.HasErrorWithException<TException>(includeAssignableTo);
    }

    /// <summary>
    /// Checks if the result has an <see cref="ModResults.Error"/> constructed from an exception of the specified type.
    /// </summary>
    /// <param name="exceptionType">Exception type</param>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public bool IsFailedWith(
      Type exceptionType,
      bool includeAssignableTo = false)
    {
      return result.HasErrorWithException(exceptionType, includeAssignableTo);
    }
    #endregion

    #region "Error"
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult Error()
    {
      return FailedResult.Create(FailureType.Error);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Error(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Error;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Error(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.Error, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Error"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Error(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Error;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Forbidden
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult Forbidden()
    {
      return FailedResult.Create(FailureType.Forbidden);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Forbidden(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Forbidden;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Forbidden(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.Forbidden, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Forbidden"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Forbidden(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Forbidden;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Unauthorized
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult Unauthorized()
    {
      return FailedResult.Create(FailureType.Unauthorized);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Unauthorized(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unauthorized;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Unauthorized(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.Unauthorized, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unauthorized"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Unauthorized(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unauthorized;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Invalid
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult Invalid()
    {
      return FailedResult.Create(FailureType.Invalid);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Invalid(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Invalid;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Invalid(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.Invalid, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Invalid"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Invalid(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Invalid;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region NotFound
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult NotFound()
    {
      return FailedResult.Create(FailureType.NotFound);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult NotFound(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.NotFound;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult NotFound(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.NotFound, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.NotFound"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult NotFound(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.NotFound;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Conflict
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult Conflict()
    {
      return FailedResult.Create(FailureType.Conflict);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Conflict(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Conflict;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Conflict(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.Conflict, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Conflict"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Conflict(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Conflict;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region CriticalError
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult CriticalError()
    {
      return FailedResult.Create(FailureType.CriticalError);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult CriticalError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.CriticalError;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult CriticalError(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.CriticalError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.CriticalError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult CriticalError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.CriticalError;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region Unavailable
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult Unavailable()
    {
      return FailedResult.Create(FailureType.Unavailable);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Unavailable(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.Unavailable;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Unavailable(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.Unavailable, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.Unavailable"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult Unavailable(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.Unavailable;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region GatewayError
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult GatewayError()
    {
      return FailedResult.Create(FailureType.GatewayError);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult GatewayError(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.GatewayError;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult GatewayError(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.GatewayError, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.GatewayError"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult GatewayError(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.GatewayError;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region RateLimited
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult RateLimited()
    {
      return FailedResult.Create(FailureType.RateLimited);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult RateLimited(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.RateLimited;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult RateLimited(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.RateLimited, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.RateLimited"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult RateLimited(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.RateLimited;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region TimedOut
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult TimedOut()
    {
      return FailedResult.Create(FailureType.TimedOut);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult TimedOut(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.TimedOut;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult TimedOut(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.TimedOut, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.TimedOut"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult TimedOut(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.TimedOut;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion

    #region PaymentRequired
    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <returns></returns>
    public static FailedResult PaymentRequired()
    {
      return FailedResult.Create(FailureType.PaymentRequired);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errorMessages">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult PaymentRequired(params IEnumerable<string> errorMessages)
    {
      var failureType = FailureType.PaymentRequired;
      return FailedResult.Create(
          failureType,
          errorMessages.Select(x => x.ToError(failureType)));
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="errors">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult PaymentRequired(params IEnumerable<Error> errors)
    {
      return FailedResult.Create(FailureType.PaymentRequired, errors);
    }

    /// <summary>
    /// Creates a failed <see cref="FailedResult"/> with failure type <see cref="FailureType.PaymentRequired"/>.
    /// </summary>
    /// <param name="exceptions">Used to create error collection under <see cref="Failure"/>.</param>
    /// <returns></returns>
    public static FailedResult PaymentRequired(params IEnumerable<Exception> exceptions)
    {
      var failureType = FailureType.PaymentRequired;
      return FailedResult.Create(
          failureType,
          exceptions.Select(x => x.ToError(failureType)));
    }
    #endregion
  }
}
