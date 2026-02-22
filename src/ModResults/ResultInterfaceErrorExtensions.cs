using System.Collections.ObjectModel;

namespace ModResults;

public static class ResultInterfaceErrorExtensions
{
  extension(BaseResult<Failure> result)
  {
    /// <summary>
    /// Checks if the result has an <see cref="Error"/> with the specified code.
    /// </summary>
    /// <param name="code">Error code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasError(
      string code,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      return (result.Failure?.HasErrors() ?? false) &&
        result.Failure.Errors.Any(e => e.HasCode(code, comparisonType));
    }

    /// <summary>
    /// Checks if the result has an <see cref="Error"/> with the specified code, returning matching errors as out parameter.
    /// </summary>
    /// <param name="code">Error code to check for.</param>
    /// <param name="errors">Matching error collection.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasError(
      string code,
      out ReadOnlyCollection<Error> errors,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      errors = result.GetErrors(code, comparisonType);
      return errors.Count > 0;
    }

    /// <summary>
    /// Gets all errors with the specified code.
    /// </summary>
    /// <param name="code">Error code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public ReadOnlyCollection<Error> GetErrors(
      string code,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      return result.GetErrorsInternal(code, comparisonType).ToList().AsReadOnly();
    }

    private IEnumerable<Error> GetErrorsInternal(
      string code,
      StringComparison comparisonType)
    {
      if ((result.Failure?.HasErrors() ?? false))
      {
        return result.Failure.Errors.Where(e => e.HasCode(code, comparisonType));
      }
      return [];
    }

    /// <summary>
    /// Checks if the result has an <see cref="Error"/> constructed from an exception of the specified type.
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public bool HasErrorWithException<TException>(
      bool includeAssignableTo = false)
      where TException : Exception
    {
      return (result.Failure?.HasErrors() ?? false) &&
        result.Failure.Errors.Any(e => e.HasException<TException>(includeAssignableTo));
    }

    /// <summary>
    /// Checks if the result has an <see cref="Error"/> constructed from an exception of the specified type, returning matching errors as out parameter.
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <param name="errors"></param>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public bool HasErrorWithException<TException>(
      out ReadOnlyCollection<Error> errors,
      bool includeAssignableTo = false)
      where TException : Exception
    {
      errors = result.GetErrorsWithException<TException>(includeAssignableTo);
      return errors.Count > 0;
    }

    /// <summary>
    /// Gets all errors constructed from an exception of the specified type.
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public ReadOnlyCollection<Error> GetErrorsWithException<TException>(
      bool includeAssignableTo = false)
      where TException : Exception
    {
      return result.GetErrorsWithExceptionInternal<TException>(includeAssignableTo).ToList().AsReadOnly();
    }

    private IEnumerable<Error> GetErrorsWithExceptionInternal<TException>(
      bool includeAssignableTo = false) where TException : Exception
    {
      if ((result.Failure?.HasErrors() ?? false))
      {
        return result.Failure.Errors.Where(e => e.HasException<TException>(includeAssignableTo));
      }
      return [];
    }

    /// <summary>
    /// Checks if the result has an <see cref="Error"/> constructed from an exception of the specified type.
    /// </summary>
    /// <param name="exceptionType">Exception type</param>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public bool HasErrorWithException(
      Type exceptionType,
      bool includeAssignableTo = false)
    {
      return (result.Failure?.HasErrors() ?? false) &&
        result.Failure.Errors.Any(e => e.HasException(exceptionType, includeAssignableTo));
    }

    /// <summary>
    /// Checks if the result has an <see cref="Error"/> constructed from an exception of the specified type, returning matching errors as out parameter.
    /// </summary>
    /// <param name="exceptionType">Exception type</param>
    /// <param name="errors"></param>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public bool HasErrorWithException(
      Type exceptionType,
      out ReadOnlyCollection<Error> errors,
      bool includeAssignableTo = false)
    {
      errors = result.GetErrorsWithException(exceptionType, includeAssignableTo);
      return errors.Count > 0;
    }

    /// <summary>
    /// Gets all errors constructed from an exception of the specified type.
    /// </summary>
    /// <param name="exceptionType">Exception type</param>
    /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
    /// <returns></returns>
    public ReadOnlyCollection<Error> GetErrorsWithException(
      Type exceptionType,
      bool includeAssignableTo = false)
    {
      return result.GetErrorsWithExceptionInternal(exceptionType, includeAssignableTo).ToList().AsReadOnly();
    }

    private IEnumerable<Error> GetErrorsWithExceptionInternal(
      Type exceptionType,
      bool includeAssignableTo = false)
    {
      if ((result.Failure?.HasErrors() ?? false))
      {
        return result.Failure.Errors.Where(e => e.HasException(exceptionType, includeAssignableTo));
      }
      return [];
    }
  }
}
