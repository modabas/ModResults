namespace ModResults.Orleans.Tests;

internal class FailureResultSerializationGrain : IFailureResultSerializationGrain
{
  private readonly Fact _fact1;
  private readonly Warning _warning3;
  private readonly Error _error1, _error2, _error5;

  public FailureResultSerializationGrain()
  {
    _fact1 = new Fact();
    _warning3 = new Warning("Warning 3", "W3");
    _error1 = new Error();
    _error2 = new Error("Error 2", code: "E2");
    _error5 = new Error(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  public Task<FailureResult> FailedResult()
  {
    // Arrange
    var errors = new List<Error> { _error1, _error2, _error5 };
    var resultOriginal = FailureResult.Error(errors.ToArray()).WithFact(_fact1).WithWarning(_warning3);

    // Act
    return Task.FromResult(resultOriginal);
  }

  public Task<FailureResult> BasicFailedResult()
  {
    // Arrange
    var resultOriginal = FailureResult.Error();

    // Act
    return Task.FromResult(resultOriginal);
  }
}
