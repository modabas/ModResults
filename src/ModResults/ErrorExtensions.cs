namespace ModResults;
public static class ErrorExtensions
{
  /// <summary>
  /// Checks whether the error has been constructed from an exception of the specified type.
  /// </summary>
  /// <typeparam name="TException">Exception type</typeparam>
  /// <param name="error"></param>
  /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  public static bool HasException<TException>(this Error error, bool includeAssignableTo = false)
    where TException : Exception
  {
    return error.HasException(typeof(TException), includeAssignableTo);
  }

  /// <summary>
  /// Checks whether the error has been constructed from an exception of the specified type.
  /// </summary>
  /// <param name="error"></param>
  /// <param name="exceptionType">Exception type</param>
  /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  public static bool HasException(this Error error, Type exceptionType, bool includeAssignableTo = false)
  {
    if (!typeof(Exception).IsAssignableFrom(exceptionType))
    {
      return false;
    }
    if (!error.IsFromException)
    {
      return false;
    }
    var errorExceptionType = Type.GetType(error.ExceptionTypeName);
    if (errorExceptionType is null)
    {
      return false;
    }
    if (includeAssignableTo)
    {
      if (exceptionType.IsAssignableFrom(errorExceptionType))
      {
        return true;
      }
    }
    else
    {
      if (errorExceptionType == exceptionType)
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
