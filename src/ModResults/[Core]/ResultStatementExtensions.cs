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
    return result.WithFacts(statements.Facts).WithWarnings(statements.Warnings);
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
    return result.WithFacts(statements.Facts).WithWarnings(statements.Warnings);
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
    where TFailure : class
  {
    return result.WithFacts(statements.Facts).WithWarnings(statements.Warnings);
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
    where TFailure : class
  {
    return result.WithStatements(fromResult.Statements);
  }
}
