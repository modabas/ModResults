namespace ModResults;

public static partial class ResultStatementExtensions
{
  extension<TValue, TFailure>(Result<TValue, TFailure> result)
    where TValue : notnull
    where TFailure : notnull
  {
    /// <summary>
    /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
    /// </summary>
    /// <param name="statements"></param>
    /// <returns></returns>
    public Result<TValue, TFailure> WithStatements(
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
    /// <param name="fromResult"></param>
    /// <returns></returns>
    public Result<TValue, TFailure> WithStatementsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasStatements())
      {
        return result.WithStatements(fromResult.Statements);
      }
      return result;
    }
  }
}
