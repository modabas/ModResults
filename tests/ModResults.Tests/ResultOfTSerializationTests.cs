using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModResults.Tests;
public class ResultOfTSerializationTests
{
  private readonly Fact fact1, fact2, fact3;
  private readonly Warning warning1, warning2, warning3;
  private readonly Error error1, error2, error3, error4, error5;
  private readonly JsonSerializerOptions jsonSerializerOptions;

  public ResultOfTSerializationTests()
  {
    jsonSerializerOptions = new()
    {
      PropertyNameCaseInsensitive = true,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      NumberHandling = JsonNumberHandling.AllowReadingFromString
    };
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
    var facts = new List<Fact> { fact3, fact2, fact1 };
    var warnings = new List<Warning> { warning1, warning3 };
    var statements = new Statements(facts, warnings);
    var resultOfTOriginal = Result<ValueStruct>.Ok(
      new ValueStruct() { Number = 42, String = "Meaning of life." })
      .WithStatements(statements);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueStruct>>(jsonString, jsonSerializerOptions);


    // Assert
    Assert.NotNull(resultOfT);
    Assert.True(resultOfT.IsOk);
    Assert.False(resultOfT.IsFailed);
    Assert.Null(resultOfT.Failure);
    Assert.NotNull(resultOfT?.Value);
    Assert.Equal(42, resultOfT.Value.Number);
    Assert.Equal("Meaning of life.", resultOfT.Value.String);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[2].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[0].Message);
    Assert.Equal(2, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[1].Message);
  }

  [Fact]
  public void OkResultWithValueClass()
  {
    // Arrange
    var facts = new List<Fact> { fact3, fact2, fact1 };
    var warnings = new List<Warning> { warning1, warning3 };
    var resultOfTOriginal = Result<ValueClass>.Ok(
      new ValueClass() { Number = 42, String = "Meaning of life." })
      .WithFacts(facts)
      .WithWarnings(warnings);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueClass>>(jsonString, jsonSerializerOptions);


    // Assert
    Assert.NotNull(resultOfT);
    Assert.True(resultOfT.IsOk);
    Assert.False(resultOfT.IsFailed);
    Assert.Null(resultOfT.Failure);
    Assert.NotNull(resultOfT?.Value);
    Assert.Equal(42, resultOfT.Value.Number);
    Assert.Equal("Meaning of life.", resultOfT.Value.String);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[2].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[0].Message);
    Assert.Equal(2, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[1].Message);
  }

  [Fact]
  public void OkResultWithValueRecord()
  {
    // Arrange
    var facts = new List<Fact> { fact3, fact2 };
    var warnings = new List<Warning> { warning1, warning3 };
    var resultOfTOriginal = Result<ValueRecord>.Ok(new(42, "Meaning of life."))
      .WithFacts(facts)
      .WithWarnings(warnings);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueRecord>>(jsonString, jsonSerializerOptions);


    // Assert
    Assert.NotNull(resultOfT);
    Assert.True(resultOfT.IsOk);
    Assert.False(resultOfT.IsFailed);
    Assert.Null(resultOfT.Failure);
    Assert.NotNull(resultOfT?.Value);
    Assert.Equal(42, resultOfT.Value.Number);
    Assert.Equal("Meaning of life.", resultOfT.Value.String);
    Assert.Equal(2, resultOfT.Statements.Facts.Count);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[0].Message);
    Assert.Equal(2, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[1].Message);
  }

  [Fact]
  public void FailedResultWithValueStruct()
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

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueStruct>>(jsonString, jsonSerializerOptions);


    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Equal(2, resultOfT.Failure.Errors.Count);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 5", resultOfT.Failure.Errors[1].Message);
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
    var resultOfTOriginal = new Result<ValueClass>(
      false,
      null,
      new Failure(FailureType.Error, errors),
      new Statements(facts, warnings));

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueClass>>(jsonString, jsonSerializerOptions);


    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Equal(5, resultOfT.Failure.Errors.Count);
    Assert.Equal(string.Empty, resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.Equal("Error 3", resultOfT.Failure.Errors[2].Message);
    Assert.Equal("Error 4", resultOfT.Failure.Errors[3].Message);
    Assert.Equal("Error 5", resultOfT.Failure.Errors[4].Message);
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
    var resultOfTOriginal = new Result<ValueRecord>(
      false,
      null,
      new Failure(FailureType.Unspecified, errors),
      new Statements(facts, warnings));

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueRecord>>(jsonString, jsonSerializerOptions);


    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Equal(3, resultOfT.Failure.Errors.Count);
    Assert.Equal(string.Empty, resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.Equal("Error 5", resultOfT.Failure.Errors[2].Message);
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
}
