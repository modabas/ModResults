namespace ModResults.Orleans;

[RegisterConverter]
public sealed class FailedResultSurrogateConverter :
  IConverter<FailedResult, FailedResultSurrogate>
{
  public FailedResult ConvertFromSurrogate(in FailedResultSurrogate surrogate)
  {
    return new FailedResult(
      surrogate.Failure,
      surrogate.Statements);
  }

  public FailedResultSurrogate ConvertToSurrogate(in FailedResult value)
  {
    return new FailedResultSurrogate()
    {
      Failure = value.Failure,
      Statements = value.HasStatements() ? value.Statements : null
    };
  }
}
