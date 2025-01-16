namespace ModResults;


/// <summary>
/// Contains failure info for a failed <see cref="Result"/> or <see cref="Result{TValue}"/>"/>
/// </summary>
public sealed class Failure
{
  private readonly List<Error> _errors = [];

  /// <summary>
  /// Error collection
  /// </summary>
  public IReadOnlyList<Error> Errors => _errors.AsReadOnly();

  /// <summary>
  /// Type of failure
  /// </summary>
  public FailureType Type { get; }

  //intended as single public constructor to be used from json deserialization
  public Failure(FailureType type, IReadOnlyList<Error> errors)
  {
    Type = type;
    _errors.AddRange(errors);
  }
}
