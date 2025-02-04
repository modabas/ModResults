namespace ModResults.Tests;
public class ResultTests
{
  private readonly Fact fact1, fact2, fact3;
  private readonly Warning warning1, warning2, warning3;
  private readonly Error error1, error2, error3, error4, error5;

  public ResultTests()
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
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
    var errors = new List<Error> { error1, error2, error5 };
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
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
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
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
    // Act
    void act() => new Result(false, null, new Statements(facts, warnings));
    // Assert
    Assert.Throws<ArgumentNullException>(act);
  }

}
