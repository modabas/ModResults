namespace ModResults;
public static class ErrorExtensions
{
  /// <summary>
  /// Checks whether the error has been constructed from an exception of the specified type.
  /// </summary>
  /// <typeparam name="TException">Exception type</typeparam>
  /// <param name="error"></param>
  /// <param name="includeAssignableFrom">If true, checks whether ,nput exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  public static bool HasException<TException>(this Error error, bool includeAssignableFrom = false)
    where TException : Exception
  {
    if (!error.IsFromException)
    {
      return false;
    }
    var errorType = Type.GetType(error.ExceptionTypeName);
    if (errorType is null)
    {
      return false;
    }
    if (includeAssignableFrom)
    {
      if (typeof(TException).IsAssignableFrom(errorType))
      {
        return true;
      }
    }
    else
    {
      if (errorType == typeof(TException))
      {
        return true;
      }
    }
    return false;
  }

  /// <summary>
  /// Checks whether the error has specified error code.
  /// </summary>
  /// <param name="error"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HasCode(this Error error, string code, StringComparison comparisonType)
  {
    return error.Code?.Equals(code, comparisonType) ?? false;
  }
}
