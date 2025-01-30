namespace ModResults.Orleans;

[GenerateSerializer]
[Alias("ModResults.Orleans.ErrorSurrogate")]
public struct ErrorSurrogate
{
  [Id(0)]
  public Error? InnerError;
  [Id(1)]
  public string Message;
  [Id(2)]
  public string? ExceptionTypeName;
  [Id(3)]
  public string? Code;
  [Id(4)]
  public string? PropertyName;
}
