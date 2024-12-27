namespace ModResults.Orleans;

[RegisterConverter]
public sealed class ErrorSurrogateConverter : IConverter<Error, ErrorSurrogate>,
  IPopulator<Error, ErrorSurrogate>
{
  public Error ConvertFromSurrogate(in ErrorSurrogate surrogate) =>
      new(surrogate.Message,
          surrogate.ExceptionTypeName,
          surrogate.InnerError,
          surrogate.Code,
          surrogate.PropertyName);

  public ErrorSurrogate ConvertToSurrogate(in Error value) =>
      new()
      {
        ExceptionTypeName = value.ExceptionTypeName,
        InnerError = value.InnerError,
        Message = value.Message,
        Code = value.Code,
        PropertyName = value.PropertyName
      };

  public void Populate(in ErrorSurrogate surrogate, Error value)
  {
    value.InnerError = surrogate.InnerError;
    value.ExceptionTypeName = surrogate.ExceptionTypeName;
    value.Message = surrogate.Message;
    value.Code = surrogate.Code;
    value.PropertyName = surrogate.PropertyName;
  }
}
