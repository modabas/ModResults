namespace ModResults;
internal static class ErrorHelpers
{
  public static Error ToError(this Exception exception, FailureType failureType)
  {
    return new Error(
        exception,
        code: Error.GetDefaultCode(failureType));
  }

  public static Error ToError(this string errorMessage, FailureType failureType)
  {
    return new Error(
        errorMessage,
        code: Error.GetDefaultCode(failureType));
  }
}
