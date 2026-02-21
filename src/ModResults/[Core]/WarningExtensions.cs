namespace ModResults;

public static class WarningExtensions
{
  extension(Warning warning)
  {
    /// <summary>
    /// Determines whether the <see cref="Warning"/> has a specified code.
    /// </summary>
    /// <param name="code">Warning code to check for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
    /// <returns></returns>
    public bool HasCode(string code, StringComparison comparisonType)
    {
      return warning.Code?.Equals(code, comparisonType) ?? false;
    }
  }
}
