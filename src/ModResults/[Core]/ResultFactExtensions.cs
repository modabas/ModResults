namespace ModResults;
public static class ResultFactExtensions
{
  public static Result WithFacts(
    this Result result,
    IEnumerable<Fact> facts)
  {
    result.Statements.AddFacts(facts);
    return result;
  }

  public static Result WithFacts(
    this Result result,
    IEnumerable<string> messages)
  {
    result.Statements.AddFacts(messages.Select(m => new Fact(m)));
    return result;
  }

  public static Result WithFactsFrom(
    this Result result,
    IModResult fromResult)
  {
    result.WithFacts(fromResult.Statements.Facts);
    return result;
  }

  public static Result<TValue> WithFacts<TValue>(
    this Result<TValue> result,
    IEnumerable<Fact> facts)
  {
    result.Statements.AddFacts(facts);
    return result;
  }

  public static Result<TValue> WithFacts<TValue>(
    this Result<TValue> result,
    IEnumerable<string> messages)
  {
    result.Statements.AddFacts(messages.Select(m => new Fact(m)));
    return result;
  }

  public static Result<TValue> WithFactsFrom<TValue>(
    this Result<TValue> result,
    IModResult fromResult)
  {
    result.WithFacts(fromResult.Statements.Facts);
    return result;
  }

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

  public static Result WithFact(this Result result, Fact fact)
  {
    result.Statements.AddFact(fact);
    return result;
  }
  public static Result WithFact(this Result result, string message)
  {
    result.Statements.AddFact(new Fact(message));
    return result;
  }

  public static Result<TValue> WithFact<TValue>(this Result<TValue> result, Fact fact)
  {
    result.Statements.AddFact(fact);
    return result;
  }
  public static Result<TValue> WithFact<TValue>(this Result<TValue> result, string message)
  {
    result.Statements.AddFact(new Fact(message));
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
