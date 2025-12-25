namespace ModResults;

public static class FactExtensions
{
  /// <summary>
  /// Determines whether the <see cref="Fact"/> has a specific code.
  /// </summary>
  /// <param name="fact"></param>
  /// <param name="code">Fact code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HasCode(this Fact fact, string code, StringComparison comparisonType)
  {
    return fact.Code?.Equals(code, comparisonType) ?? false;
  }
}
