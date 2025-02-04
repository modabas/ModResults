
namespace ModResults.Orleans.Tests;
internal class ResultOfTSerializationGrain : IResultOfTSerializationGrain
{
  private readonly Fact fact1, fact2, fact3;
  private readonly Warning warning1, warning2, warning3;
  private readonly Error error1, error2, error3, error4, error5;

  public ResultOfTSerializationGrain()
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

  public Task<Result<ValueClass>> FailedResultWithValueClass()
  {
    // Arrange
    var facts = new List<Fact> { fact3 };
    var warnings = new List<Warning> { warning1, warning2, warning3 };
    var errors = new List<Error> { error1, error2, error3, error4, error5 };
    var resultOfTOriginal = new Result<ValueClass>(
      false,
      null,
      new Failure(FailureType.Error, errors),
      new Statements(facts, warnings));

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueRecord>> FailedResultWithValueRecord()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
    var errors = new List<Error> { error1, error2, error5 };
    var resultOfTOriginal = new Result<ValueRecord>(
      false,
      null,
      new Failure(FailureType.Unspecified, errors),
      new Statements(facts, warnings));

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueStruct>> FailedResultWithValueStruct()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2, fact3 };
    var warnings = new List<Warning> { warning1, warning2 };
    var errors = new List<Error> { error2, error5 };
    var resultOfTOriginal = new Result<ValueStruct>(
      false,
      default,
      new Failure(FailureType.Unavailable, errors),
      new Statements(facts, warnings));

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueClass>> OkResultWithValueClass()
  {
    // Arrange
    var facts = new List<Fact> { fact3, fact2, fact1 };
    var warnings = new List<Warning> { warning1, warning3 };
    var resultOfTOriginal = Result<ValueClass>.Ok(
      new ValueClass() { Number = 42, String = "Meaning of life." })
      .WithFacts(facts)
      .WithWarnings(warnings);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueRecord>> OkResultWithValueRecord()
  {
    // Arrange
    var facts = new List<Fact> { fact3, fact2 };
    var warnings = new List<Warning> { warning1, warning3 };
    var resultOfTOriginal = Result<ValueRecord>.Ok(new(42, "Meaning of life."))
      .WithFacts(facts)
      .WithWarnings(warnings);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueStruct>> OkResultWithValueStruct()
  {
    // Arrange
    var facts = new List<Fact> { fact3, fact2, fact1 };
    var warnings = new List<Warning> { warning1, warning3 };
    var statements = new Statements(facts, warnings);
    var resultOfTOriginal = Result<ValueStruct>.Ok(
      new ValueStruct() { Number = 42, String = "Meaning of life." })
      .WithStatements(statements);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }
}
