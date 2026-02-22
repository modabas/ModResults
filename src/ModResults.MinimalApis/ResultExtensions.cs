using Microsoft.AspNetCore.Http;

namespace ModResults.MinimalApis;

public static class ResultExtensions
{
  /// <summary>
  /// Converts <see cref="Result"/> to a response of type <see cref="IResult"/> based on its state and failure type.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="type">Kind of HTTP 2XX success response to be created if result is in Ok state.</param>
  /// <returns></returns>
  /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"></exception>
  public static IResult ToResponse(
    this Result result,
    SuccessfulResponseType type = SuccessfulResponseType.NoContent)
  {
    if (result.IsOk)
    {
      return type switch
      {
        SuccessfulResponseType.Ok => Results.Ok(),
        SuccessfulResponseType.NoContent => Results.NoContent(),
        SuccessfulResponseType.Created => Results.Created(),
        SuccessfulResponseType.Accepted => Results.Accepted(),
        SuccessfulResponseType.ResetContent => Results.StatusCode(StatusCodes.Status205ResetContent),
        _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(type), (int)type, typeof(SuccessfulResponseType)),
      };
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result"/> to a created or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="IResult"/> will be a created response.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="uri">The Uri with the location at which the status of requested content can be monitored.</param>
  /// <returns></returns>
  public static IResult ToCreatedOrErrorResponse(this Result result, string? uri)
  {
    if (result.IsOk)
    {
      return Results.Created(uri, null);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result"/> to a created or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="IResult"/> will be a created response.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="uri">The Uri with the location at which the status of requested content can be monitored.</param>
  /// <returns></returns>
  public static IResult ToCreatedOrErrorResponse(this Result result, Uri? uri)
  {
    if (result.IsOk)
    {
      return Results.Created(uri, null);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result"/> to a created or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="IResult"/> will be a created response.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="routeName">The name of the route to use for generating Url.</param>
  /// <param name="routeValues">The route data to use for generating Url.</param>
  /// <returns></returns>
  public static IResult ToCreatedOrErrorResponse(
    this Result result,
    string? routeName,
    object? routeValues)
  {
    if (result.IsOk)
    {
      return Results.CreatedAtRoute(routeName, routeValues, null);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result"/> to an accepted or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="IResult"/> will be an accepted response.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="uri">The Uri with the location at which the status of requested content can be monitored.</param>
  /// <returns></returns>
  public static IResult ToAcceptedOrErrorResponse(
    this Result result,
    string? uri)
  {
    if (result.IsOk)
    {
      return Results.Accepted(uri, null);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result"/> to an accepted or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result"/> is in Ok state, the returned <see cref="IResult"/> will be an accepted response.
  /// If source <see cref="Result"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="routeName">The name of the route to use for generating Url.</param>
  /// <param name="routeValues">The route data to use for generating Url.</param>
  /// <returns></returns>
  public static IResult ToAcceptedOrErrorResponse(
    this Result result,
    string? routeName,
    object? routeValues)
  {
    if (result.IsOk)
    {
      return Results.AcceptedAtRoute(routeName, routeValues, null);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result{TValue}"/> to a response of type <see cref="IResult"/> based on its state and failure type.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="type">Kind of HTTP 2XX success response to be created if result is in Ok state.</param>
  /// <returns></returns>
  /// <exception cref="System.ComponentModel.InvalidEnumArgumentException"></exception>
  public static IResult ToResponse<TValue>(
    this Result<TValue> result,
    SuccessfulResponseType type = SuccessfulResponseType.Ok)
    where TValue : notnull
  {
    if (result.IsOk)
    {
      return type switch
      {
        SuccessfulResponseType.Ok => Results.Ok(result.Value),
        SuccessfulResponseType.NoContent => Results.NoContent(),
        SuccessfulResponseType.Created => Results.Created(default(string), result.Value),
        SuccessfulResponseType.Accepted => Results.Accepted(default, result.Value),
        SuccessfulResponseType.ResetContent => Results.StatusCode(StatusCodes.Status205ResetContent),
        _ => throw new System.ComponentModel.InvalidEnumArgumentException(nameof(type), (int)type, typeof(SuccessfulResponseType)),
      };
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result{TValue}"/> to a created or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result{TValue}"/> is in Ok state, the returned <see cref="IResult"/> will be a created response.
  /// If source <see cref="Result{TValue}"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="uri">The Uri with the location at which the status of requested content can be monitored.</param>
  /// <returns></returns>
  public static IResult ToCreatedOrErrorResponse<TValue>(
    this Result<TValue> result,
    string? uri)
    where TValue : notnull
  {
    if (result.IsOk)
    {
      return Results.Created(uri, result.Value);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result{TValue}"/> to a created or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result{TValue}"/> is in Ok state, the returned <see cref="IResult"/> will be a created response.
  /// If source <see cref="Result{TValue}"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="uri">The Uri with the location at which the status of requested content can be monitored.</param>
  /// <returns></returns>
  public static IResult ToCreatedOrErrorResponse<TValue>(
    this Result<TValue> result,
    Uri? uri)
    where TValue : notnull
  {
    if (result.IsOk)
    {
      return Results.Created(uri, result.Value);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result{TValue}"/> to a created or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result{TValue}"/> is in Ok state, the returned <see cref="IResult"/> will be a created response.
  /// If source <see cref="Result{TValue}"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="routeName">The name of the route to use for generating Url.</param>
  /// <param name="routeValues">The route data to use for generating Url.</param>
  /// <returns></returns>
  public static IResult ToCreatedOrErrorResponse<TValue>(
    this Result<TValue> result,
    string? routeName,
    object? routeValues)
    where TValue : notnull
  {
    if (result.IsOk)
    {
      return Results.CreatedAtRoute(routeName, routeValues, result.Value);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result{TValue}"/> to an accepted or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result{TValue}"/> is in Ok state, the returned <see cref="IResult"/> will be an accepted response.
  /// If source <see cref="Result{TValue}"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="uri">The Uri with the location at which the status of requested content can be monitored.</param>
  /// <returns></returns>
  public static IResult ToAcceptedOrErrorResponse<TValue>(
    this Result<TValue> result,
    string? uri)
    where TValue : notnull
  {
    if (result.IsOk)
    {
      return Results.Accepted(uri, result.Value);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts <see cref="Result{TValue}"/> to an accepted or an error response of type <see cref="IResult"/> based on its state and failure type.
  /// If source <see cref="Result{TValue}"/> is in Ok state, the returned <see cref="IResult"/> will be an accepted response.
  /// If source <see cref="Result{TValue}"/> is in Fail state, the returned <see cref="IResult"/> will be an error response.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="routeName">The name of the route to use for generating Url.</param>
  /// <param name="routeValues">The route data to use for generating Url.</param>
  /// <returns></returns>
  public static IResult ToAcceptedOrErrorResponse<TValue>(
    this Result<TValue> result,
    string? routeName,
    object? routeValues)
    where TValue : notnull
  {
    if (result.IsOk)
    {
      return Results.AcceptedAtRoute(routeName, routeValues, result.Value);
    }
    else
    {
      return result.ToErrorResponse();
    }
  }

  /// <summary>
  /// Converts a Failed <see cref="Result"/> to an error response of type <see cref="IResult"/> based on its failure type.
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
  /// <exception cref="NotSupportedException">Thrown if result is in Ok state.</exception>
  public static IResult ToErrorResponse(this BaseResult<Failure> result)
  {
    return TypedResults.Problem(result);
  }
}
