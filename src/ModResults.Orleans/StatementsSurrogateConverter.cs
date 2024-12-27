namespace ModResults.Orleans;

[RegisterConverter]
public sealed class StatementsSurrogateConverter :
  IConverter<Statements, StatementsSurrogate>
{
  public Statements ConvertFromSurrogate(in StatementsSurrogate surrogate)
  {
    return new Statements(
        surrogate.Facts,
        surrogate.Warnings);
  }

  public StatementsSurrogate ConvertToSurrogate(in Statements value)
  {
    return new StatementsSurrogate()
    {
      Facts = value.Facts,
      Warnings = value.Warnings
    };
  }
}
