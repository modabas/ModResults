namespace ModResults;

//Failed initializers
public partial class Result
{
  #region "Error"
  public static Result Error()
  {
    return new Result(FailureType.Error);
  }

  public static Result Error(params string[] errorMessages)
  {
    var failureType = FailureType.Error;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Error(params Error[] errors)
  {
    return new Result(FailureType.Error, errors);
  }

  public static Result Error(params Exception[] exceptions)
  {
    var failureType = FailureType.Error;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Forbidden
  public static Result Forbidden()
  {
    return new Result(FailureType.Forbidden);
  }

  public static Result Forbidden(params string[] errorMessages)
  {
    var failureType = FailureType.Forbidden;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Forbidden(params Error[] errors)
  {
    return new Result(FailureType.Forbidden, errors);
  }

  public static Result Forbidden(params Exception[] exceptions)
  {
    var failureType = FailureType.Forbidden;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unauthorized
  public static Result Unauthorized()
  {
    return new Result(FailureType.Unauthorized);
  }

  public static Result Unauthorized(params string[] errorMessages)
  {
    var failureType = FailureType.Unauthorized;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Unauthorized(params Error[] errors)
  {
    return new Result(FailureType.Unauthorized, errors);
  }

  public static Result Unauthorized(params Exception[] exceptions)
  {
    var failureType = FailureType.Unauthorized;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Invalid
  public static Result Invalid()
  {
    return new Result(FailureType.Invalid);
  }

  public static Result Invalid(params string[] errorMessages)
  {
    var failureType = FailureType.Invalid;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Invalid(params Error[] errors)
  {
    return new Result(FailureType.Invalid, errors);
  }

  public static Result Invalid(params Exception[] exceptions)
  {
    var failureType = FailureType.Invalid;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region NotFound
  public static Result NotFound()
  {
    return new Result(FailureType.NotFound);
  }

  public static Result NotFound(params string[] errorMessages)
  {
    var failureType = FailureType.NotFound;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result NotFound(params Error[] errors)
  {
    return new Result(FailureType.NotFound, errors);
  }

  public static Result NotFound(params Exception[] exceptions)
  {
    var failureType = FailureType.NotFound;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Conflict
  public static Result Conflict()
  {
    return new Result(FailureType.Conflict);
  }

  public static Result Conflict(params string[] errorMessages)
  {
    var failureType = FailureType.Conflict;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Conflict(params Error[] errors)
  {
    return new Result(FailureType.Conflict, errors);
  }

  public static Result Conflict(params Exception[] exceptions)
  {
    var failureType = FailureType.Conflict;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region CriticalError
  public static Result CriticalError()
  {
    return new Result(FailureType.CriticalError);
  }

  public static Result CriticalError(params string[] errorMessages)
  {
    var failureType = FailureType.CriticalError;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result CriticalError(params Error[] errors)
  {
    return new Result(FailureType.CriticalError, errors);
  }

  public static Result CriticalError(params Exception[] exceptions)
  {
    var failureType = FailureType.CriticalError;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unavailable
  public static Result Unavailable()
  {
    return new Result(FailureType.Unavailable);
  }

  public static Result Unavailable(params string[] errorMessages)
  {
    var failureType = FailureType.Unavailable;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Unavailable(params Error[] errors)
  {
    return new Result(FailureType.Unavailable, errors);
  }

  public static Result Unavailable(params Exception[] exceptions)
  {
    var failureType = FailureType.Unavailable;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region GatewayError
  public static Result GatewayError()
  {
    return new Result(FailureType.GatewayError);
  }

  public static Result GatewayError(params string[] errorMessages)
  {
    var failureType = FailureType.GatewayError;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result GatewayError(params Error[] errors)
  {
    return new Result(FailureType.GatewayError, errors);
  }

  public static Result GatewayError(params Exception[] exceptions)
  {
    var failureType = FailureType.GatewayError;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region RateLimited
  public static Result RateLimited()
  {
    return new Result(FailureType.RateLimited);
  }

  public static Result RateLimited(params string[] errorMessages)
  {
    var failureType = FailureType.RateLimited;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result RateLimited(params Error[] errors)
  {
    return new Result(FailureType.RateLimited, errors);
  }

  public static Result RateLimited(params Exception[] exceptions)
  {
    var failureType = FailureType.RateLimited;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region TimedOut
  public static Result TimedOut()
  {
    return new Result(FailureType.TimedOut);
  }

  public static Result TimedOut(params string[] errorMessages)
  {
    var failureType = FailureType.TimedOut;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result TimedOut(params Error[] errors)
  {
    return new Result(FailureType.TimedOut, errors);
  }

  public static Result TimedOut(params Exception[] exceptions)
  {
    var failureType = FailureType.TimedOut;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion


  public static implicit operator Result(Exception exception)
  {
    return Result.CriticalError(exception);
  }
}


//Failed initializers
public partial class Result<TValue>
{
  #region "Error"
  public static Result<TValue> Error()
  {
    return new Result<TValue>(FailureType.Error);
  }

  public static Result<TValue> Error(params string[] errorMessages)
  {
    var failureType = FailureType.Error;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Error(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Error, errors);
  }

  public static Result<TValue> Error(params Exception[] exceptions)
  {
    var failureType = FailureType.Error;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Forbidden
  public static Result<TValue> Forbidden()
  {
    return new Result<TValue>(FailureType.Forbidden);
  }

  public static Result<TValue> Forbidden(params string[] errorMessages)
  {
    var failureType = FailureType.Forbidden;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Forbidden(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Forbidden, errors);
  }

  public static Result<TValue> Forbidden(params Exception[] exceptions)
  {
    var failureType = FailureType.Forbidden;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unauthorized
  public static Result<TValue> Unauthorized()
  {
    return new Result<TValue>(FailureType.Unauthorized);
  }

  public static Result<TValue> Unauthorized(params string[] errorMessages)
  {
    var failureType = FailureType.Unauthorized;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Unauthorized(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Unauthorized, errors);
  }

  public static Result<TValue> Unauthorized(params Exception[] exceptions)
  {
    var failureType = FailureType.Unauthorized;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Invalid
  public static Result<TValue> Invalid()
  {
    return new Result<TValue>(FailureType.Invalid);
  }

  public static Result<TValue> Invalid(params string[] errorMessages)
  {
    var failureType = FailureType.Invalid;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Invalid(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Invalid, errors);
  }

  public static Result<TValue> Invalid(params Exception[] exceptions)
  {
    var failureType = FailureType.Invalid;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region NotFound
  public static Result<TValue> NotFound()
  {
    return new Result<TValue>(FailureType.NotFound);
  }

  public static Result<TValue> NotFound(params string[] errorMessages)
  {
    var failureType = FailureType.NotFound;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> NotFound(params Error[] errors)
  {
    return new Result<TValue>(FailureType.NotFound, errors);
  }

  public static Result<TValue> NotFound(params Exception[] exceptions)
  {
    var failureType = FailureType.NotFound;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Conflict
  public static Result<TValue> Conflict()
  {
    return new Result<TValue>(FailureType.Conflict);
  }

  public static Result<TValue> Conflict(params string[] errorMessages)
  {
    var failureType = FailureType.Conflict;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Conflict(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Conflict, errors);
  }

  public static Result<TValue> Conflict(params Exception[] exceptions)
  {
    var failureType = FailureType.Conflict;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region CriticalError
  public static Result<TValue> CriticalError()
  {
    return new Result<TValue>(FailureType.CriticalError);
  }

  public static Result<TValue> CriticalError(params string[] errorMessages)
  {
    var failureType = FailureType.CriticalError;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> CriticalError(params Error[] errors)
  {
    return new Result<TValue>(FailureType.CriticalError, errors);
  }

  public static Result<TValue> CriticalError(params Exception[] exceptions)
  {
    var failureType = FailureType.CriticalError;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unavailable
  public static Result<TValue> Unavailable()
  {
    return new Result<TValue>(FailureType.Unavailable);
  }

  public static Result<TValue> Unavailable(params string[] errorMessages)
  {
    var failureType = FailureType.Unavailable;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Unavailable(params Error[] errors)
  {
    return new Result<TValue>(FailureType.Unavailable, errors);
  }

  public static Result<TValue> Unavailable(params Exception[] exceptions)
  {
    var failureType = FailureType.Unavailable;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region GatewayError
  public static Result<TValue> GatewayError()
  {
    return new Result<TValue>(FailureType.GatewayError);
  }

  public static Result<TValue> GatewayError(params string[] errorMessages)
  {
    var failureType = FailureType.GatewayError;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> GatewayError(params Error[] errors)
  {
    return new Result<TValue>(FailureType.GatewayError, errors);
  }

  public static Result<TValue> GatewayError(params Exception[] exceptions)
  {
    var failureType = FailureType.GatewayError;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region RateLimited
  public static Result<TValue> RateLimited()
  {
    return new Result<TValue>(FailureType.RateLimited);
  }

  public static Result<TValue> RateLimited(params string[] errorMessages)
  {
    var failureType = FailureType.RateLimited;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> RateLimited(params Error[] errors)
  {
    return new Result<TValue>(FailureType.RateLimited, errors);
  }

  public static Result<TValue> RateLimited(params Exception[] exceptions)
  {
    var failureType = FailureType.RateLimited;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region TimedOut
  public static Result<TValue> TimedOut()
  {
    return new Result<TValue>(FailureType.TimedOut);
  }

  public static Result<TValue> TimedOut(params string[] errorMessages)
  {
    var failureType = FailureType.TimedOut;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> TimedOut(params Error[] errors)
  {
    return new Result<TValue>(FailureType.TimedOut, errors);
  }

  public static Result<TValue> TimedOut(params Exception[] exceptions)
  {
    var failureType = FailureType.TimedOut;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  public static implicit operator Result<TValue>(Exception exception)
  {
    return Result<TValue>.CriticalError(exception);
  }
}
