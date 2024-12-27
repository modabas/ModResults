namespace ModResults.Orleans;

[RegisterConverter]
public sealed class ResultSurrogateConverter :
  IConverter<Result, ResultSurrogate>
{
  public Result ConvertFromSurrogate(in ResultSurrogate surrogate)
  {
    return new Result(
        surrogate.IsOk,
        surrogate.Failure,
        surrogate.Statements);
  }

  public ResultSurrogate ConvertToSurrogate(in Result value)
  {
    return new ResultSurrogate()
    {
      Failure = value.Failure,
      IsOk = value.IsOk,
      Statements = value.Statements
    };
  }
}


[RegisterConverter]
public sealed class ResultSurrogateConverter<TValue> :
  IConverter<Result<TValue>, ResultSurrogate<TValue>>
  where TValue : notnull
{
  public Result<TValue> ConvertFromSurrogate(in ResultSurrogate<TValue> surrogate)
  {
    return new Result<TValue>(
        surrogate.Value,
        surrogate.Failure,
        surrogate.Statements);
  }

  public ResultSurrogate<TValue> ConvertToSurrogate(in Result<TValue> value)
  {
    return new ResultSurrogate<TValue>()
    {
      Failure = value.Failure,
      Value = value.Value,
      Statements = value.Statements
    };
  }
}
