namespace ModResults;

public abstract class BaseResult : IModResult
{
  /// <summary>
  /// Gets if state of result instance is Ok.
  /// </summary>
  public abstract bool IsOk { get; init; }

  /// <summary>
  /// Gets if state of result instance is Failed.
  /// </summary>
  public abstract bool IsFailed { get; }

  private Statements? _statements;
  private Statements GetStatements()
  {
    return _statements ??= new(null, null);
  }

  private void SetStatements(Statements? statements)
  {
    // If the provided statements is null or does not contain any facts or warnings,
    // we set the _statements field to null to avoid unnecessary memory allocation.
    if (statements is null ||
      !(statements.HasWarnings() || statements.HasFacts()))
    {
      _statements = null;
      return;
    }
    _statements = statements;
    return;
  }

  /// <summary>
  /// Contains facts and warnings for the result.
  /// </summary>
  public Statements Statements
  {
    get => GetStatements();
    init => SetStatements(value);
  }

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
  /// Gets the current collection of statements if it has been initialized.
  /// </summary>
  /// <returns>The current <see cref="Statements"/> instance if it has been initialized; otherwise, <see langword="null"/>.</returns>
  internal Statements? PeekStatements()
  {
    return _statements;
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
