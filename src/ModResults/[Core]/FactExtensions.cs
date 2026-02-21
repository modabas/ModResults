namespace ModResults;

public static class FactExtensions
{
  extension(Fact fact)
  {
    /// <summary>
    /// Determines whether the <see cref="Fact"/> has a specific code.
    /// </summary>
    /// <param name="code">Fact code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasCode(string code, StringComparison comparisonType)
    {
      return fact.Code?.Equals(code, comparisonType) ?? false;
    }
  }
}
