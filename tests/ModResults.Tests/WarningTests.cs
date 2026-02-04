namespace ModResults.Tests;

public class WarningTests
{
  private readonly Warning _warning1, _warning2, _warning3;

  public WarningTests()
  {
    _warning1 = new Warning();
    _warning2 = new Warning("Warning 2", "W2");
    _warning3 = new Warning("Warning 3", "W3");
  }

  [Fact]
  public void ResultHasWarning()
  {
    // Arrange
    var result = Result.Ok().WithWarnings([_warning1, _warning2]).WithWarning(_warning3);

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
    Assert.False(result.HasWarning("w2"));
    Assert.True(result.HasWarning("W2"));
    Assert.True(result.HasWarning("W3", out var warnings));
    Assert.Single(warnings);
    Assert.Equal("Warning 3", warnings[0].Message);
    Assert.True(warnings[0].HasCode("W3", StringComparison.Ordinal));
    Assert.False(warnings[0].HasCode("w3", StringComparison.Ordinal));
  }

  [Fact]
  public void ResultHasWarningFromString()
  {
    // Arrange
    var result = Result.Ok().WithWarnings([string.Empty, "Warning 2"]).WithWarning("Warning 3");

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
    Assert.False(result.HasWarning("w2"));
    Assert.False(result.HasWarning("W2"));
    Assert.False(result.HasWarning("W3", out var warnings));
    Assert.Empty(warnings);
  }

  [Fact]
  public void ResultHasWarningFrom()
  {
    // Arrange
    var resultOriginal = Result.Ok(new ValueStruct() { Number = 42, String = "Meaning of life." })
      .WithWarnings([_warning1, _warning2]).WithWarning(_warning3);
    var result = Result.Ok().WithWarningsFrom(resultOriginal);

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
    Assert.False(result.HasWarning("w2"));
    Assert.True(result.HasWarning("W2"));
    Assert.True(result.HasWarning("W3", out var warnings));
    Assert.Single(warnings);
    Assert.Equal("Warning 3", warnings[0].Message);
    Assert.True(warnings[0].HasCode("W3", StringComparison.Ordinal));
    Assert.False(warnings[0].HasCode("w3", StringComparison.Ordinal));
  }

  [Fact]
  public void ResultOfTHasWarning()
  {
    // Arrange
    var result = Result<ValueClass>.Error().WithWarnings([_warning1, _warning2]).WithWarning(_warning3);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
    Assert.False(result.HasWarning("w2"));
    Assert.True(result.HasWarning("W2"));
    Assert.True(result.HasWarning("W3", out var warnings));
    Assert.Single(warnings);
    Assert.Equal("Warning 3", warnings[0].Message);
    Assert.True(warnings[0].HasCode("W3", StringComparison.Ordinal));
    Assert.False(warnings[0].HasCode("w3", StringComparison.Ordinal));
  }

  [Fact]
  public void ResultOfTHasWarningFromString()
  {
    // Arrange
    var result = Result<ValueClass>.Error().WithWarnings([string.Empty, "Warning 2"]).WithWarning("Warning 3");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
    Assert.False(result.HasWarning("w2"));
    Assert.False(result.HasWarning("W2"));
    Assert.False(result.HasWarning("W3", out var warnings));
    Assert.Empty(warnings);
  }

  [Fact]
  public void ResultOfTHasWarningFrom()
  {
    // Arrange
    var resultOriginal = Result.Ok(new ValueStruct() { Number = 42, String = "Meaning of life." })
      .WithWarnings([_warning1, _warning2]).WithWarning(_warning3);
    var result = Result<ValueClass>.Error().WithWarningsFrom(resultOriginal);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
    Assert.False(result.HasWarning("w2"));
    Assert.True(result.HasWarning("W2"));
    Assert.True(result.HasWarning("W3", out var warnings));
    Assert.Single(warnings);
    Assert.Equal("Warning 3", warnings[0].Message);
    Assert.True(warnings[0].HasCode("W3", StringComparison.Ordinal));
    Assert.False(warnings[0].HasCode("w3", StringComparison.Ordinal));
  }
}
