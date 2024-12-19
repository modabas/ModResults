namespace ModResults;

public interface IStatements
{
  public IReadOnlyList<Warning> Warnings { get; }
  public void AddWarning(Warning warning);
  public void AddWarnings(IEnumerable<Warning> warnings);
  public void ClearWarnings();
  public IReadOnlyList<Fact> Facts { get; }
  public void AddFact(Fact facts);
  public void AddFacts(IEnumerable<Fact> facts);
  public void ClearFacts();
}
