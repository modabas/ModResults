using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModResults.Tests;

public class ResultJsonSerializationTests
{
  private readonly Fact _fact1, _fact2, _fact3;
  private readonly Warning _warning1, _warning2, _warning3;
  private readonly Error _error1, _error2, _error5;
  private readonly JsonSerializerOptions _jsonSerializerOptions;

  public ResultJsonSerializationTests()
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
    _error5 = new Error(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  [Fact]
  public void OkResult()
  {
    // Arrange
    var facts = new List<Fact> { _fact1, _fact2, _fact3 };
    var warnings = new List<Warning> { _warning1, _warning2, _warning3 };
    var statements = new Statements(facts, warnings);
    var resultOriginal = Result.Ok().WithStatements(statements);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOriginal, _jsonSerializerOptions);
    var result = JsonSerializer.Deserialize<Result>(jsonString, _jsonSerializerOptions);

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
  }

  [Fact]
  public void FailedResult()
  {
    // Arrange
    var errors = new List<Error> { _error1, _error2, _error5 };
    var resultOriginal = Result.Error(errors.ToArray()).WithFact(_fact1).WithWarning(_warning3);

    // Act
    var jsonString = JsonSerializer.Serialize(resultOriginal, _jsonSerializerOptions);
    var result = JsonSerializer.Deserialize<Result>(jsonString, _jsonSerializerOptions);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Single(result.Statements.Facts);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Single(result.Statements.Warnings);
    Assert.Equal("Warning 3", result.Statements.Warnings[0].Message);
    Assert.Equal(3, result.Failure.Errors.Count);
    Assert.Equal(string.Empty, result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.Equal("Error 5", result.Failure.Errors[2].Message);
    Assert.True(result.IsFailedWith(FailureType.Error));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.True(result.IsFailedWith<ApplicationException>());
    Assert.False(result.IsFailedWith<Exception>());
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith(typeof(Exception), true));
    Assert.False(result.IsFailedWith(typeof(ArgumentException)));
    Assert.False(result.IsFailedWith<ArgumentException>(true));
  }

}
