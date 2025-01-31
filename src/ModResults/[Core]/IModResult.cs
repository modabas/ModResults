namespace ModResults;
public interface IModResult
{
  public bool IsOk { get; }
  public bool IsFailed { get; }
  public Statements Statements { get; }
}

public interface IModResult<TFailure> : IModResult
  where TFailure : class
{
  public TFailure? Failure { get; }
}

public interface IModResult<TValue, TFailure> : IModResult<TFailure>
  where TValue : notnull
  where TFailure : class
{
  public TValue? Value { get; }
}
