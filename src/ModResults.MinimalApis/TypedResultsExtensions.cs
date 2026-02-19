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
    public static ProblemHttpResult Problem(BaseResult<Failure> result)
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
  private static readonly IReadOnlyList<Fact> _emptyFacts = [];
  private static readonly IReadOnlyList<Warning> _emptyWarnings = [];
  private static ProblemHttpResult ToProblem(this BaseResult<Failure> result, int statusCode)
  {
    var errors = (result.Failure?.HasErrors() ?? false) ? result.Failure.Errors : _emptyErrors;
    var detail = errors.FirstOrDefault()?.Message;
    var extensions = new Dictionary<string, object?>()
    {
      { "errors", errors },
      { "facts", result.HasFacts() ? result.Statements.Facts : _emptyFacts },
      { "warnings", result.HasWarnings() ? result.Statements.Warnings : _emptyWarnings }
    };
    return TypedResults.Problem(
      detail: detail,
      statusCode: statusCode,
      extensions: extensions);
  }

  private static ProblemHttpResult ToValidationProblem(this BaseResult<Failure> result)
  {
    var resultErrors = (result.Failure?.HasErrors() ?? false) ? result.Failure.Errors : _emptyErrors;
    var errors = resultErrors
        .GroupBy(e => e.PropertyName ?? string.Empty)
        .Select(g => new { g.Key, Values = g.Select(e => e.Message).ToArray() })
        .ToDictionary(pair => pair.Key, pair => pair.Values);
    var extensions = new Dictionary<string, object?>()
    {
      { "facts", result.HasFacts() ? result.Statements.Facts : _emptyFacts },
      { "warnings", result.HasWarnings() ? result.Statements.Warnings : _emptyWarnings }
    };
    var problemDetails = new HttpValidationProblemDetails(errors)
    {
      Extensions = extensions
    };
    return TypedResults.Problem(problemDetails);
  }
}
