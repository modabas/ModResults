namespace ModResults;

public sealed class Failure
{
  private readonly List<Error> _errors = [];
  public IReadOnlyList<Error> Errors => _errors.AsReadOnly();
  public FailureType Type { get; }

  //intended as single public constructor to be used from json deserialization
  public Failure(FailureType type, IReadOnlyList<Error> errors)
  {
    Type = type;
    _errors.AddRange(errors);
  }
}
