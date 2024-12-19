namespace ModResults.Orleans;

[GenerateSerializer]
public struct StatementsSurrogate
{
  [Id(0)]
  public IReadOnlyList<Fact> Facts;
  [Id(1)]
  public IReadOnlyList<Warning> Warnings;
}
