namespace ModResults;

//Failed initializers
public partial class Result
{
  #region "Error"
  public static Result Error()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Error);
      }
    After:
        return new Result(FailureType.Error);
      }
    */
    return new Result(ModResults.FailureType.Error);
  }

  public static Result Error(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Error;
        return new Result(
    After:
        var failureType = FailureType.Error;
        return new Result(
    */
    var failureType = ModResults.FailureType.Error;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Error(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Error, errors);
      }
    After:
        return new Result(FailureType.Error, errors);
      }
    */
    return new Result(ModResults.FailureType.Error, errors);
  }

  public static Result Error(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Error;
        return new Result(
    After:
        var failureType = FailureType.Error;
        return new Result(
    */
    var failureType = ModResults.FailureType.Error;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Forbidden
  public static Result Forbidden()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Forbidden);
      }
    After:
        return new Result(FailureType.Forbidden);
      }
    */
    return new Result(ModResults.FailureType.Forbidden);
  }

  public static Result Forbidden(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Forbidden;
        return new Result(
    After:
        var failureType = FailureType.Forbidden;
        return new Result(
    */
    var failureType = ModResults.FailureType.Forbidden;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Forbidden(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Forbidden, errors);
      }
    After:
        return new Result(FailureType.Forbidden, errors);
      }
    */
    return new Result(ModResults.FailureType.Forbidden, errors);
  }

  public static Result Forbidden(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Forbidden;
        return new Result(
    After:
        var failureType = FailureType.Forbidden;
        return new Result(
    */
    var failureType = ModResults.FailureType.Forbidden;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unauthorized
  public static Result Unauthorized()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Unauthorized);
      }
    After:
        return new Result(FailureType.Unauthorized);
      }
    */
    return new Result(ModResults.FailureType.Unauthorized);
  }

  public static Result Unauthorized(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unauthorized;
        return new Result(
    After:
        var failureType = FailureType.Unauthorized;
        return new Result(
    */
    var failureType = ModResults.FailureType.Unauthorized;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Unauthorized(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Unauthorized, errors);
      }
    After:
        return new Result(FailureType.Unauthorized, errors);
      }
    */
    return new Result(ModResults.FailureType.Unauthorized, errors);
  }

  public static Result Unauthorized(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unauthorized;
        return new Result(
    After:
        var failureType = FailureType.Unauthorized;
        return new Result(
    */
    var failureType = ModResults.FailureType.Unauthorized;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Invalid
  public static Result Invalid()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Invalid);
      }
    After:
        return new Result(FailureType.Invalid);
      }
    */
    return new Result(ModResults.FailureType.Invalid);
  }

  public static Result Invalid(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Invalid;
        return new Result(
    After:
        var failureType = FailureType.Invalid;
        return new Result(
    */
    var failureType = ModResults.FailureType.Invalid;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Invalid(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Invalid, errors);
      }
    After:
        return new Result(FailureType.Invalid, errors);
      }
    */
    return new Result(ModResults.FailureType.Invalid, errors);
  }

  public static Result Invalid(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Invalid;
        return new Result(
    After:
        var failureType = FailureType.Invalid;
        return new Result(
    */
    var failureType = ModResults.FailureType.Invalid;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region NotFound
  public static Result NotFound()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.NotFound);
      }
    After:
        return new Result(FailureType.NotFound);
      }
    */
    return new Result(ModResults.FailureType.NotFound);
  }

  public static Result NotFound(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.NotFound;
        return new Result(
    After:
        var failureType = FailureType.NotFound;
        return new Result(
    */
    var failureType = ModResults.FailureType.NotFound;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result NotFound(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.NotFound, errors);
      }
    After:
        return new Result(FailureType.NotFound, errors);
      }
    */
    return new Result(ModResults.FailureType.NotFound, errors);
  }

  public static Result NotFound(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.NotFound;
        return new Result(
    After:
        var failureType = FailureType.NotFound;
        return new Result(
    */
    var failureType = ModResults.FailureType.NotFound;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Conflict
  public static Result Conflict()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Conflict);
      }
    After:
        return new Result(FailureType.Conflict);
      }
    */
    return new Result(ModResults.FailureType.Conflict);
  }

  public static Result Conflict(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Conflict;
        return new Result(
    After:
        var failureType = FailureType.Conflict;
        return new Result(
    */
    var failureType = ModResults.FailureType.Conflict;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Conflict(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Conflict, errors);
      }
    After:
        return new Result(FailureType.Conflict, errors);
      }
    */
    return new Result(ModResults.FailureType.Conflict, errors);
  }

  public static Result Conflict(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Conflict;
        return new Result(
    After:
        var failureType = FailureType.Conflict;
        return new Result(
    */
    var failureType = ModResults.FailureType.Conflict;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region CriticalError
  public static Result CriticalError()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.CriticalError);
      }
    After:
        return new Result(FailureType.CriticalError);
      }
    */
    return new Result(ModResults.FailureType.CriticalError);
  }

  public static Result CriticalError(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.CriticalError;
        return new Result(
    After:
        var failureType = FailureType.CriticalError;
        return new Result(
    */
    var failureType = ModResults.FailureType.CriticalError;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result CriticalError(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.CriticalError, errors);
      }
    After:
        return new Result(FailureType.CriticalError, errors);
      }
    */
    return new Result(ModResults.FailureType.CriticalError, errors);
  }

  public static Result CriticalError(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.CriticalError;
        return new Result(
    After:
        var failureType = FailureType.CriticalError;
        return new Result(
    */
    var failureType = ModResults.FailureType.CriticalError;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unavailable
  public static Result Unavailable()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Unavailable);
      }
    After:
        return new Result(FailureType.Unavailable);
      }
    */
    return new Result(ModResults.FailureType.Unavailable);
  }

  public static Result Unavailable(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unavailable;
        return new Result(
    After:
        var failureType = FailureType.Unavailable;
        return new Result(
    */
    var failureType = ModResults.FailureType.Unavailable;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result Unavailable(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.Unavailable, errors);
      }
    After:
        return new Result(FailureType.Unavailable, errors);
      }
    */
    return new Result(ModResults.FailureType.Unavailable, errors);
  }

  public static Result Unavailable(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unavailable;
        return new Result(
    After:
        var failureType = FailureType.Unavailable;
        return new Result(
    */
    var failureType = ModResults.FailureType.Unavailable;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region GatewayError
  public static Result GatewayError()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.GatewayError);
      }
    After:
        return new Result(FailureType.GatewayError);
      }
    */
    return new Result(ModResults.FailureType.GatewayError);
  }

  public static Result GatewayError(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.GatewayError;
        return new Result(
    After:
        var failureType = FailureType.GatewayError;
        return new Result(
    */
    var failureType = ModResults.FailureType.GatewayError;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result GatewayError(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.GatewayError, errors);
      }
    After:
        return new Result(FailureType.GatewayError, errors);
      }
    */
    return new Result(ModResults.FailureType.GatewayError, errors);
  }

  public static Result GatewayError(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.GatewayError;
        return new Result(
    After:
        var failureType = FailureType.GatewayError;
        return new Result(
    */
    var failureType = ModResults.FailureType.GatewayError;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region RateLimited
  public static Result RateLimited()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.RateLimited);
      }
    After:
        return new Result(FailureType.RateLimited);
      }
    */
    return new Result(ModResults.FailureType.RateLimited);
  }

  public static Result RateLimited(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.RateLimited;
        return new Result(
    After:
        var failureType = FailureType.RateLimited;
        return new Result(
    */
    var failureType = ModResults.FailureType.RateLimited;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result RateLimited(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.RateLimited, errors);
      }
    After:
        return new Result(FailureType.RateLimited, errors);
      }
    */
    return new Result(ModResults.FailureType.RateLimited, errors);
  }

  public static Result RateLimited(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.RateLimited;
        return new Result(
    After:
        var failureType = FailureType.RateLimited;
        return new Result(
    */
    var failureType = ModResults.FailureType.RateLimited;
    return new Result(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region TimedOut
  public static Result TimedOut()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.TimedOut);
      }
    After:
        return new Result(FailureType.TimedOut);
      }
    */
    return new Result(ModResults.FailureType.TimedOut);
  }

  public static Result TimedOut(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.TimedOut;
        return new Result(
    After:
        var failureType = FailureType.TimedOut;
        return new Result(
    */
    var failureType = ModResults.FailureType.TimedOut;
    return new Result(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result TimedOut(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result(Results.FailureType.TimedOut, errors);
      }
    After:
        return new Result(FailureType.TimedOut, errors);
      }
    */
    return new Result(ModResults.FailureType.TimedOut, errors);
  }

  public static Result TimedOut(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.TimedOut;
        return new Result(
    After:
        var failureType = FailureType.TimedOut;
        return new Result(
    */
    var failureType = ModResults.FailureType.TimedOut;
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

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Error);
      }
    After:
        return new Result<TValue>(FailureType.Error);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Error);
  }

  public static Result<TValue> Error(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Error;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Error;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Error;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Error(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Error, errors);
      }
    After:
        return new Result<TValue>(FailureType.Error, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Error, errors);
  }

  public static Result<TValue> Error(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Error;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Error;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Error;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Forbidden
  public static Result<TValue> Forbidden()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Forbidden);
      }
    After:
        return new Result<TValue>(FailureType.Forbidden);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Forbidden);
  }

  public static Result<TValue> Forbidden(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Forbidden;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Forbidden;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Forbidden;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Forbidden(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Forbidden, errors);
      }
    After:
        return new Result<TValue>(FailureType.Forbidden, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Forbidden, errors);
  }

  public static Result<TValue> Forbidden(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Forbidden;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Forbidden;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Forbidden;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unauthorized
  public static Result<TValue> Unauthorized()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Unauthorized);
      }
    After:
        return new Result<TValue>(FailureType.Unauthorized);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Unauthorized);
  }

  public static Result<TValue> Unauthorized(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unauthorized;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Unauthorized;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Unauthorized;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Unauthorized(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Unauthorized, errors);
      }
    After:
        return new Result<TValue>(FailureType.Unauthorized, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Unauthorized, errors);
  }

  public static Result<TValue> Unauthorized(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unauthorized;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Unauthorized;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Unauthorized;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Invalid
  public static Result<TValue> Invalid()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Invalid);
      }
    After:
        return new Result<TValue>(FailureType.Invalid);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Invalid);
  }

  public static Result<TValue> Invalid(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Invalid;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Invalid;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Invalid;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Invalid(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Invalid, errors);
      }
    After:
        return new Result<TValue>(FailureType.Invalid, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Invalid, errors);
  }

  public static Result<TValue> Invalid(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Invalid;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Invalid;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Invalid;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region NotFound
  public static Result<TValue> NotFound()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.NotFound);
      }
    After:
        return new Result<TValue>(FailureType.NotFound);
      }
    */
    return new Result<TValue>(ModResults.FailureType.NotFound);
  }

  public static Result<TValue> NotFound(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.NotFound;
        return new Result<TValue>(
    After:
        var failureType = FailureType.NotFound;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.NotFound;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> NotFound(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.NotFound, errors);
      }
    After:
        return new Result<TValue>(FailureType.NotFound, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.NotFound, errors);
  }

  public static Result<TValue> NotFound(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.NotFound;
        return new Result<TValue>(
    After:
        var failureType = FailureType.NotFound;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.NotFound;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Conflict
  public static Result<TValue> Conflict()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Conflict);
      }
    After:
        return new Result<TValue>(FailureType.Conflict);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Conflict);
  }

  public static Result<TValue> Conflict(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Conflict;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Conflict;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Conflict;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Conflict(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Conflict, errors);
      }
    After:
        return new Result<TValue>(FailureType.Conflict, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Conflict, errors);
  }

  public static Result<TValue> Conflict(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Conflict;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Conflict;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Conflict;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region CriticalError
  public static Result<TValue> CriticalError()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.CriticalError);
      }
    After:
        return new Result<TValue>(FailureType.CriticalError);
      }
    */
    return new Result<TValue>(ModResults.FailureType.CriticalError);
  }

  public static Result<TValue> CriticalError(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.CriticalError;
        return new Result<TValue>(
    After:
        var failureType = FailureType.CriticalError;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.CriticalError;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> CriticalError(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.CriticalError, errors);
      }
    After:
        return new Result<TValue>(FailureType.CriticalError, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.CriticalError, errors);
  }

  public static Result<TValue> CriticalError(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.CriticalError;
        return new Result<TValue>(
    After:
        var failureType = FailureType.CriticalError;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.CriticalError;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region Unavailable
  public static Result<TValue> Unavailable()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Unavailable);
      }
    After:
        return new Result<TValue>(FailureType.Unavailable);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Unavailable);
  }

  public static Result<TValue> Unavailable(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unavailable;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Unavailable;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Unavailable;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> Unavailable(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.Unavailable, errors);
      }
    After:
        return new Result<TValue>(FailureType.Unavailable, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.Unavailable, errors);
  }

  public static Result<TValue> Unavailable(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.Unavailable;
        return new Result<TValue>(
    After:
        var failureType = FailureType.Unavailable;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.Unavailable;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region GatewayError
  public static Result<TValue> GatewayError()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.GatewayError);
      }
    After:
        return new Result<TValue>(FailureType.GatewayError);
      }
    */
    return new Result<TValue>(ModResults.FailureType.GatewayError);
  }

  public static Result<TValue> GatewayError(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.GatewayError;
        return new Result<TValue>(
    After:
        var failureType = FailureType.GatewayError;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.GatewayError;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> GatewayError(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.GatewayError, errors);
      }
    After:
        return new Result<TValue>(FailureType.GatewayError, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.GatewayError, errors);
  }

  public static Result<TValue> GatewayError(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.GatewayError;
        return new Result<TValue>(
    After:
        var failureType = FailureType.GatewayError;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.GatewayError;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region RateLimited
  public static Result<TValue> RateLimited()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.RateLimited);
      }
    After:
        return new Result<TValue>(FailureType.RateLimited);
      }
    */
    return new Result<TValue>(ModResults.FailureType.RateLimited);
  }

  public static Result<TValue> RateLimited(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.RateLimited;
        return new Result<TValue>(
    After:
        var failureType = FailureType.RateLimited;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.RateLimited;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> RateLimited(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.RateLimited, errors);
      }
    After:
        return new Result<TValue>(FailureType.RateLimited, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.RateLimited, errors);
  }

  public static Result<TValue> RateLimited(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.RateLimited;
        return new Result<TValue>(
    After:
        var failureType = FailureType.RateLimited;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.RateLimited;
    return new Result<TValue>(
        failureType,
        exceptions.Select(x => x.ToError(failureType)));
  }
  #endregion

  #region TimedOut
  public static Result<TValue> TimedOut()
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.TimedOut);
      }
    After:
        return new Result<TValue>(FailureType.TimedOut);
      }
    */
    return new Result<TValue>(ModResults.FailureType.TimedOut);
  }

  public static Result<TValue> TimedOut(params string[] errorMessages)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.TimedOut;
        return new Result<TValue>(
    After:
        var failureType = FailureType.TimedOut;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.TimedOut;
    return new Result<TValue>(
        failureType,
        errorMessages.Select(x => x.ToError(failureType)));
  }

  public static Result<TValue> TimedOut(params Error[] errors)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        return new Result<TValue>(Results.FailureType.TimedOut, errors);
      }
    After:
        return new Result<TValue>(FailureType.TimedOut, errors);
      }
    */
    return new Result<TValue>(ModResults.FailureType.TimedOut, errors);
  }

  public static Result<TValue> TimedOut(params Exception[] exceptions)
  {

    /* Unmerged change from project 'ModResults (netstandard2.0)'
    Before:
        var failureType = Results.FailureType.TimedOut;
        return new Result<TValue>(
    After:
        var failureType = FailureType.TimedOut;
        return new Result<TValue>(
    */
    var failureType = ModResults.FailureType.TimedOut;
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