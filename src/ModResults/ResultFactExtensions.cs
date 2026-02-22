namespace ModResults;

public static partial class ResultFactExtensions
{
  extension(Result result)
  {
    /// <summary>
    /// Adds a collection of <see cref="Fact"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="facts"></param>
    /// <returns></returns>
    public Result WithFacts(
      IReadOnlyList<Fact> facts)
    {
      result.Statements.AddFacts(facts);
      return result;
    }

    /// <summary>
    /// Adds a collection of <see cref="Fact"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="facts"></param>
    /// <returns></returns>
    public Result WithFacts(
      IEnumerable<Fact> facts)
    {
      result.Statements.AddFacts(facts);
      return result;
    }

    /// <summary>
    /// Adds a collection of string messages as a collection of <see cref="Fact"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    public Result WithFacts(
      IEnumerable<string> messages)
    {
      result.Statements.AddFacts(messages.Select(m => new Fact(m)));
      return result;
    }

    /// <summary>
    /// Adds all <see cref="Fact"/>s of another result object.
    /// </summary>
    /// <param name="fromResult"></param>
    /// <returns></returns>
    public Result WithFactsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasFacts())
      {
        result.WithFacts(fromResult.Statements.Facts);
      }
      return result;
    }

    /// <summary>
    /// Adds a <see cref="Fact"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    public Result WithFact(Fact fact)
    {
      result.Statements.AddFact(fact);
      return result;
    }

    /// <summary>
    /// Adds a string message as a <see cref="Fact"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Result WithFact(string message)
    {
      result.Statements.AddFact(new Fact(message));
      return result;
    }
  }

  extension<TValue>(Result<TValue> result) where TValue : notnull
  {
    /// <summary>
    /// Adds a collection of <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="facts"></param>
    /// <returns></returns>
    public Result<TValue> WithFacts(
      IReadOnlyList<Fact> facts)
    {
      result.Statements.AddFacts(facts);
      return result;
    }

    /// <summary>
    /// Adds a collection of <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="facts"></param>
    /// <returns></returns>
    public Result<TValue> WithFacts(
      IEnumerable<Fact> facts)
    {
      result.Statements.AddFacts(facts);
      return result;
    }

    /// <summary>
    /// Adds a collection of string messages as a collection of <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    public Result<TValue> WithFacts(
      IEnumerable<string> messages)
    {
      result.Statements.AddFacts(messages.Select(m => new Fact(m)));
      return result;
    }

    /// <summary>
    /// Adds all <see cref="Fact"/>s of another result object.
    /// </summary>
    /// <param name="fromResult"></param>
    /// <returns></returns>
    public Result<TValue> WithFactsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasFacts())
      {
        result.WithFacts(fromResult.Statements.Facts);
      }
      return result;
    }

    /// <summary>
    /// Adds a <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="fact"></param>
    /// <returns></returns>
    public Result<TValue> WithFact(Fact fact)
    {
      result.Statements.AddFact(fact);
      return result;
    }

    /// <summary>
    /// Adds a string message as a <see cref="Fact"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Result<TValue> WithFact(string message)
    {
      result.Statements.AddFact(new Fact(message));
      return result;
    }
  }
}
