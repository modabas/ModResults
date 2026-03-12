using System.Diagnostics.CodeAnalysis;

namespace ModResults;


/// <summary>
/// Represents the result of an operation that has failed, containing detailed failure information.
/// </summary>
/// <remarks>Use the provided static factory methods to create instances of this class for failed operations. 
/// The failure details are always available and provide information about the reason for the failure. 
/// This class is mainly intended as a helper class to be passes to implicit operator of <see cref="Result{TValue}"/> class for easy creation of failed results without specifying TValue type.</remarks>
public sealed class FailedResult : BaseResult<Failure>
{
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public override bool IsOk { get; init; }

  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public override bool IsFailed => !IsOk;

  /// <summary>
  /// Contains failure info for <see cref="FailedResult"/> instance. Not null.
  /// </summary>
  public override Failure? Failure { get; init; }

  private FailedResult(FailureType failureType, IEnumerable<Error> errors)
  {
    IsOk = false;
    Failure = Failure.Create(failureType, errors);
  }

  private FailedResult(FailureType failureType)
  {
    IsOk = false;
    Failure = new Failure(failureType, null);
  }

  internal static FailedResult Create(FailureType failureType, IEnumerable<Error> errors)
  {
    return new(failureType, errors);
  }

  internal static FailedResult Create(FailureType failureType)
  {
    return new(failureType);
  }

  /// <summary>
  /// This constructor is intended as single public constructor to be used from Json deserialization.
  /// Use provided static methods to create instances of <see cref="FailedResult"/>.
  /// </summary>
  /// <param name="failure"></param>
  /// <param name="statements"></param>
  /// <exception cref="ArgumentNullException"></exception>
  public FailedResult(
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
}
