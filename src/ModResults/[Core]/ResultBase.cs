namespace ModResults;

public abstract class ResultBase : IModResult
{
  public abstract bool IsOk { get; init; }

  public abstract bool IsFailed { get; }

  protected Statements? _statements;
  protected Statements GetStatements()
  {
    return _statements ??= new(Definitions.EmptyFacts, Definitions.EmptyWarnings);
  }

  /// <summary>
  /// Contains facts and warnings for the result.
  /// </summary>
  public Statements Statements { get { return GetStatements(); } init { _statements = value; } }

  internal bool HasStatements()
  {
    return _statements is not null;
  }

  public bool HasFacts()
  {
    return HasStatements() && GetStatements().HasFacts();
  }

  public bool HasWarnings()
  {
    return HasStatements() && GetStatements().HasWarnings();
  }
}

public abstract class ResultBase<TFailure> : ResultBase, IModResult<TFailure>
  where TFailure : notnull
{
  public abstract TFailure? Failure { get; init; }
}

public abstract class ResultBase<TValue, TFailure> : ResultBase<TFailure>, IModResult<TValue, TFailure>
  where TValue : notnull
  where TFailure : notnull
{
  public abstract TValue? Value { get; init; }
}
