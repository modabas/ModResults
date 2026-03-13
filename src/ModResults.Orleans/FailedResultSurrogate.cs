namespace ModResults.Orleans;

[GenerateSerializer]
[Alias("ModResults.Orleans.FailedResultSurrogate")]
public struct FailedResultSurrogate
{
  [Id(0)]
  public Failure Failure;

  [Id(1)]
  public Statements? Statements;
}
