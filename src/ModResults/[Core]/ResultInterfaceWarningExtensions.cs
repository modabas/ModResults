using System.Collections.ObjectModel;

namespace ModResults;

public static class ResultInterfaceWarningExtensions
{
  /// <summary>
  /// Checks if the result has a <see cref="Warning"/> with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Warning code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HasWarning(
    this IModResult result,
    string code,
    StringComparison comparisonType = Definitions.DefaultComparisonType)
  {
    return result.Statements.Warnings.Any(p => p.HasCode(code, comparisonType));
  }

  /// <summary>
  /// Checks if the result has a <see cref="Warning"/> with the specified code, returning matching warnings as out parameter.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Warning code to check for.</param>
  /// <param name="warnings">Matching warning collection.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HasWarning(
    this IModResult result,
    string code,
    out ReadOnlyCollection<Warning> warnings,
    StringComparison comparisonType = Definitions.DefaultComparisonType)
  {
    warnings = result.GetWarnings(code, comparisonType);
    return warnings.Count > 0;
  }

  /// <summary>
  /// Gets all warnings with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Warning code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Warning> GetWarnings(
    this IModResult result,
    string code,
    StringComparison comparisonType = Definitions.DefaultComparisonType)
  {
    return result.GetWarningsInternal(code, comparisonType).ToList().AsReadOnly();
  }

  private static IEnumerable<Warning> GetWarningsInternal(
    this IModResult result,
    string code,
    StringComparison comparisonType)
  {
    return result.Statements.Warnings.Where(w => w.HasCode(code, comparisonType));
  }
}
