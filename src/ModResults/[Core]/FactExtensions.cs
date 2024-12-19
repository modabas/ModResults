namespace ModResults;
public static class FactExtensions
{
  public static bool HasCode(this Fact fact, string code, StringComparison comparisonType)
  {
    return fact.Code?.Equals(code, comparisonType) ?? false;
  }
}
