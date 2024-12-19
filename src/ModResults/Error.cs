using System.Diagnostics.CodeAnalysis;

namespace ModResults;
public class Error
{
  public Error? InnerError { get; set; }

  public string Message { get; set; }

  [MemberNotNullWhen(returnValue: true, nameof(ExceptionTypeName))]
  public bool IsFromException => ExceptionTypeName is not null;

  public string? ExceptionTypeName { get; set; }
  public string? Code { get; set; }
  public string? PropertyName { get; set; }

  public Error(string errorMessage,
      Error? innerError = null,
      Type? exceptionType = null,
      string? code = null,
      string? propertyName = null)
  {
    Message = errorMessage;
    InnerError = innerError;
    ExceptionTypeName = exceptionType?.AssemblyQualifiedName;
    Code = code;
    PropertyName = propertyName;
  }

  public Error(string errorMessage,
      string? exceptionTypeName,
      Error? innerError,
      string? code,
      string? propertyName)
  {
    Message = errorMessage;
    InnerError = innerError;
    ExceptionTypeName = exceptionTypeName;
    Code = code;
    PropertyName = propertyName;
  }

  public Error(Exception exception,
      int? maximumDepth = 10,
      string? code = null,
      string? propertyName = null)
  {
    ExceptionTypeName = exception.GetType().AssemblyQualifiedName;
    Code = code ?? exception.HResult.ToString();
    Message = exception.Message;
    PropertyName = propertyName;
    if (exception.InnerException is not null && maximumDepth > 0)
    {
      InnerError = new Error(exception.InnerException, maximumDepth - 1);
    }
  }

  public Error() : this(string.Empty, code: null)
  {
  }

  public static string? GetDefaultCode(FailureType failureType)
  {
    return failureType switch
    {
      FailureType.Unspecified => "Failure.Unspecified",
      FailureType.Error => "Failure.Error",
      FailureType.Forbidden => "Failure.Forbidden",
      FailureType.Unauthorized => "Failure.Unauthorized",
      FailureType.Invalid => "Failure.Invalid",
      FailureType.NotFound => "Failure.NotFound",
      FailureType.Conflict => "Failure.Conflict",
      FailureType.CriticalError => "Failure.CriticalError",
      FailureType.Unavailable => "Failure.Unavailable",
      FailureType.GatewayError => "Failure.GatewayError",
      FailureType.RateLimited => "Failure.RateLimited",
      FailureType.TimedOut => "Failure.TimedOut",
      _ => null,
    };
  }
}
