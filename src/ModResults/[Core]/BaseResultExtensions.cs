using System.Collections.ObjectModel;
using System.Text;

namespace ModResults;

public static class BaseResultExtensions
{
  extension(BaseResult result)
  {
    /// <summary>
    /// Dumps the state, facts and warnings of the result as a formatted string.
    /// </summary>
    /// <returns></returns>
    public string DumpStatements()
    {
      var sb = new StringBuilder();
      sb.AppendLine($"IsOk: {result.IsOk}");
      if (result.HasFacts())
      {
        sb.AppendLine("Facts:");
        sb = result.Statements.Facts.Select(e => e.Message)
          .Aggregate(sb, (sb, m) => sb.AppendLine($"  {m}"));
      }
      if (result.HasWarnings())
      {
        sb.AppendLine("Warnings:");
        sb = result.Statements.Warnings.Select(e => e.Message)
          .Aggregate(sb, (sb, m) => sb.AppendLine($"  {m}"));
      }
      return sb.ToString();
    }

    /// <summary>
    /// Determines whether the result has a <see cref="Fact"/> with the specified code.
    /// </summary>
    /// <param name="code">Fact code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasFact(
      string code,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      return result.PeekStatements()?.PeekFacts()?.Any(f => f.HasCode(code, comparisonType)) ?? false;
    }

    /// <summary>
    /// Checks if the result has a <see cref="Fact"/> with the specified code, returning matching facts as out parameter.
    /// </summary>
    /// <param name="code">Fact code to check for.</param>
    /// <param name="facts">Matching fact collection.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasFact(
      string code,
      out ReadOnlyCollection<Fact> facts,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      facts = result.GetFacts(code, comparisonType);
      return facts.Count > 0;
    }

    /// <summary>
    /// Gets all <see cref="Fact"/>s with the specified code.
    /// </summary>
    /// <param name="code">Fact code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public ReadOnlyCollection<Fact> GetFacts(
      string code,
      StringComparison comparisonType = Definitions.DefaultComparisonType)
    {
      return result.GetFactsInternal(code, comparisonType).ToList().AsReadOnly();
    }

    private IEnumerable<Fact> GetFactsInternal(
      string code,
      StringComparison comparisonType)
    {
      return result.PeekStatements()?.PeekFacts()?.Where(f => f.HasCode(code, comparisonType)) ?? [];
    }

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
      return result.PeekStatements()?.PeekWarnings()?.Any(p => p.HasCode(code, comparisonType)) ?? false;
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
      return result.PeekStatements()?.PeekWarnings()?.Where(w => w.HasCode(code, comparisonType)) ?? [];
    }
  }
}
