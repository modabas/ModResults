namespace ModResults;
internal static class ErrorHelpers
{
  /// <summary>
  /// Creates an <see cref="Error"/> instance from an <see cref="Exception"/>.
  /// </summary>
  /// <param name="exception"></param>
  /// <param name="failureType">Failure type that created error will be associated with.</param>
  /// <returns></returns>
  public static Error ToError(this Exception exception, FailureType failureType)
  {
    return new Error(
        exception,
        code: Error.GetDefaultCode(failureType));
  }

  /// <summary>
  /// Creates an <see cref="Error"/> instance from an error message.
  /// </summary>
  /// <param name="errorMessage"></param>
  /// <param name="failureType">Failure type that created error will be associated with.</param>
  /// <returns></returns>
  public static Error ToError(this string errorMessage, FailureType failureType)
  {
    return new Error(
        errorMessage,
        code: Error.GetDefaultCode(failureType));
  }
}
