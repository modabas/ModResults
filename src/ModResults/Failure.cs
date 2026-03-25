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

  /// <summary>
  /// Determines whether the current failure contains any errors without initializing the errors property.
  /// </summary>
  /// <returns><see langword="true"/> if the result contains at least one error; otherwise, <see langword="false"/>.</returns>

  public bool HasErrors()
  {
    return _errors is not null && _errors.Count > 0;
  }

  /// <summary>
  /// Gets the current collection of errors if it has been initialized.
  /// </summary>
  /// <returns>The current <see cref="Error"/> list instance if it has been initialized; otherwise, <see langword="null"/>.</returns>
  internal List<Error>? PeekErrors()
  {
    return _errors;
  }

  /// <summary>
  /// Type of failure.
  /// </summary>
  public FailureType Type { get; }

  //intended as single public constructor to be used from json deserialization
  public Failure(FailureType type, IReadOnlyList<Error>? errors)
  {
    Type = type;
    if (errors?.Count > 0)
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

  internal static Failure Create(FailureType type)
  {
    return new Failure(type, null);
  }
}
