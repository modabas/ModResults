namespace ModResults.Orleans;

internal class Definitions
{
  public static readonly IReadOnlyList<Error> EmptyErrors = [];
  public static readonly IReadOnlyList<Fact> EmptyFacts = [];
  public static readonly IReadOnlyList<Warning> EmptyWarnings = [];
  public static readonly Statements EmptyStatements = new(EmptyFacts, EmptyWarnings);
}
