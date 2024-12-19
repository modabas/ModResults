using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceFactExtensions
{
  public static bool HasFact(this IModResult result, string code)
  {
    return result.HasFact(code, Definitions.DefaultComparisonType);
  }

  public static bool HasFact(this IModResult result, string code, StringComparison comparisonType)
  {
    return result.Statements.Facts.Any(f => f.HasCode(code, comparisonType));
  }

  public static bool HasFact(this IModResult result, string code, out ReadOnlyCollection<Fact> facts)
  {
    return result.HasFact(code, Definitions.DefaultComparisonType, out facts);
  }

  public static bool HasFact(this IModResult result, string code, StringComparison comparisonType, out ReadOnlyCollection<Fact> facts)
  {
    facts = result.GetFacts(code, comparisonType);
    return facts.Count > 0;
  }

  public static ReadOnlyCollection<Fact> GetFacts(this IModResult result, string code)
  {
    return result.GetFacts(code, Definitions.DefaultComparisonType);
  }

  public static ReadOnlyCollection<Fact> GetFacts(this IModResult result, string code, StringComparison comparisonType)
  {
    return result.GetFactsInternal(code, comparisonType).ToList().AsReadOnly();
  }

  private static IEnumerable<Fact> GetFactsInternal(this IModResult result, string code, StringComparison comparisonType)
  {
    return result.Statements.Facts.Where(f => f.HasCode(code, comparisonType));
  }
}
