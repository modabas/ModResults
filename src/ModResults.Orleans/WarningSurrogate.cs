namespace ModResults.Orleans;

[GenerateSerializer]
public struct WarningSurrogate
{
  [Id(0)]
  public string Message;
  [Id(1)]
  public string? Code;
}
