namespace ModResults.Orleans.Tests;

[GenerateSerializer]
[Alias("ModResults.Orleans.Tests.ValueStruct")]
internal struct ValueStruct
{
  [Id(0)]
  public int Number { get; set; }
  [Id(1)]
  public string String { get; set; }
}

