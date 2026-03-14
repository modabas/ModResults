namespace ModResults.Orleans;

[GenerateSerializer]
[Alias("ModResults.Orleans.FailureResultSurrogate")]
public struct FailureResultSurrogate
{
  [Id(0)]
  public Failure Failure;

  [Id(1)]
  public Statements? Statements;
}
