using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceWarningExtensions
{
  public static bool HasWarning(this IModResult result, string code)
  {
    return result.HasWarning(code, Definitions.DefaultComparisonType);
  }

  public static bool HasWarning(this IModResult result, string code, StringComparison comparisonType)
  {
    return result.Statements.Warnings.Any(p => p.HasCode(code, comparisonType));
  }

  public static bool HasWarning(this IModResult result, string code, out ReadOnlyCollection<Warning> warnings)
  {
    return result.HasWarning(code, Definitions.DefaultComparisonType, out warnings);
  }

  public static bool HasWarning(this IModResult result, string code, StringComparison comparisonType, out ReadOnlyCollection<Warning> warnings)
  {
    warnings = result.GetWarnings(code, comparisonType);
    return warnings.Count > 0;
  }

  public static ReadOnlyCollection<Warning> GetWarnings(this IModResult result, string code)
  {
    return result.GetWarnings(code, Definitions.DefaultComparisonType);
  }

  public static ReadOnlyCollection<Warning> GetWarnings(this IModResult result, string code, StringComparison comparisonType)
  {
    return result.GetWarningsInternal(code, comparisonType).ToList().AsReadOnly();
  }

  private static IEnumerable<Warning> GetWarningsInternal(this IModResult result, string code, StringComparison comparisonType)
  {
    return result.Statements.Warnings.Where(w => w.HasCode(code, comparisonType));
  }
}
