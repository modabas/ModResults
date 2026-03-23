using System.Diagnostics.CodeAnalysis;

namespace ModResults;

public abstract class BaseBusinessResult<TSelf> : BaseResult<Failure>, IModResult<Failure>
  where TSelf : BaseBusinessResult<TSelf>
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

  /// <summary>
  /// Adds a collection of <see cref="Fact"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="facts"></param>
  /// <returns></returns>
  public TSelf WithFacts(
    IReadOnlyList<Fact> facts)
  {
    Statements.AddFacts(facts);
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a collection of <see cref="Fact"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="facts"></param>
  /// <returns></returns>
  public TSelf WithFacts(
    IEnumerable<Fact> facts)
  {
    Statements.AddFacts(facts);
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a collection of string messages as a collection of <see cref="Fact"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="messages"></param>
  /// <returns></returns>
  public TSelf WithFacts(
    IEnumerable<string> messages)
  {
    Statements.AddFacts(messages.Select(m => new Fact(m)));
    return (TSelf)this;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s of another result object.
  /// </summary>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public TSelf WithFactsFrom(
    BaseResult fromResult)
  {
    if (fromResult.HasFacts())
    {
      WithFacts(fromResult.Statements.Facts);
    }
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a <see cref="Fact"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="fact"></param>
  /// <returns></returns>
  public TSelf WithFact(Fact fact)
  {
    Statements.AddFact(fact);
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a string message as a <see cref="Fact"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="message"></param>
  /// <returns></returns>
  public TSelf WithFact(string message)
  {
    Statements.AddFact(new Fact(message));
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a collection of <see cref="Warning"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="warnings"></param>
  /// <returns></returns>
  public TSelf WithWarnings(
    IReadOnlyList<Warning> warnings)
  {
    Statements.AddWarnings(warnings);
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a collection of <see cref="Warning"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="warnings"></param>
  /// <returns></returns>
  public TSelf WithWarnings(
    IEnumerable<Warning> warnings)
  {
    Statements.AddWarnings(warnings);
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a collection of string messages as a collection of <see cref="Warning"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="messages"></param>
  /// <returns></returns>
  public TSelf WithWarnings(
    IEnumerable<string> messages)
  {
    Statements.AddWarnings(messages.Select(m => new Warning(m)));
    return (TSelf)this;
  }

  /// <summary>
  /// Adds all <see cref="Warning"/>s of another result object.
  /// </summary>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public TSelf WithWarningsFrom(
    BaseResult fromResult)
  {
    if (fromResult.HasWarnings())
    {
      WithWarnings(fromResult.Statements.Warnings);
    }
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a <see cref="Warning"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="warning"></param>
  /// <returns></returns>
  public TSelf WithWarning(Warning warning)
  {
    Statements.AddWarning(warning);
    return (TSelf)this;
  }

  /// <summary>
  /// Adds a string message as a <see cref="Warning"/> to the <see cref="BaseBusinessResult{TSelf}"/>.
  /// </summary>
  /// <param name="message"></param>
  /// <returns></returns>
  public TSelf WithWarning(string message)
  {
    Statements.AddWarning(new Warning(message));
    return (TSelf)this;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
  /// </summary>
  /// <param name="statements"></param>
  /// <returns></returns>
  public TSelf WithStatements(
    Statements statements)
  {
    if (statements.HasFacts())
    {
      WithFacts(statements.Facts);
    }
    if (statements.HasWarnings())
    {
      WithWarnings(statements.Warnings);
    }
    return (TSelf)this;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of another result object.
  /// </summary>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public TSelf WithStatementsFrom(
    BaseResult fromResult)
  {
    if (fromResult.HasStatements())
    {
      return WithStatements(fromResult.Statements);
    }
    return (TSelf)this;
  }
}

public abstract class BaseBusinessResult<TSelf, TValue> : BaseBusinessResult<TSelf>, IModResult<TValue, Failure>
  where TSelf : BaseBusinessResult<TSelf, TValue>
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
