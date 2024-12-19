namespace ModResults;
public interface IModResult
{
  public bool IsOk { get; }
  public bool IsFailed { get; }
  public Statements Statements { get; }
}

public interface IModResult<TFailure> : IModResult
{
  public TFailure? Failure { get; }
}

public interface IModResult<TValue, TFailure> : IModResult<TFailure>
{
  public TValue? Value { get; }
}
