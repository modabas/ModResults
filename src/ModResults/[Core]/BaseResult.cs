namespace ModResults;

public abstract class BaseResult : IModResult
{
  public abstract bool IsOk { get; init; }

  public abstract bool IsFailed { get; }

  private Statements? _statements;
  private Statements GetStatements()
  {
    return _statements ??= new(null, null);
  }

  protected void SetStatements(Statements? statements)
  {
    if (statements is null)
    {
      _statements = null;
      return;
    }
    if (statements.HasWarnings() || statements.HasFacts())
    {
      _statements = statements;
      return;
    }
    _statements = null;
    return;
  }

  /// <summary>
  /// Contains facts and warnings for the result.
  /// </summary>
  public Statements Statements => GetStatements();

  /// <summary>
  /// Determines whether the current result has its statement property initialized.
  /// </summary>
  /// <returns><see langword="true"/> if statements property has already been initialized; otherwise, <see
  /// langword="false"/>.</returns>
  public bool HasStatements()
  {
    return _statements is not null;
  }

  /// <summary>
  /// Determines whether the current result contains any facts under statements property without initializing the statements property or its facts property.
  /// </summary>
  /// <returns><see langword="true"/> if the result contains at least one fact; otherwise, <see langword="false"/>.</returns>
  public bool HasFacts()
  {
    return HasStatements() && GetStatements().HasFacts();
  }

  /// <summary>
  /// Determines whether the current result contains any warnings under statements property without initializing the statements property or its warnings property.
  /// </summary>
  /// <returns><see langword="true"/> if the result contains at least one warning; otherwise, <see langword="false"/>.</returns>
  public bool HasWarnings()
  {
    return HasStatements() && GetStatements().HasWarnings();
  }
}

public abstract class BaseResult<TFailure> : BaseResult, IModResult<TFailure>
  where TFailure : notnull
{
  public abstract TFailure? Failure { get; init; }
}

public abstract class BaseResult<TValue, TFailure> : BaseResult<TFailure>, IModResult<TValue, TFailure>
  where TValue : notnull
  where TFailure : notnull
{
  public abstract TValue? Value { get; init; }
}
