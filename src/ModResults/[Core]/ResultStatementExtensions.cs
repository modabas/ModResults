namespace ModResults;
public static class ResultStatementExtensions
{
  public static Result WithStatements(
    this Result result,
    Statements statements)
  {
    return result.WithFacts(statements.Facts).WithWarnings(statements.Warnings);
  }

  public static Result WithStatementsFrom(
    this Result result,
    IModResult fromResult)
  {
    return result.WithStatements(fromResult.Statements);
  }

  public static Result<TValue> WithStatements<TValue>(
    this Result<TValue> result,
    Statements statements)
  {
    return result.WithFacts(statements.Facts).WithWarnings(statements.Warnings);
  }

  public static Result<TValue> WithStatementsFrom<TValue>(
    this Result<TValue> result,
    IModResult fromResult)
  {
    return result.WithStatements(fromResult.Statements);
  }

  public static Result<TValue, TFailure> WithStatements<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    Statements statements)
  {
    return result.WithFacts(statements.Facts).WithWarnings(statements.Warnings);
  }

  public static Result<TValue, TFailure> WithStatementsFrom<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IModResult fromResult)
  {
    return result.WithStatements(fromResult.Statements);
  }
}
