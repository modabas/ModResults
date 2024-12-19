using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceErrorExtensions
{
  public static bool HasError(this IModResult<Failure> result, string code)
  {
    return result.HasError(code, Definitions.DefaultComparisonType);
  }

  public static bool HasError(this IModResult<Failure> result, string code, StringComparison comparisonType)
  {
    return result.Failure?.Errors.Any(e => e.HasCode(code, comparisonType)) ?? false;
  }

  public static bool HasError(this IModResult<Failure> result, string code, out ReadOnlyCollection<Error> errors)
  {
    return result.HasError(code, Definitions.DefaultComparisonType, out errors);
  }

  public static bool HasError(this IModResult<Failure> result, string code, StringComparison comparisonType, out ReadOnlyCollection<Error> errors)
  {
    errors = result.GetErrors(code, comparisonType);
    return errors.Count > 0;
  }

  public static ReadOnlyCollection<Error> GetErrors(this IModResult<Failure> result, string code)
  {
    return result.GetErrors(code, Definitions.DefaultComparisonType);
  }

  public static ReadOnlyCollection<Error> GetErrors(this IModResult<Failure> result, string code, StringComparison comparisonType)
  {
    return result.GetErrorsInternal(code, comparisonType).ToList().AsReadOnly();
  }

  private static IEnumerable<Error> GetErrorsInternal(this IModResult<Failure> result, string code, StringComparison comparisonType)
  {
    return result.Failure?.Errors.Where(e => e.HasCode(code, comparisonType)) ?? [];
  }

  public static bool HasErrorWithException<TException>(this IModResult<Failure> result, bool includeAssignableFrom = false) where TException : Exception
  {
    return result.Failure?.Errors.Any(e => e.HasException<TException>(includeAssignableFrom)) ?? false;
  }

  public static bool HasErrorWithException<TException>(this IModResult<Failure> result, out ReadOnlyCollection<Error> errors, bool includeAssignableFrom = false) where TException : Exception
  {
    errors = result.GetErrorsWithException<TException>(includeAssignableFrom);
    return errors.Count > 0;
  }

  public static ReadOnlyCollection<Error> GetErrorsWithException<TException>(this IModResult<Failure> result, bool includeAssignableFrom = false) where TException : Exception
  {
    return result.GetErrorsWithExceptionInternal<TException>(includeAssignableFrom).ToList().AsReadOnly();
  }

  private static IEnumerable<Error> GetErrorsWithExceptionInternal<TException>(this IModResult<Failure> result, bool includeAssignableFrom = false) where TException : Exception
  {
    return result.Failure?.Errors.Where(e => e.HasException<TException>(includeAssignableFrom)) ?? [];
  }
}
