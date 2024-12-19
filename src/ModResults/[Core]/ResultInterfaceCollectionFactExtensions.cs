using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceCollectionFactExtensions
{
  public static ReadOnlyCollection<Fact> GetFacts(this IEnumerable<IModResult> results)
  {
    return results.SelectMany(r => r.Statements.Facts).ToList().AsReadOnly();
  }

  public static bool HaveFact(this IEnumerable<IModResult> results, string code)
  {
    return results.HaveFact(code, Definitions.DefaultComparisonType);
  }

  public static bool HaveFact(this IEnumerable<IModResult> results, string code, StringComparison comparisonType)
  {
    return results.Select(r => r.HasFact(code, comparisonType)).Any(h => h);
  }

  public static bool HaveFact(this IEnumerable<IModResult> results, string code, out ReadOnlyCollection<Fact> facts)
  {
    return results.HaveFact(code, Definitions.DefaultComparisonType, out facts);
  }

  public static bool HaveFact(this IEnumerable<IModResult> results, string code, StringComparison comparisonType, out ReadOnlyCollection<Fact> facts)
  {
    facts = results.GetFacts(code, comparisonType);
    return facts.Count > 0;
  }

  public static ReadOnlyCollection<Fact> GetFacts(this IEnumerable<IModResult> results, string code)
  {
    return results.GetFacts(code, Definitions.DefaultComparisonType);
  }

  public static ReadOnlyCollection<Fact> GetFacts(this IEnumerable<IModResult> results, string code, StringComparison comparisonType)
  {
    return results.SelectMany(r => r.GetFacts(code, comparisonType)).ToList().AsReadOnly();
  }
}
