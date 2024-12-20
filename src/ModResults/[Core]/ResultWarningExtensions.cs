namespace ModResults;
public static partial class ResultWarningExtensions
{
  public static Result<TValue, TFailure> WithWarnings<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IEnumerable<Warning> warnings)
  {
    result.Statements.AddWarnings(warnings);
    return result;
  }

  public static Result<TValue, TFailure> WithWarnings<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IEnumerable<string> messages)
  {
    result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
    return result;
  }

  public static Result<TValue, TFailure> WithWarningsFrom<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IModResult fromResult)
  {
    result.WithWarnings(fromResult.Statements.Warnings);
    return result;
  }

  public static Result<TValue, TFailure> WithWarning<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    Warning warning)
  {
    result.Statements.AddWarning(warning);
    return result;
  }

  public static Result<TValue, TFailure> WithWarning<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    string message)
  {
    result.Statements.AddWarning(new Warning(message));
    return result;
  }
}
