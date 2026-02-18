namespace ModResults;

public sealed class Statements : IStatements
{
  private List<Warning>? _warnings;
  private List<Warning> GetWarnings()
  {
    return _warnings ??= [];
  }

  /// <summary>
  /// Warning collection.
  /// </summary>
  public IReadOnlyList<Warning> Warnings => GetWarnings().AsReadOnly();

  private List<Fact>? _facts;
  private List<Fact> GetFacts()
  {
    return _facts ??= [];
  }

  /// <summary>
  /// Fact collection.
  /// </summary>
  public IReadOnlyList<Fact> Facts => GetFacts().AsReadOnly();

  /// <summary>
  /// Adds a <see cref="Warning"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="warning"></param>
  public void AddWarning(Warning warning)
  {
    GetWarnings().Add(warning);
  }

  /// <summary>
  /// Adds a collection of <see cref="Warning"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="warnings"></param>
  public void AddWarnings(IReadOnlyList<Warning> warnings)
  {
    GetWarnings().AddRange(warnings);
  }

  /// <summary>
  /// Adds a collection of <see cref="Warning"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="warnings"></param>
  public void AddWarnings(IEnumerable<Warning> warnings)
  {
    GetWarnings().AddRange(warnings);
  }

  /// <summary>
  /// Clears all warnings.
  /// </summary>
  public void ClearWarnings()
  {
    GetWarnings().Clear();
  }

  /// <summary>
  /// Adds a <see cref="Fact"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="fact"></param>
  public void AddFact(Fact fact)
  {
    GetFacts().Add(fact);
  }

  /// <summary>
  /// Adds a collection of <see cref="Fact"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="facts"></param>
  public void AddFacts(IReadOnlyList<Fact> facts)
  {
    GetFacts().AddRange(facts);
  }

  /// <summary>
  /// Adds a collection of <see cref="Fact"/> to the <see cref="Statements"/>.
  /// </summary>
  /// <param name="facts"></param>
  public void AddFacts(IEnumerable<Fact> facts)
  {
    GetFacts().AddRange(facts);
  }

  /// <summary>
  /// Clears all facts.
  /// </summary>
  public void ClearFacts()
  {
    GetFacts().Clear();
  }

  //intended as single public constructor to be used from json deserialization
  public Statements(IReadOnlyList<Fact> facts, IReadOnlyList<Warning> warnings)
  {
    GetFacts().AddRange(facts);
    GetWarnings().AddRange(warnings);
  }
}
