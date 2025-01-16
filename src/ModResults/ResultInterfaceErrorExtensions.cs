using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceErrorExtensions
{
  /// <summary>
  /// Checks if the result has an <see cref="Error"/> with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Error code to check for.</param>
  /// <returns></returns>
  public static bool HasError(this IModResult<Failure> result, string code)
  {
    return result.HasError(code, Definitions.DefaultComparisonType);
  }

  /// <summary>
  /// Checks if the result has an <see cref="Error"/> with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HasError(
    this IModResult<Failure> result,
    string code,
    StringComparison comparisonType)
  {
    return result.Failure?.Errors.Any(e => e.HasCode(code, comparisonType)) ?? false;
  }

  /// <summary>
  /// Checks if the result has an <see cref="Error"/> with the specified code, returning matching errors as out parameter.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="errors">Matching error collection.</param>
  /// <returns></returns>
  public static bool HasError(
    this IModResult<Failure> result,
    string code,
    out ReadOnlyCollection<Error> errors)
  {
    return result.HasError(code, Definitions.DefaultComparisonType, out errors);
  }

  /// <summary>
  /// Checks if the result has an <see cref="Error"/> with the specified code, returning matching errors as out parameter.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <param name="errors">Matching error collection.</param>
  /// <returns></returns>
  public static bool HasError(
    this IModResult<Failure> result,
    string code,
    StringComparison comparisonType,
    out ReadOnlyCollection<Error> errors)
  {
    errors = result.GetErrors(code, comparisonType);
    return errors.Count > 0;
  }

  /// <summary>
  /// Gets all errors with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Error code to check for.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Error> GetErrors(
    this IModResult<Failure> result,
    string code)
  {
    return result.GetErrors(code, Definitions.DefaultComparisonType);
  }

  /// <summary>
  /// Gets all errors with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Error> GetErrors(
    this IModResult<Failure> result,
    string code,
    StringComparison comparisonType)
  {
    return result.GetErrorsInternal(code, comparisonType).ToList().AsReadOnly();
  }

  private static IEnumerable<Error> GetErrorsInternal(
    this IModResult<Failure> result,
    string code,
    StringComparison comparisonType)
  {
    return result.Failure?.Errors.Where(e => e.HasCode(code, comparisonType)) ?? [];
  }

  /// <summary>
  /// Checks if the result has an <see cref="Error"/> constructed from an exception of the specified type.
  /// </summary>
  /// <typeparam name="TException"></typeparam>
  /// <param name="result"></param>
  /// <param name="includeAssignableFrom">If true, checks whether ,nput exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  public static bool HasErrorWithException<TException>(
    this IModResult<Failure> result,
    bool includeAssignableFrom = false) 
    where TException : Exception
  {
    return result.Failure?.Errors.Any(e => e.HasException<TException>(includeAssignableFrom)) ?? false;
  }

  /// <summary>
  /// Checks if the result has an <see cref="Error"/> constructed from an exception of the specified type, returning matching errors as out parameter.
  /// </summary>
  /// <typeparam name="TException"></typeparam>
  /// <param name="result"></param>
  /// <param name="errors"></param>
  /// <param name="includeAssignableFrom">If true, checks whether ,nput exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  public static bool HasErrorWithException<TException>(
    this IModResult<Failure> result,
    out ReadOnlyCollection<Error> errors,
    bool includeAssignableFrom = false) 
    where TException : Exception
  {
    errors = result.GetErrorsWithException<TException>(includeAssignableFrom);
    return errors.Count > 0;
  }

  /// <summary>
  /// Gets all errors constructed from an exception of the specified type.
  /// </summary>
  /// <typeparam name="TException"></typeparam>
  /// <param name="result"></param>
  /// <param name="includeAssignableFrom">If true, checks whether ,nput exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Error> GetErrorsWithException<TException>(
    this IModResult<Failure> result,
    bool includeAssignableFrom = false) 
    where TException : Exception
  {
    return result.GetErrorsWithExceptionInternal<TException>(includeAssignableFrom).ToList().AsReadOnly();
  }

  private static IEnumerable<Error> GetErrorsWithExceptionInternal<TException>(
    this IModResult<Failure> result,
    bool includeAssignableFrom = false) where TException : Exception
  {
    return result.Failure?.Errors.Where(e => e.HasException<TException>(includeAssignableFrom)) ?? [];
  }
}
