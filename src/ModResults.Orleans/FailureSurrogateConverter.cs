namespace ModResults.Orleans;

[RegisterConverter]
public sealed class FailureSurrogateConverter :
    IConverter<Failure, FailureSurrogate>
{
  public Failure ConvertFromSurrogate(in FailureSurrogate surrogate)
  {
    return new Failure(
        surrogate.Type,
        surrogate.Errors);
  }

  public FailureSurrogate ConvertToSurrogate(in Failure value)
  {
    return new FailureSurrogate()
    {
      Type = value.Type,
      Errors = value.Errors
    };
  }
}
