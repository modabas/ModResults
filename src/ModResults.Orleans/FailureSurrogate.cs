namespace ModResults.Orleans;

[GenerateSerializer]
[Alias("ModResults.Orleans.FailureSurrogate")]
public struct FailureSurrogate
{
  [Id(0)]
  public FailureType Type;
  [Id(1)]
  public IReadOnlyList<Error> Errors;
}
