namespace ModResults;

public static partial class ResultWarningExtensions
{
  extension<TValue, TFailure>(Result<TValue, TFailure> result)
    where TValue : notnull
    where TFailure : notnull
  {
    public Result<TValue, TFailure> WithWarnings(
    IReadOnlyList<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    public Result<TValue, TFailure> WithWarnings(
      IEnumerable<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    public Result<TValue, TFailure> WithWarnings(
      IEnumerable<string> messages)
    {
      result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
      return result;
    }

    public Result<TValue, TFailure> WithWarningsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasWarnings())
      {
        result.WithWarnings(fromResult.Statements.Warnings);
      }
      return result;
    }

    public Result<TValue, TFailure> WithWarning(
      Warning warning)
    {
      result.Statements.AddWarning(warning);
      return result;
    }

    public Result<TValue, TFailure> WithWarning(
      string message)
    {
      result.Statements.AddWarning(new Warning(message));
      return result;
    }
  }
}
