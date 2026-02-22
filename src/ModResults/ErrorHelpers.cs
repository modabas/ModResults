namespace ModResults;

internal static class ErrorHelpers
{
  extension(Exception exception)
  {
    /// <summary>
    /// Creates an <see cref="Error"/> instance from an <see cref="Exception"/>.
    /// </summary>
    /// <param name="failureType">Failure type that created error will be associated with.</param>
    /// <returns></returns>
    public Error ToError(FailureType failureType)
    {
      return new Error(
          exception,
          code: Error.GetDefaultCode(failureType));
    }
  }

  extension(string errorMessage)
  {
    /// <summary>
    /// Creates an <see cref="Error"/> instance from an error message.
    /// </summary>
    /// <param name="failureType">Failure type that created error will be associated with.</param>
    /// <returns></returns>
    public Error ToError(FailureType failureType)
    {
      return new Error(
          errorMessage,
          code: Error.GetDefaultCode(failureType));
    }
  }
}
