namespace ModResults;

public static partial class ResultFactExtensions
{
  public static Result<TValue, TFailure> WithFacts<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IReadOnlyList<Fact> facts)
    where TValue : notnull
    where TFailure : notnull
  {
    result.Statements.AddFacts(facts);
    return result;
  }

  public static Result<TValue, TFailure> WithFacts<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IEnumerable<Fact> facts)
    where TValue : notnull
    where TFailure : notnull
  {
    result.Statements.AddFacts(facts);
    return result;
  }

  public static Result<TValue, TFailure> WithFacts<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IEnumerable<string> messages)
    where TValue : notnull
    where TFailure : notnull
  {
    result.Statements.AddFacts(messages.Select(m => new Fact(m)));
    return result;
  }

  public static Result<TValue, TFailure> WithFactsFrom<TValue, TFailure>(
    this Result<TValue, TFailure> result,
    IModResult fromResult)
    where TValue : notnull
    where TFailure : notnull
  {
    result.WithFacts(fromResult.Statements.Facts);
    return result;
  }

  public static Result<TValue, TFailure> WithFact<TValue, TFailure>(
    this Result<TValue, TFailure> result, Fact fact)
    where TValue : notnull
    where TFailure : notnull
  {
    result.Statements.AddFact(fact);
    return result;
  }

  public static Result<TValue, TFailure> WithFact<TValue, TFailure>(
    this Result<TValue, TFailure> result, string message)
    where TValue : notnull
    where TFailure : notnull
  {
    result.Statements.AddFact(new Fact(message));
    return result;
  }
}
