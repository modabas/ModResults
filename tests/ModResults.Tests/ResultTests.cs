namespace ModResults.Tests;

public class ResultTests
{
  private readonly Fact _fact1, _fact2;
  private readonly Warning _warning1;
  private readonly Error _error1, _error2, _error5;

  public ResultTests()
  {
    _fact1 = new Fact();
    _fact2 = new Fact("Fact 2", "F2");
    _warning1 = new Warning();
    _error1 = new Error();
    _error2 = new Error("Error 2", code: "E2");
    _error5 = new Error(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  [Fact]
  public void OkResult()
  {
    // Arrange
    var result = Result.Ok();

    // Act
    var isOk = result.IsOk;
    var isFailed = result.IsFailed;
    var failure = result.Failure;

    // Assert
    Assert.True(isOk);
    Assert.False(isFailed);
    Assert.Null(failure);
    Assert.False(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith<ApplicationException>());
    Assert.False(result.IsFailedWith<Exception>());
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
    Assert.False(result.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void OkResultFromResultOfTImplicitOperator()
  {
    // Arrange
    Result<ValueStruct> resultOfT = new ValueStruct() { Number = 42, String = "Meaning of life." };

    // Act
    Result result = resultOfT;

    // Assert
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.False(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith<ApplicationException>());
    Assert.False(result.IsFailedWith<Exception>());
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
    Assert.False(result.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void FailedResult()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    var errors = new List<Error> { _error1, _error2, _error5 };
    var resultOfT = new Result<ValueStruct>(
      false,
      default,
      new Failure(FailureType.Forbidden, errors),
      new Statements(facts, warnings));
    var result = Result.Fail(resultOfT);

    // Act
    var isOk = result.IsOk;
    var isFailed = result.IsFailed;
    var failure = result.Failure;

    // Assert
    Assert.False(isOk);
    Assert.True(isFailed);
    Assert.NotNull(failure);
    Assert.Equal(3, failure?.Errors.Count);
    Assert.Equal(string.Empty, failure?.Errors[0].Message);
    Assert.Equal("Error 2", failure?.Errors[1].Message);
    Assert.Equal("Error 5", failure?.Errors[2].Message);
    Assert.Equal(2, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Single(result.Statements.Warnings);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.True(result.IsFailedWith<ApplicationException>());
    Assert.False(result.IsFailedWith<Exception>());
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void FailedResultFromOkResultOfT()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    var resultOfT = new Result<ValueStruct>(
      true,
      new ValueStruct() { Number = 42, String = "Meaning of life." },
      null,
      new Statements(facts, warnings));

    // Act
    var result = Result.Fail(resultOfT);

    // Assert
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.Equal(2, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Single(result.Statements.Warnings);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.False(result.IsFailedWith(FailureType.Forbidden));
    Assert.True(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith<ApplicationException>());
    Assert.False(result.IsFailedWith<Exception>());
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
    Assert.False(result.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void CtorThrowsArgumentNullExceptionWhenFailureIsNull()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    // Act
    void act() => new Result(false, null, new Statements(facts, warnings));
    // Assert
    Assert.Throws<ArgumentNullException>(act);
  }

}
