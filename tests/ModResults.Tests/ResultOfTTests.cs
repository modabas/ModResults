namespace ModResults.Tests;
public class ResultOfTTests
{

  private readonly Fact fact1, fact2, fact3;
  private readonly Warning warning1, warning2, warning3;
  private readonly Error error1, error2, error3, error4, error5;

  public ResultOfTTests()
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
  public void OkResultWithValueStruct()
  {
    // Arrange
    var resultOfT = Result<ValueStruct>.Ok(new ValueStruct() { Number = 42, String = "Meaning of life." });

    // Act
    var isOk = resultOfT.IsOk;
    var isFailed = resultOfT.IsFailed;
    var failure = resultOfT.Failure;
    ValueStruct? value = resultOfT.Value;

    // Assert
    Assert.True(isOk);
    Assert.False(isFailed);
    Assert.Null(failure);
    Assert.NotNull(value);
    Assert.Equal(42, value?.Number);
    Assert.Equal("Meaning of life.", value?.String);
    Assert.False(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith(typeof(InvalidOperationException)));
    Assert.False(resultOfT.IsFailedWith<InvalidCastException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.False(resultOfT.IsFailedWith<Exception>(true));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception), true));


  }

  [Fact]
  public void OkResultWithValueClass()
  {
    // Arrange
    var result = Result<ValueClass>.Ok(new ValueClass() { Number = 42, String = "Meaning of life." });

    // Act
    var isOk = result.IsOk;
    var isFailed = result.IsFailed;
    var failure = result.Failure;
    var value = result.Value;

    // Assert
    Assert.True(isOk);
    Assert.False(isFailed);
    Assert.Null(failure);
    Assert.NotNull(value);
    Assert.Equal(42, value.Number);
    Assert.Equal("Meaning of life.", value.String);
  }

  [Fact]
  public void OkResultWithValueRecord()
  {
    // Arrange
    var result = Result<ValueRecord>.Ok(new ValueRecord(42, "Meaning of life."));

    // Act
    var isOk = result.IsOk;
    var isFailed = result.IsFailed;
    var failure = result.Failure;
    var value = result.Value;

    // Assert
    Assert.True(isOk);
    Assert.False(isFailed);
    Assert.Null(failure);
    Assert.NotNull(value);
    Assert.Equal(42, value.Number);
    Assert.Equal("Meaning of life.", value.String);
  }

  [Fact]
  public void FailedResultWithValueStruct()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2, fact3 };
    var warnings = new List<Warning> { warning1, warning2 };
    var errors = new List<Error> { error2, error5 };
    var result2 = new Result(
      false,
      new Failure(FailureType.Unavailable, errors),
      new Statements(facts, warnings));
    var resultOfT = Result<ValueStruct>.Fail(result2);

    // Act
    var isOk = resultOfT.IsOk;
    var isFailed = resultOfT.IsFailed;
    var failure = resultOfT.Failure;

    // Assert
    Assert.False(isOk);
    Assert.Equal("Error 5", failure?.Errors[1].Message);
    Assert.NotNull(failure);
    Assert.Equal(2, failure?.Errors.Count);
    Assert.Equal("Error 2", failure?.Errors[0].Message);
    Assert.Equal("Error 5", failure?.Errors[1].Message);
    Assert.True(resultOfT.HasError("E2"));
    Assert.False(resultOfT.HasError("e2"));
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(2, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.True(resultOfT.HasWarning("W2"));
    Assert.False(resultOfT.HasWarning("w2"));
    Assert.True(resultOfT.IsFailedWith(FailureType.Unavailable));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void FailedResultWithValueClass()
  {
    // Arrange
    var facts = new List<Fact> { fact3 };
    var warnings = new List<Warning> { warning1, warning2, warning3 };
    var errors = new List<Error> { error1, error2, error3, error4, error5 };
    var result2 = new Result(
      false,
      new Failure(FailureType.Error, errors),
      new Statements(facts, warnings));
    var resultOfT = Result<ValueClass>.Fail(result2);

    // Act
    var isOk = resultOfT.IsOk;
    var isFailed = resultOfT.IsFailed;
    var failure = resultOfT.Failure;

    // Assert
    Assert.False(isOk);
    Assert.True(isFailed);
    Assert.NotNull(failure);
    Assert.Equal(5, failure?.Errors.Count);
    Assert.Equal(string.Empty, failure?.Errors[0].Message);
    Assert.Equal("Error 2", failure?.Errors[1].Message);
    Assert.Equal("Error 3", failure?.Errors[2].Message);
    Assert.Equal("Error 4", failure?.Errors[3].Message);
    Assert.Equal("Error 5", failure?.Errors[4].Message);
    Assert.True(isFailed);
    Assert.Single(resultOfT.Statements.Facts);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[0].Message);
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
    Assert.True(resultOfT.IsFailedWith(typeof(InvalidOperationException)));
    Assert.False(resultOfT.IsFailedWith<InvalidCastException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void FailedResultWithValueRecord()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
    var errors = new List<Error> { error1, error2, error5 };
    var result2 = new Result(
      false,
      new Failure(FailureType.Unspecified, errors),
      new Statements(facts, warnings));
    var resultOfT = Result<ValueRecord>.Fail(result2);

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
    Assert.True(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith(FailureType.Conflict));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void CtorThrowsArgumentNullExceptionWhenValueClassIsNull()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
    // Act
    void act() => new Result<ValueClass>(true, null, null, new Statements(facts, warnings));
    // Assert
    Assert.Throws<ArgumentNullException>(act);
  }

  [Fact]
  public void CtorThrowsArgumentNullExceptionWhenValueRecordIsNull()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
    // Act
    void act() => new Result<ValueRecord>(true, null, null, new Statements(facts, warnings));
    // Assert
    Assert.Throws<ArgumentNullException>(act);
  }

  [Fact]
  public void CtorThrowsArgumentNullExceptionWhenFailureIsNull()
  {
    // Arrange
    var facts = new List<Fact> { fact1, fact2 };
    var warnings = new List<Warning> { warning1 };
    // Act
    void act() => new Result<ValueRecord>(false, null, null, new Statements(facts, warnings));
    // Assert
    Assert.Throws<ArgumentNullException>(act);
  }
}

