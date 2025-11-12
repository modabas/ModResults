namespace ModResults.Orleans.Tests;

internal class ResultSerializationGrain : IResultSerializationGrain
{
  private readonly Fact fact1, fact2, fact3;
  private readonly Warning warning1, warning2, warning3;
  private readonly Error error1, error2, error3, error4, error5;

  public ResultSerializationGrain()
  {
    fact1 = new Fact();
    fact2 = new Fact("Fact 2", "F2");
    fact3 = new Fact("Fact 3", "F3");
    warning1 = new Warning();
    warning2 = new Warning("Warning 2", "W2");
    warning3 = new Warning("Warning 3", "W3");
    error1 = new Error();
    error2 = new Error("Error 2", code: "E2");
    error3 = new Error("Error 3", code: "E3");
    error4 = new Error(new InvalidOperationException("Error 4"));
    error5 = new Error(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  public Task<Result> FailedResult()
  {
    // Arrange
    var errors = new List<Error> { error1, error2, error5 };
    var resultOriginal = Result.Error(errors.ToArray()).WithFact(fact1).WithWarning(warning3);

    // Act
    return Task.FromResult(resultOriginal);
  }

  public Task<Result> OkResult()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2, fact3 };
    var warnings = new List<Warning> { warning1, warning2, warning3 };
    var statements = new Statements(facts, warnings);

    var resultOriginal = Result.Ok().WithStatements(statements);

    // Act
    return Task.FromResult(resultOriginal);
  }
}
