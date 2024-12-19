namespace ModResults.Orleans;

[GenerateSerializer]
public struct ResultSurrogate
{
  [Id(0)]
  public bool IsOk;

  [Id(1)]
  public Failure? Failure;

  [Id(2)]
  public Statements Statements;
}

[GenerateSerializer]
public struct ResultSurrogate<TValue>
{
  [Id(0)]
  public TValue? Value;

  [Id(1)]
  public Failure? Failure;

  [Id(2)]
  public Statements Statements;
}
