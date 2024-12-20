namespace ModResults;
public static partial class ResultWarningExtensions
{
  public static Result WithWarnings(
    this Result result,
    IEnumerable<Warning> warnings)
  {
    result.Statements.AddWarnings(warnings);
    return result;
  }

  public static Result WithWarnings(
    this Result result,
    IEnumerable<string> messages)
  {
    result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
    return result;
  }

  public static Result WithWarningsFrom(
    this Result result,
    IModResult fromResult)
  {
    result.WithWarnings(fromResult.Statements.Warnings);
    return result;
  }

  public static Result<TValue> WithWarnings<TValue>(
    this Result<TValue> result,
    IEnumerable<Warning> warnings)
  {
    result.Statements.AddWarnings(warnings);
    return result;
  }

  public static Result<TValue> WithWarnings<TValue>(
    this Result<TValue> result,
    IEnumerable<string> messages)
  {
    result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
    return result;
  }

  public static Result<TValue> WithWarningsFrom<TValue>(
    this Result<TValue> result,
    IModResult fromResult)
  {
    result.WithWarnings(fromResult.Statements.Warnings);
    return result;
  }

  public static Result WithWarning(this Result result, Warning warning)
  {
    result.Statements.AddWarning(warning);
    return result;
  }

  public static Result WithWarning(this Result result, string message)
  {
    result.Statements.AddWarning(new Warning(message));
    return result;
  }

  public static Result<TValue> WithWarning<TValue>(
    this Result<TValue> result,
    Warning warning)
  {
    result.Statements.AddWarning(warning);
    return result;
  }

  public static Result<TValue> WithWarning<TValue>(
    this Result<TValue> result,
    string message)
  {
    result.Statements.AddWarning(new Warning(message));
    return result;
  }
}
