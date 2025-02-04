namespace ModResults.Orleans.Tests;

[GenerateSerializer]
internal class ErrorChild : Error
{
  [Id(0)]
  public string Extra { get; init; }

  public ErrorChild(string errorMessage, string? code, string extra) : base(errorMessage, code: code)
  {
    Extra = extra;
  }
}
