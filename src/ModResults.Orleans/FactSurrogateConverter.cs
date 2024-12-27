namespace ModResults.Orleans;

[RegisterConverter]
public sealed class FactSurrogateConverter : IConverter<Fact, FactSurrogate>,
  IPopulator<Fact, FactSurrogate>
{
  public Fact ConvertFromSurrogate(in FactSurrogate surrogate) =>
      new(surrogate.Message, surrogate.Code);

  public FactSurrogate ConvertToSurrogate(in Fact value) =>
      new()
      {
        Message = value.Message,
        Code = value.Code
      };

  public void Populate(in FactSurrogate surrogate, Fact value)
  {
    value.Message = surrogate.Message;
    value.Code = surrogate.Code;
  }
}
