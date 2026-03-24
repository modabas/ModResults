namespace ModResults.Tests;

public class FailureResultTests
{
  private readonly Fact _fact1, _fact2;
  private readonly Warning _warning1;
  private readonly Error _error1, _error2, _error5;

  public FailureResultTests()
  {
    _fact1 = new Fact();
    _fact2 = new Fact("Fact 2", "F2");
    _warning1 = new Warning();
    _error1 = new Error();
    _error2 = new Error("Error 2", code: "E2");
    _error5 = new Error(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  [Fact]
  public void FailureResultAsFailedResultOfT()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    var errors = new List<Error> { _error1, _error2, _error5 };
    var failureResult = new FailureResult(
      new Failure(FailureType.Forbidden, errors),
      new Statements(facts, warnings));
    Result<ValueStruct> resultOfT = failureResult;

    // Act
    var isOk = resultOfT.IsOk;
    var isFailed = resultOfT.IsFailed;
    var failure = resultOfT.Failure;

    // Assert
    Assert.False(isOk);
    Assert.True(isFailed);
    Assert.NotNull(failure);
    Assert.Equal(3, failure?.Errors.Count);
    Assert.Equal(string.Empty, failure?.Errors[0].Message);
    Assert.Equal("Error 2", failure?.Errors[1].Message);
    Assert.Equal("Error 5", failure?.Errors[2].Message);
    Assert.Equal(2, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Single(resultOfT.Statements.Warnings);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Forbidden));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void FailureResultAsFailedResult()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    var errors = new List<Error> { _error1, _error2, _error5 };
    var failureResult = new FailureResult(
      new Failure(FailureType.Forbidden, errors),
      new Statements(facts, warnings));
    Result result = failureResult;

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
  public void FailureResultFromFailedResultOfT()
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
    var result = FailureResult.From(resultOfT, false);

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
  public void FailedResultOfTAsFailureResult()
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
    var result = FailureResult.From(resultOfT);

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
  public void FailureResultFromFailedResultOfTWithEmptyErrors()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    var resultOfT = new Result<ValueStruct>(
      false,
      default,
      new Failure(FailureType.Forbidden, null),
      new Statements(facts, warnings));
    var result = FailureResult.From(resultOfT, false);

    // Act
    var isOk = result.IsOk;
    var isFailed = result.IsFailed;
    var failure = result.Failure;

    // Assert
    Assert.False(isOk);
    Assert.True(isFailed);
    Assert.NotNull(failure);
    Assert.False(failure.HasErrors());
    Assert.Equal(2, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Single(result.Statements.Warnings);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
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
  public void FailedResultOfTWithEmptyErrorsAsFailureResult()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    var resultOfT = new Result<ValueStruct>(
      false,
      default,
      new Failure(FailureType.Forbidden, null),
      new Statements(facts, warnings));
    var result = FailureResult.From(resultOfT);

    // Act
    var isOk = result.IsOk;
    var isFailed = result.IsFailed;
    var failure = result.Failure;

    // Assert
    Assert.False(isOk);
    Assert.True(isFailed);
    Assert.NotNull(failure);
    Assert.False(failure.HasErrors());
    Assert.Equal(2, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Single(result.Statements.Warnings);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
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
  public void FailureResultFromOkResultOfT()
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
    var result = FailureResult.From(resultOfT, false);

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
  public void OkResultOfTAsFailureResult()
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
    var result = FailureResult.From(resultOfT);

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
}
