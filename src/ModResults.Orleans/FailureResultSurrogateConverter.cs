namespace ModResults.Orleans;

[RegisterConverter]
public sealed class FailureResultSurrogateConverter :
  IConverter<FailureResult, FailureResultSurrogate>
{
  public FailureResult ConvertFromSurrogate(in FailureResultSurrogate surrogate)
  {
    return new FailureResult(
      surrogate.Failure,
      surrogate.Statements);
  }

  public FailureResultSurrogate ConvertToSurrogate(in FailureResult value)
  {
    return new FailureResultSurrogate()
    {
      Failure = value.Failure,
      Statements = value.PeekStatements()
    };
  }
}
