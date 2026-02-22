using System.Collections.ObjectModel;

namespace ModResults;

public static class ResultInterfaceWarningExtensions
{
  extension(BaseResult result)
  {
    /// <summary>
    /// Checks if the result has a <see cref="Warning"/> with the specified code.
    /// </summary>
    /// <param name="code">Warning code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasWarning(
      string code,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      return result.HasWarnings() && result.Statements.Warnings.Any(p => p.HasCode(code, comparisonType));
    }

    /// <summary>
    /// Checks if the result has a <see cref="Warning"/> with the specified code, returning matching warnings as out parameter.
    /// </summary>
    /// <param name="code">Warning code to check for.</param>
    /// <param name="warnings">Matching warning collection.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasWarning(
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
    /// <param name="code">Warning code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public ReadOnlyCollection<Warning> GetWarnings(
      string code,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      return result.GetWarningsInternal(code, comparisonType).ToList().AsReadOnly();
    }

    private IEnumerable<Warning> GetWarningsInternal(
      string code,
      StringComparison comparisonType)
    {
      if (result.HasWarnings())
      {
        return result.Statements.Warnings.Where(w => w.HasCode(code, comparisonType));
      }
      return [];
    }
  }
}
