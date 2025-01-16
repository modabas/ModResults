namespace ModResults;
public static partial class ResultWarningExtensions
{
  /// <summary>
  /// Adds a collection of <see cref="Warning"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="warnings"></param>
  /// <returns></returns>
  public static Result WithWarnings(
    this Result result,
    IEnumerable<Warning> warnings)
  {
    result.Statements.AddWarnings(warnings);
    return result;
  }

  /// <summary>
  /// Adds a collection of string messages as a collection of <see cref="Warning"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="messages"></param>
  /// <returns></returns>
  public static Result WithWarnings(
    this Result result,
    IEnumerable<string> messages)
  {
    result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
    return result;
  }

  /// <summary>
  /// Adds all <see cref="Warning"/>s of another result object.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public static Result WithWarningsFrom(
    this Result result,
    IModResult fromResult)
  {
    result.WithWarnings(fromResult.Statements.Warnings);
    return result;
  }

  /// <summary>
  /// Adds a collection of <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="warnings"></param>
  /// <returns></returns>
  public static Result<TValue> WithWarnings<TValue>(
    this Result<TValue> result,
    IEnumerable<Warning> warnings)
    where TValue : notnull
  {
    result.Statements.AddWarnings(warnings);
    return result;
  }

  /// <summary>
  /// Adds a collection of string messages as a collection of <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="messages"></param>
  /// <returns></returns>
  public static Result<TValue> WithWarnings<TValue>(
    this Result<TValue> result,
    IEnumerable<string> messages)
    where TValue : notnull
  {
    result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
    return result;
  }

  /// <summary>
  /// Adds all <see cref="Warning"/>s of another result object.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public static Result<TValue> WithWarningsFrom<TValue>(
    this Result<TValue> result,
    IModResult fromResult)
    where TValue : notnull
  {
    result.WithWarnings(fromResult.Statements.Warnings);
    return result;
  }

  /// <summary>
  /// Adds a <see cref="Warning"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="warning"></param>
  /// <returns></returns>
  public static Result WithWarning(this Result result, Warning warning)
  {
    result.Statements.AddWarning(warning);
    return result;
  }

  /// <summary>
  /// Adds a string message as a <see cref="Warning"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static Result WithWarning(this Result result, string message)
  {
    result.Statements.AddWarning(new Warning(message));
    return result;
  }

  /// <summary>
  /// Adds a <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="warning"></param>
  /// <returns></returns>
  public static Result<TValue> WithWarning<TValue>(
    this Result<TValue> result,
    Warning warning)
    where TValue : notnull
  {
    result.Statements.AddWarning(warning);
    return result;
  }

  /// <summary>
  /// Adds a string message as a <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static Result<TValue> WithWarning<TValue>(
    this Result<TValue> result,
    string message)
    where TValue : notnull
  {
    result.Statements.AddWarning(new Warning(message));
    return result;
  }
}
