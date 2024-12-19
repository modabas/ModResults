namespace ModResults;
public static class WarningExtensions
{
  public static bool HasCode(this Warning warning, string code, StringComparison comparisonType)
  {
    return warning.Code?.Equals(code, comparisonType) ?? false;
  }
}
