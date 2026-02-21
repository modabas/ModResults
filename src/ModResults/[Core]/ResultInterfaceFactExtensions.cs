using System.Collections.ObjectModel;

namespace ModResults;

public static class ResultInterfaceFactExtensions
{
  extension(BaseResult result)
  {
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
      return result.HasFacts() && result.Statements.Facts.Any(f => f.HasCode(code, comparisonType));
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
      if (result.HasFacts())
      {
        return result.Statements.Facts.Where(f => f.HasCode(code, comparisonType));
      }
      return [];
    }
  }
}
