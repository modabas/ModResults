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
    if (statements.HasFacts())
    {
      result = result.WithFacts(statements.Facts);
    }
    if (statements.HasWarnings())
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
    ResultBase fromResult)
  {
    if (fromResult.HasStatements())
    {
      return result.WithStatements(fromResult.Statements);
    }
    return result;
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
    if (statements.HasFacts())
    {
      result = result.WithFacts(statements.Facts);
    }
    if (statements.HasWarnings())
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
    ResultBase fromResult)
    where TValue : notnull
  {
    if (fromResult.HasStatements())
    {
      return result.WithStatements(fromResult.Statements);
    }
    return result;
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
    if (statements.HasFacts())
    {
      result = result.WithFacts(statements.Facts);
    }
    if (statements.HasWarnings())
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
    ResultBase fromResult)
    where TValue : notnull
    where TFailure : notnull
  {
    if (fromResult.HasStatements())
    {
      return result.WithStatements(fromResult.Statements);
    }
    return result;
  }
}
