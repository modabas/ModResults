namespace ModResults.Orleans.Tests;

[GenerateSerializer]
internal class FactChild : Fact
{
  [Id(0)]
  public string Extra { get; init; }
  public FactChild(string message, string? code, string extra) : base(message, code)
  {
    Extra = extra;
  }
}
