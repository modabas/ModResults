namespace ModResults.Orleans.Tests;

[GenerateSerializer]
internal class WarningChild : Warning
{
  [Id(0)]
  public string Extra { get; init; }
  public WarningChild(string message, string? code, string extra) : base(message, code)
  {
    Extra = extra;
  }
}
