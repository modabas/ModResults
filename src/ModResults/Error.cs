using System.Diagnostics.CodeAnalysis;

namespace ModResults;

/// <summary>
/// Contains error info for a failed <see cref="Result"/> or <see cref="Result{TValue}"/>"/>
/// </summary>
public class Error
{
  /// <summary>
  /// The <see cref="Error"/> instance that causes the current error.
  /// </summary>
  public Error? InnerError { get; set; }

  /// <summary>
  /// The error message.
  /// </summary>
  public string Message { get; set; }

  /// <summary>
  /// A value indicating whether the error is from an exception.
  /// </summary>
  [MemberNotNullWhen(returnValue: true, nameof(ExceptionTypeName))]
  public bool IsFromException => ExceptionTypeName is not null;

  /// <summary>
  /// The <see cref="Exception"/> type name that is used to construct this <see cref="Error"/> instance from.
  /// </summary>
  public string? ExceptionTypeName { get; set; }

  /// <summary>
  /// Error code.
  /// </summary>
  public string? Code { get; set; }

  /// <summary>
  /// Property name associated with the error.
  /// </summary>
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

  /// <summary>
  /// Gets the default error code for the specified <see cref="FailureType"/>.
  /// </summary>
  /// <param name="failureType"></param>
  /// <returns></returns>
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
      FailureType.PaymentRequired => "Failure.PaymentRequired",
      _ => null,
    };
  }
}
