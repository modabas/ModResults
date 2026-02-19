namespace ModResults;

public abstract class BaseResult : IModResult
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

  public bool HasStatements()
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
