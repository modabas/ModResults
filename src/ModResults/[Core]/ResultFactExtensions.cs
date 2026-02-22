namespace ModResults;

public static partial class ResultFactExtensions
{
  extension<TValue, TFailure>(Result<TValue, TFailure> result)
    where TValue : notnull
    where TFailure : notnull
  {
    public Result<TValue, TFailure> WithFacts(
    IReadOnlyList<Fact> facts)
    {
      result.Statements.AddFacts(facts);
      return result;
    }

    public Result<TValue, TFailure> WithFacts(
      IEnumerable<Fact> facts)
    {
      result.Statements.AddFacts(facts);
      return result;
    }

    public Result<TValue, TFailure> WithFacts(
      IEnumerable<string> messages)
    {
      result.Statements.AddFacts(messages.Select(m => new Fact(m)));
      return result;
    }

    public Result<TValue, TFailure> WithFactsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasFacts())
      {
        result.WithFacts(fromResult.Statements.Facts);
      }
      return result;
    }

    public Result<TValue, TFailure> WithFact(
  Fact fact)
    {
      result.Statements.AddFact(fact);
      return result;
    }

    public Result<TValue, TFailure> WithFact(
  string message)
    {
      result.Statements.AddFact(new Fact(message));
      return result;
    }
  }
}
