namespace ModResults;

public sealed class Statements : IStatements
{
  private readonly List<Warning> _warnings = [];
  public IReadOnlyList<Warning> Warnings => _warnings.AsReadOnly();

  private readonly List<Fact> _facts = [];
  public IReadOnlyList<Fact> Facts => _facts.AsReadOnly();

  public void AddWarning(Warning warning)
  {
    _warnings.Add(warning);
  }

  public void AddWarnings(IEnumerable<Warning> warnings)
  {
    _warnings.AddRange(warnings);
  }

  public void ClearWarnings()
  {
    _warnings.Clear();
  }

  public void AddFact(Fact fact)
  {
    _facts.Add(fact);
  }

  public void AddFacts(IEnumerable<Fact> facts)
  {
    _facts.AddRange(facts);
  }

  public void ClearFacts()
  {
    _facts.Clear();
  }

  //intended as single public constructor to be used from json deserialization
  public Statements(IReadOnlyList<Fact> facts, IReadOnlyList<Warning> warnings)
  {
    _facts.AddRange(facts);
    _warnings.AddRange(warnings);
  }
}
