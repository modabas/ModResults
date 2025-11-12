namespace ModResults;

public static class WarningExtensions
{
  /// <summary>
  /// Determines whether the <see cref="Warning"/> has a specified code.
  /// </summary>
  /// <param name="warning"></param>
  /// <param name="code">Warning code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HasCode(this Warning warning, string code, StringComparison comparisonType)
  {
    return warning.Code?.Equals(code, comparisonType) ?? false;
  }
}
