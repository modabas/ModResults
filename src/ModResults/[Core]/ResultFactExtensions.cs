namespace ModResults;
public static partial class ResultFactExtensions
{
  public static Result<TValue, TFailure> WithFacts<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IEnumerable<Fact> facts)
  {
    result.Statements.AddFacts(facts);
    return result;
  }

  public static Result<TValue, TFailure> WithFacts<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IEnumerable<string> messages)
  {
    result.Statements.AddFacts(messages.Select(m => new Fact(m)));
    return result;
  }

  public static Result<TValue, TFailure> WithFactsFrom<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IModResult fromResult)
  {
    result.WithFacts(fromResult.Statements.Facts);
    return result;
  }

  public static Result<TValue, TFailure> WithFact<TValue, TFailure>(
    this Result<TValue, TFailure> result, Fact fact)
  {
    result.Statements.AddFact(fact);
    return result;
  }
  public static Result<TValue, TFailure> WithFact<TValue, TFailure>(
    this Result<TValue, TFailure> result, string message)
  {
    result.Statements.AddFact(new Fact(message));
    return result;
  }
}
