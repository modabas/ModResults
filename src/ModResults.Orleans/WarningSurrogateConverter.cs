namespace ModResults.Orleans;

[RegisterConverter]
public sealed class WarningSurrogateConverter : IConverter<Warning, WarningSurrogate>,
  IPopulator<Warning, WarningSurrogate>
{
  public Warning ConvertFromSurrogate(in WarningSurrogate surrogate) =>
      new(surrogate.Message, surrogate.Code);

  public WarningSurrogate ConvertToSurrogate(in Warning value) =>
      new()
      {
        Message = value.Message,
        Code = value.Code,
      };

  public void Populate(in WarningSurrogate surrogate, Warning value)
  {
    value.Message = surrogate.Message;
    value.Code = surrogate.Code;
  }
}
