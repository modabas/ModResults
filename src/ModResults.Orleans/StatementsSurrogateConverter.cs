namespace ModResults.Orleans;

[RegisterConverter]
public sealed class StatementsSurrogateConverter :
  IConverter<Statements, StatementsSurrogate>
{
  public Statements ConvertFromSurrogate(in StatementsSurrogate surrogate)
  {
    return new Statements(
        surrogate.Facts ?? Definitions.EmptyFacts,
        surrogate.Warnings ?? Definitions.EmptyWarnings);
  }

  public StatementsSurrogate ConvertToSurrogate(in Statements value)
  {
    return new StatementsSurrogate()
    {
      Facts = value.HasFacts() ? value.Facts : null,
      Warnings = value.HasWarnings() ? value.Warnings : null
    };
  }
}
