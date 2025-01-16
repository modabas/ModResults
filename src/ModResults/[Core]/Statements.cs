namespace ModResults;

public sealed class Statements : IStatements
{
  private readonly List<Warning> _warnings = [];
  /// <summary>
  /// Warning collection.
  /// </summary>
  public IReadOnlyList<Warning> Warnings => _warnings.AsReadOnly();

  private readonly List<Fact> _facts = [];
  /// <summary>
  /// Fact collection.
  /// </summary>
  public IReadOnlyList<Fact> Facts => _facts.AsReadOnly();

  /// <summary>
  /// Adds a <see cref="Warning"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="warning"></param>
  public void AddWarning(Warning warning)
  {
    _warnings.Add(warning);
  }

  /// <summary>
  /// Adds a collection of <see cref="Warning"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="warnings"></param>
  public void AddWarnings(IEnumerable<Warning> warnings)
  {
    _warnings.AddRange(warnings);
  }

  /// <summary>
  /// Clears all warnings.
  /// </summary>
  public void ClearWarnings()
  {
    _warnings.Clear();
  }

  /// <summary>
  /// Adds a <see cref="Fact"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="fact"></param>
  public void AddFact(Fact fact)
  {
    _facts.Add(fact);
  }

  /// <summary>
  /// Adds a collection of <see cref="Fact"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="facts"></param>
  public void AddFacts(IEnumerable<Fact> facts)
  {
    _facts.AddRange(facts);
  }

  /// <summary>
  /// Clears all facts.
  /// </summary>
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
