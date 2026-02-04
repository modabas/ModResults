using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModResults.Tests;

public class ResultOfTJsonSerializationTests
{
  private readonly Fact _fact1, _fact2, _fact3;
  private readonly Warning _warning1, _warning2, _warning3;
  private readonly Error _error1, _error2, _error3, _error4, _error5;
  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public ResultOfTJsonSerializationTests()
  {
    _jsonSerializerOptions = new()
    {
      PropertyNameCaseInsensitive = true,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      NumberHandling = JsonNumberHandling.AllowReadingFromString
    };
    _fact1 = new Fact();
    _fact2 = new Fact("Fact 2", "F2");
    _fact3 = new Fact("Fact 3", "F3");
    _warning1 = new Warning();
    _warning2 = new Warning("Warning 2", "W2");
    _warning3 = new Warning("Warning 3", "W3");
    _error1 = new Error();
    _error2 = new Error("Error 2", code: "E2");
    _error3 = new Error("Error 3", code: "E3");
    _error4 = new Error(new InvalidOperationException("Error 4"));
    _error5 = new Error(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  [Fact]
  public void OkResultWithValueStruct()
  {
    // Arrange
    var facts = new List<Fact> { _fact3, _fact2, _fact1 };
    var warnings = new List<Warning> { _warning1, _warning3 };
    var statements = new Statements(facts, warnings);
    var resultOfTOriginal = Result<ValueStruct>.Ok(
      new ValueStruct() { Number = 42, String = "Meaning of life." })
      .WithStatements(statements);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, _jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueStruct>>(jsonString, _jsonSerializerOptions);


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
    var facts = new List<Fact> { _fact3, _fact2, _fact1 };
    var warnings = new List<Warning> { _warning1, _warning3 };
    var resultOfTOriginal = Result<ValueClass>.Ok(
      new ValueClass() { Number = 42, String = "Meaning of life." })
      .WithFacts(facts)
      .WithWarnings(warnings);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, _jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueClass>>(jsonString, _jsonSerializerOptions);


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
    var facts = new List<Fact> { _fact3, _fact2 };
    var warnings = new List<Warning> { _warning1, _warning3 };
    var resultOfTOriginal = Result<ValueRecord>.Ok(new(42, "Meaning of life."))
      .WithFacts(facts)
      .WithWarnings(warnings);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, _jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueRecord>>(jsonString, _jsonSerializerOptions);


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
    var facts = new List<Fact> { _fact1, _fact2, _fact3 };
    var warnings = new List<Warning> { _warning1, _warning2 };
    var errors = new List<Error> { _error2, _error5 };
    var resultOfTOriginal = new Result<ValueStruct>(
      false,
      default,
      new Failure(FailureType.Unavailable, errors),
      new Statements(facts, warnings));

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, _jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueStruct>>(jsonString, _jsonSerializerOptions);


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
    var facts = new List<Fact> { _fact3 };
    var warnings = new List<Warning> { _warning1, _warning2, _warning3 };
    var errors = new List<Error> { _error1, _error2, _error3, _error4, _error5 };
    var resultOfTOriginal = new Result<ValueClass>(
      false,
      null,
      new Failure(FailureType.Error, errors),
      new Statements(facts, warnings));

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, _jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueClass>>(jsonString, _jsonSerializerOptions);


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
    var facts = new List<Fact> { _fact1, _fact2 };
    var warnings = new List<Warning> { _warning1 };
    var errors = new List<Error> { _error1, _error2, _error5 };
    var resultOfTOriginal = new Result<ValueRecord>(
      false,
      null,
      new Failure(FailureType.Unspecified, errors),
      new Statements(facts, warnings));

    // Act
    var jsonString = JsonSerializer.Serialize(resultOfTOriginal, _jsonSerializerOptions);
    var resultOfT = JsonSerializer.Deserialize<Result<ValueRecord>>(jsonString, _jsonSerializerOptions);


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
