using System.Diagnostics.CodeAnalysis;

namespace ModResults;

public abstract class BaseResultWithFailure : BaseResult<Failure>, IModResult<Failure>
{
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public override bool IsOk { get; init; }

  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public override bool IsFailed => !IsOk;

  /// <summary>
  /// Contains failure info for a failed result instance. Not null when <see cref="IsFailed"/> is true.
  /// </summary>
  public override Failure? Failure { get; init; }

  /// <summary>
  /// Checks if the result is failed with a specific <see cref="FailureType"/>.
  /// </summary>
  /// <param name="failureType"></param>
  /// <returns></returns>
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailedWith(FailureType failureType)
  {
    return IsFailed && Failure.Type == failureType;
  }

  /// <summary>
  /// Checks if the result has an <see cref="ModResults.Error"/> with the specified code.
  /// </summary>
  /// <param name="errorCode">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailedWith(
    string errorCode,
    StringComparison comparisonType = Definitions.DefaultComparisonType)
  {
    return IsFailed && this.HasError(errorCode, comparisonType);
  }

  /// <summary>
  /// Checks if the result has an <see cref="ModResults.Error"/> constructed from an exception of the specified type.
  /// </summary>
  /// <typeparam name="TException"></typeparam>
  /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailedWith<TException>(
    bool includeAssignableTo = false)
    where TException : Exception
  {
    return IsFailed && this.HasErrorWithException<TException>(includeAssignableTo);
  }

  /// <summary>
  /// Checks if the result has an <see cref="ModResults.Error"/> constructed from an exception of the specified type.
  /// </summary>
  /// <param name="exceptionType">Exception type</param>
  /// <param name="includeAssignableTo">If true, checks whether input exception type is assignable from exception contained by error instance. If false, only checks for exact match.</param>
  /// <returns></returns>
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public bool IsFailedWith(
    Type exceptionType,
    bool includeAssignableTo = false)
  {
    return IsFailed && this.HasErrorWithException(exceptionType, includeAssignableTo);
  }
}

public abstract class BaseResultWithFailure<TValue> : BaseResultWithFailure, IModResult<TValue, Failure>
  where TValue : notnull
{
  [MemberNotNullWhen(returnValue: true, nameof(Value))]
  [MemberNotNullWhen(returnValue: false, nameof(Failure))]
  public override bool IsOk { get; init; }

  [MemberNotNullWhen(returnValue: false, nameof(Value))]
  [MemberNotNullWhen(returnValue: true, nameof(Failure))]
  public override bool IsFailed => !IsOk;

  /// <summary>
  /// Contains encapsulated value for a result instance in ok state. Not null when <see cref="IsOk"/> is true.
  /// </summary>
  public virtual TValue? Value { get; init; }

  /// <summary>
  /// Contains failure info for a result instance in failed state. Not null when <see cref="IsFailed"/> is true.
  /// </summary>
  public override Failure? Failure { get; init; }
}
