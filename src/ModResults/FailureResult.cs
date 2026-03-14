using System.Diagnostics.CodeAnalysis;

namespace ModResults;


/// <summary>
/// A business result that represents the outcome of an operation that has failed, containing detailed failure and additional information.
/// </summary>
/// <remarks>Use the provided static factory methods to create instances of this class for failed operations. 
/// The failure details are always available and provide information about the reason for the failure. 
/// This class is mainly intended as helper for returning failed <see cref="Result{TValue}"/> instances without needing to specify TValue directly, using implicit conversion operators. 
/// It is also designed for easy conversion to both <see cref="Result"/> and <see cref="Result{TValue}"/> types, enabling seamless integration of failure information into result handling.</remarks>
public sealed class FailureResult : BaseModResult
{
  /// <summary>
  /// Contains failure info for <see cref="FailureResult"/> instance. Not null.
  /// </summary>
  [NotNull]
  public override Failure? Failure { get; init; }

  private FailureResult(FailureType failureType, IEnumerable<Error> errors)
  {
    IsOk = false;
    Failure = Failure.Create(failureType, errors);
  }

  private FailureResult(FailureType failureType)
  {
    IsOk = false;
    Failure = new Failure(failureType, null);
  }

  internal static FailureResult Create(FailureType failureType, IEnumerable<Error> errors)
  {
    return new(failureType, errors);
  }

  internal static FailureResult Create(FailureType failureType)
  {
    return new(failureType);
  }

  /// <summary>
  /// This constructor is intended as single public constructor to be used from Json deserialization.
  /// Use provided static methods to create instances of <see cref="FailureResult"/>.
  /// </summary>
  /// <param name="failure"></param>
  /// <param name="statements"></param>
  /// <exception cref="ArgumentNullException"></exception>
  public FailureResult(
    Failure? failure,
    Statements? statements)
  {
    //by design Failure cannot be null
    if (failure is null)
    {
      throw new ArgumentNullException(nameof(failure));
    }
    IsOk = false;
    Failure = failure;
    Statements = statements!;
  }

  /// <summary>
  /// Creates a failed <see cref="FailureResult"/> with failure type <see cref="FailureType.CriticalError"/> containing an error constructed from specified exception.
  /// </summary>
  /// <param name="exception">The <see cref="Exception"/> that will used to construct an error instance from.</param>
  public static implicit operator FailureResult(Exception exception)
  {
    return FailureResult.CriticalError(exception);
  }

  /// <summary>
  /// Creates a <see cref="FailureResult"/> in Failed state with input failure type.
  /// </summary>
  /// <param name="failureType">Failure type that will be encapsulated in a Failed <see cref="FailureResult"/>.</param>
  public static implicit operator FailureResult(FailureType failureType)
  {
    return new FailureResult(failureType);
  }
}
