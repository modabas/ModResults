namespace ModResults.Orleans;

[GenerateSerializer]
[Alias("ModResults.Orleans.ResultSurrogate")]
public struct ResultSurrogate
{
  [Id(0)]
  public Failure? Failure;

  [Id(1)]
  public Statements Statements;
}

[GenerateSerializer]
[Alias("ModResults.Orleans.ResultSurrogate`1")]
public struct ResultSurrogate<TValue>
{
  [Id(0)]
  public TValue? Value;

  [Id(1)]
  public Failure? Failure;

  [Id(2)]
  public Statements Statements;
}
