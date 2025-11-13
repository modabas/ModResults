namespace ModResults;

public static class ResultStatementExtensions
{
  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="statements"></param>
  /// <returns></returns>
  public static Result WithStatements(
    this Result result,
    Statements statements)
  {
    if (statements.Facts.Count > 0)
    {
      result = result.WithFacts(statements.Facts);
    }
    if (statements.Warnings.Count > 0)
    {
      result = result.WithWarnings(statements.Warnings);
    }
    return result;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of another result object.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public static Result WithStatementsFrom(
    this Result result,
    IModResult fromResult)
  {
    return result.WithStatements(fromResult.Statements);
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="statements"></param>
  /// <returns></returns>
  public static Result<TValue> WithStatements<TValue>(
    this Result<TValue> result,
    Statements statements)
    where TValue : notnull
  {
    if (statements.Facts.Count > 0)
    {
      result = result.WithFacts(statements.Facts);
    }
    if (statements.Warnings.Count > 0)
    {
      result = result.WithWarnings(statements.Warnings);
    }
    return result;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of another result object.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public static Result<TValue> WithStatementsFrom<TValue>(
    this Result<TValue> result,
    IModResult fromResult)
    where TValue : notnull
  {
    return result.WithStatements(fromResult.Statements);
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <typeparam name="TFailure"></typeparam>
  /// <param name="result"></param>
  /// <param name="statements"></param>
  /// <returns></returns>
  public static Result<TValue, TFailure> WithStatements<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    Statements statements)
    where TValue : notnull
    where TFailure : notnull
  {
    if (statements.Facts.Count > 0)
    {
      result = result.WithFacts(statements.Facts);
    }
    if (statements.Warnings.Count > 0)
    {
      result = result.WithWarnings(statements.Warnings);
    }
    return result;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of another result object.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <typeparam name="TFailure"></typeparam>
  /// <param name="result"></param>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public static Result<TValue, TFailure> WithStatementsFrom<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IModResult fromResult)
    where TValue : notnull
    where TFailure : notnull
  {
    return result.WithStatements(fromResult.Statements);
  }
}
