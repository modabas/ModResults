namespace ModResults;

internal class Definitions
{
  public const StringComparison DefaultComparisonType = StringComparison.Ordinal;

  public static readonly IReadOnlyList<Error> EmptyErrors = [];
  public static readonly IReadOnlyList<Fact> EmptyFacts = [];
  public static readonly IReadOnlyList<Warning> EmptyWarnings = [];
}
