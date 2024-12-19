namespace ModResults.Orleans;

[GenerateSerializer]
public struct FactSurrogate
{
  [Id(0)]
  public string Message;
  [Id(1)]
  public string? Code;
}
