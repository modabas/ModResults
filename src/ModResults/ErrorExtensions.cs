namespace ModResults;
public static class ErrorExtensions
{
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

  public static bool HasCode(this Error error, string code, StringComparison comparisonType)
  {
    return error.Code?.Equals(code, comparisonType) ?? false;
  }
}
