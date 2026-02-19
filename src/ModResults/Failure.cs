namespace ModResults;


/// <summary>
/// Contains failure info for a failed <see cref="Result"/> or <see cref="Result{TValue}"/>".
/// </summary>
public sealed class Failure
{
  private List<Error>? _errors;
  private List<Error> GetErrors()
  {
    return _errors ??= [];
  }

  /// <summary>
  /// Error collection.
  /// </summary>
  public IReadOnlyList<Error> Errors => GetErrors().AsReadOnly();

  public bool HasErrors()
  {
    return _errors is not null && _errors.Count > 0;
  }

  /// <summary>
  /// Type of failure.
  /// </summary>
  public FailureType Type { get; }

  //intended as single public constructor to be used from json deserialization
  public Failure(FailureType type, IReadOnlyList<Error> errors)
  {
    Type = type;
    if (errors.Count > 0)
    {
      _errors = new(errors);
    }
  }

  private Failure(FailureType type, IEnumerable<Error> errors)
  {
    Type = type;
    if (errors.Any())
    {
      _errors = new(errors);
    }
  }

  internal static Failure Create(FailureType type, IEnumerable<Error> errors)
  {
    return new Failure(type, errors);
  }
}
