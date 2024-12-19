using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceCollectionErrorExtensions
{
  public static ReadOnlyCollection<Error> GetErrors(this IEnumerable<IModResult<Failure>> results)
  {
    return results.SelectMany(r => r.Failure?.Errors ?? []).ToList().AsReadOnly();
  }

  public static bool HaveError(this IEnumerable<IModResult<Failure>> results, string code)
  {
    return results.HaveError(code, Definitions.DefaultComparisonType);
  }

  public static bool HaveError(this IEnumerable<IModResult<Failure>> results, string code, StringComparison comparisonType)
  {
    return results.Select(r => r.HasError(code, comparisonType)).Any(h => h);
  }

  public static bool HaveError(this IEnumerable<IModResult<Failure>> results, string code, out ReadOnlyCollection<Error> errors)
  {
    return results.HaveError(code, Definitions.DefaultComparisonType, out errors);
  }

  public static bool HaveError(this IEnumerable<IModResult<Failure>> results, string code, StringComparison comparisonType, out ReadOnlyCollection<Error> errors)
  {
    errors = results.GetErrors(code, comparisonType);
    return errors.Count > 0;
  }

  public static ReadOnlyCollection<Error> GetErrors(this IEnumerable<IModResult<Failure>> results, string code)
  {
    return results.GetErrors(code, Definitions.DefaultComparisonType);
  }

  public static ReadOnlyCollection<Error> GetErrors(this IEnumerable<IModResult<Failure>> results, string code, StringComparison comparisonType)
  {
    return results.SelectMany(r => r.GetErrors(code, comparisonType)).ToList().AsReadOnly();
  }
}
