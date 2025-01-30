namespace ModResults.Orleans;

[GenerateSerializer]
[Alias("ModResults.Orleans.FactSurrogate")]
public struct FactSurrogate
{
  [Id(0)]
  public string Message;
  [Id(1)]
  public string? Code;
}
