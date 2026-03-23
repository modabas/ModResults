namespace ModResults;

public sealed class Statements
{
  private List<Warning>? _warnings;
  private List<Warning> GetWarnings()
  {
    return _warnings ??= [];
  }

  /// <summary>
  /// Gets a read-only list of warnings associated with the current statements instance.
  /// </summary>
  public IReadOnlyList<Warning> Warnings => GetWarnings().AsReadOnly();

  /// <summary>
  /// Determines whether the current statement contains any warnings without initializing the warnings property.
  /// </summary>
  /// <returns><see langword="true"/> if the result contains at least one warning; otherwise, <see langword="false"/>.</returns>

  public bool HasWarnings()
  {
    return _warnings is not null && _warnings.Count > 0;
  }

  private List<Fact>? _facts;
  private List<Fact> GetFacts()
  {
    return _facts ??= [];
  }


  /// <summary>
  /// Gets a read-only collection of facts associated with the current statements instance.
  /// </summary>
  public IReadOnlyList<Fact> Facts => GetFacts().AsReadOnly();

  /// <summary>
  /// Determines whether the current statement contains any facts without initializing the facts property.
  /// </summary>
  /// <returns><see langword="true"/> if the result contains at least one fact; otherwise, <see langword="false"/>.</returns>
  public bool HasFacts()
  {
    return _facts is not null && _facts.Count > 0;
  }

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
    _warnings = null;
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
    _facts = null;
  }

  //intended as single public constructor to be used from json deserialization
  public Statements(IReadOnlyList<Fact>? facts, IReadOnlyList<Warning>? warnings)
  {
    if (facts?.Count > 0)
    {
      _facts = new(facts);
    }
    if (warnings?.Count > 0)
    {
      _warnings = new(warnings);
    }
  }
}
