namespace ModResults;
public interface IModResult
{
  public bool IsOk { get; }
  public bool IsFailed { get; }
  public Statements Statements { get; }
}

public interface IModResult<TFailure> : IModResult
  where TFailure : notnull
{
  public TFailure? Failure { get; }
}

public interface IModResult<TValue, TFailure> : IModResult<TFailure>
  where TValue : notnull
  where TFailure : notnull
{
  public TValue? Value { get; }
}
