using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ModResults.MinimalApis;

public static class TypedResultsExtensions
{
  extension(TypedResults)
  {
    /// <summary>
    /// Converts a Failed <see cref="Result"/> to an error response of type <see cref="ProblemHttpResult"/> based on its failure type.
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException">Thrown if result is in Ok state.</exception>
    public static ProblemHttpResult Problem(IModResult<Failure> result)
    {
      if (result.IsOk)
      {
        throw new NotSupportedException();
      }
      return result.Failure?.Type switch
      {
        FailureType.Unspecified => result.ToProblem(StatusCodes.Status500InternalServerError),
        FailureType.Error => result.ToProblem(StatusCodes.Status422UnprocessableEntity),
        FailureType.Forbidden => result.ToProblem(StatusCodes.Status403Forbidden),
        FailureType.Unauthorized => result.ToProblem(StatusCodes.Status401Unauthorized),
        FailureType.Invalid => result.ToValidationProblem(),
        FailureType.NotFound => result.ToProblem(StatusCodes.Status404NotFound),
        FailureType.Conflict => result.ToProblem(StatusCodes.Status409Conflict),
        FailureType.CriticalError => result.ToProblem(StatusCodes.Status500InternalServerError),
        FailureType.Unavailable => result.ToProblem(StatusCodes.Status503ServiceUnavailable),
        FailureType.GatewayError => result.ToProblem(StatusCodes.Status502BadGateway),
        FailureType.RateLimited => result.ToProblem(StatusCodes.Status429TooManyRequests),
        FailureType.TimedOut => result.ToProblem(StatusCodes.Status504GatewayTimeout),
        FailureType.PaymentRequired => result.ToProblem(StatusCodes.Status402PaymentRequired),
        _ => result.ToProblem(StatusCodes.Status500InternalServerError)
      };
    }
  }
  private static readonly IReadOnlyList<Error> _emptyErrors = [];
  private static ProblemHttpResult ToProblem(this IModResult<Failure> result, int statusCode)
  {
    var detail = result.Failure?.Errors.FirstOrDefault()?.Message;
    var extensions = new Dictionary<string, object?>()
    {
      { "errors", result.Failure?.Errors ?? _emptyErrors },
      { "facts", result.Statements.Facts },
      { "warnings", result.Statements.Warnings }
    };
    return TypedResults.Problem(
      detail: detail,
      statusCode: statusCode,
      extensions: extensions);
  }

  private static ProblemHttpResult ToValidationProblem(this IModResult<Failure> result)
  {
    var errors = (result.Failure?.Errors ?? _emptyErrors)
        .GroupBy(e => e.PropertyName ?? string.Empty)
        .Select(g => new { g.Key, Values = g.Select(e => e.Message).ToArray() })
        .ToDictionary(pair => pair.Key, pair => pair.Values);
    var extensions = new Dictionary<string, object?>()
    {
      { "facts", result.Statements.Facts },
      { "warnings", result.Statements.Warnings }
    };
    var problemDetails = new HttpValidationProblemDetails(errors)
    {
      Extensions = extensions
    };
    return TypedResults.Problem(problemDetails);
  }
}
