using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceCollectionWarningExtensions
{
  public static ReadOnlyCollection<Warning> GetWarnings(this IEnumerable<IModResult> results)
  {
    return results.SelectMany(r => r.Statements.Warnings).ToList().AsReadOnly();
  }

  public static bool HaveWarning(this IEnumerable<IModResult> results, string code)
  {
    return results.HaveWarning(code, Definitions.DefaultComparisonType);
  }

  public static bool HaveWarning(this IEnumerable<IModResult> results, string code, StringComparison comparisonType)
  {
    return results.Select(r => r.HasWarning(code, comparisonType)).Any(h => h);
  }

  public static bool HaveWarning(this IEnumerable<IModResult> results, string code, out ReadOnlyCollection<Warning> warnings)
  {
    return results.HaveWarning(code, Definitions.DefaultComparisonType, out warnings);
  }

  public static bool HaveWarning(this IEnumerable<IModResult> results, string code, StringComparison comparisonType, out ReadOnlyCollection<Warning> warnings)
  {
    warnings = results.GetWarnings(code, comparisonType);
    return warnings.Count > 0;
  }

  public static ReadOnlyCollection<Warning> GetWarnings(this IEnumerable<IModResult> results, string code)
  {
    return results.GetWarnings(code, Definitions.DefaultComparisonType);
  }

  public static ReadOnlyCollection<Warning> GetWarnings(this IEnumerable<IModResult> results, string code, StringComparison comparisonType)
  {
    return results.SelectMany(r => r.GetWarnings(code, comparisonType)).ToList().AsReadOnly();
  }
}
