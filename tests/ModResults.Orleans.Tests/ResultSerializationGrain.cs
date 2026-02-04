namespace ModResults.Orleans.Tests;

internal class ResultSerializationGrain : IResultSerializationGrain
{
  private readonly Fact _fact1, _fact2, _fact3;
  private readonly Warning _warning1, _warning2, _warning3;
  private readonly Error _error1, _error2, _error5;

  public ResultSerializationGrain()
  {
    _fact1 = new Fact();
    _fact2 = new Fact("Fact 2", "F2");
    _fact3 = new Fact("Fact 3", "F3");
    _warning1 = new Warning();
    _warning2 = new Warning("Warning 2", "W2");
    _warning3 = new Warning("Warning 3", "W3");
    _error1 = new Error();
    _error2 = new Error("Error 2", code: "E2");
    _error5 = new Error(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  public Task<Result> FailedResult()
  {
    // Arrange
    var errors = new List<Error> { _error1, _error2, _error5 };
    var resultOriginal = Result.Error(errors.ToArray()).WithFact(_fact1).WithWarning(_warning3);

    // Act
    return Task.FromResult(resultOriginal);
  }

  public Task<Result> OkResult()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2, _fact3 };
    var warnings = new List<Warning> { _warning1, _warning2, _warning3 };
    var statements = new Statements(facts, warnings);

    var resultOriginal = Result.Ok().WithStatements(statements);

    // Act
    return Task.FromResult(resultOriginal);
  }
}
