namespace ModResults;

public static partial class ResultStatementExtensions
{
  extension(Result result)
  {
    /// <summary>
    /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
    /// </summary>
    /// <param name="statements"></param>
    /// <returns></returns>
    public Result WithStatements(
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
    public Result WithStatementsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasStatements())
      {
        return result.WithStatements(fromResult.Statements);
      }
      return result;
    }
  }

  extension<TValue>(Result<TValue> result) where TValue : notnull
  {
    /// <summary>
    /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
    /// </summary>
    /// <param name="statements"></param>
    /// <returns></returns>
    public Result<TValue> WithStatements(
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
    public Result<TValue> WithStatementsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasStatements())
      {
        return result.WithStatements(fromResult.Statements);
      }
      return result;
    }
  }

  extension(FailureResult result)
  {
    /// <summary>
    /// Adds all <see cref="Fact"/>s and <see cref="Warning"/>s of a <see cref="Statements"/> object.
    /// </summary>
    /// <param name="statements"></param>
    /// <returns></returns>
    public FailureResult WithStatements(
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
    public FailureResult WithStatementsFrom(
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
