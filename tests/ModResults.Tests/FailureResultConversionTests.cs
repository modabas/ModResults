namespace ModResults.Tests;

public class FailureResultConversionTests
{
  private readonly Fact _fact1, _fact2, _fact3;
  private readonly Warning _warning1, _warning2, _warning3;
  private readonly Error _error1, _error2;
  private readonly InvalidOperationException _ex1;
  private readonly ApplicationException _ex2;

  public FailureResultConversionTests()
  {
    _fact1 = new Fact();
    _fact2 = new Fact("Fact 2", "F2");
    _fact3 = new Fact("Fact 3", "F3");
    _warning1 = new Warning();
    _warning2 = new Warning("Warning 2", "W2");
    _warning3 = new Warning("Warning 3", "W3");
    _error1 = new Error("Error 1");
    _error2 = new Error("Error 2", code: "E2");
    _ex1 = new InvalidOperationException("Error 4");
    _ex2 = new ApplicationException("Error 5", new ArgumentException("Error 5 Inner"));
  }

  [Fact]
  public void BasicFailedResultToResult()
  {
    //Arrange
    var resultOriginal = FailureResult.TimedOut();

    //Act
    var result = resultOriginal.ToResult();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.False(result.HasFacts());
    Assert.False(result.HasWarnings());
    Assert.False(result.HasStatements());
    Assert.False(result.Failure.HasErrors());
  }

  [Fact]
  public void FailedResultToResultOfT()
  {
    //Arrange
    var resultOriginal = FailureResult
      .Error(
        _error1,
        _error2,
        new Error(_ex1),
        new Error(_ex2))
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult<ValueClass>();

    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Null(resultOfT.Value);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.Equal(4, resultOfT.Failure.Errors.Count);
    Assert.Equal("Error 1", resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("Failure.Error"));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith<InvalidOperationException>());
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
  }
}
