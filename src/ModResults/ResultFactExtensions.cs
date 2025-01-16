namespace ModResults;
public static partial class ResultFactExtensions
{
  /// <summary>
  /// Adds a collection of <see cref="Fact"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="facts"></param>
  /// <returns></returns>
  public static Result WithFacts(
    this Result result,
    IEnumerable<Fact> facts)
  {
    result.Statements.AddFacts(facts);
    return result;
  }

  /// <summary>
  /// Adds a collection of string messages as a collection of <see cref="Fact"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="messages"></param>
  /// <returns></returns>
  public static Result WithFacts(
    this Result result,
    IEnumerable<string> messages)
  {
    result.Statements.AddFacts(messages.Select(m => new Fact(m)));
    return result;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s of another result object.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public static Result WithFactsFrom(
    this Result result,
    IModResult fromResult)
  {
    result.WithFacts(fromResult.Statements.Facts);
    return result;
  }

  /// <summary>
  /// Adds a collection of <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="facts"></param>
  /// <returns></returns>
  public static Result<TValue> WithFacts<TValue>(
    this Result<TValue> result,
    IEnumerable<Fact> facts)
    where TValue : notnull
  {
    result.Statements.AddFacts(facts);
    return result;
  }

  /// <summary>
  /// Adds a collection of string messages as a collection of <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="messages"></param>
  /// <returns></returns>
  public static Result<TValue> WithFacts<TValue>(
    this Result<TValue> result,
    IEnumerable<string> messages)
    where TValue : notnull
  {
    result.Statements.AddFacts(messages.Select(m => new Fact(m)));
    return result;
  }

  /// <summary>
  /// Adds all <see cref="Fact"/>s of another result object.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="fromResult"></param>
  /// <returns></returns>
  public static Result<TValue> WithFactsFrom<TValue>(
    this Result<TValue> result,
    IModResult fromResult)
    where TValue : notnull
  {
    result.WithFacts(fromResult.Statements.Facts);
    return result;
  }

  /// <summary>
  /// Adds a <see cref="Fact"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="fact"></param>
  /// <returns></returns>
  public static Result WithFact(this Result result, Fact fact)
  {
    result.Statements.AddFact(fact);
    return result;
  }

  /// <summary>
  /// Adds a string message as a <see cref="Fact"/> to the <see cref="Result"/>.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static Result WithFact(this Result result, string message)
  {
    result.Statements.AddFact(new Fact(message));
    return result;
  }

  /// <summary>
  /// Adds a <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="fact"></param>
  /// <returns></returns>
  public static Result<TValue> WithFact<TValue>(this Result<TValue> result, Fact fact)
    where TValue : notnull
  {
    result.Statements.AddFact(fact);
    return result;
  }

  /// <summary>
  /// Adds a string message as a <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="result"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static Result<TValue> WithFact<TValue>(this Result<TValue> result, string message)
    where TValue : notnull
  {
    result.Statements.AddFact(new Fact(message));
    return result;
  }
}
