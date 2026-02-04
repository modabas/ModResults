namespace ModResults.Tests;

public class FactTests
{
  private readonly Fact _fact1, _fact2, _fact3;

  public FactTests()
  {
    _fact1 = new Fact();
    _fact2 = new Fact("Fact 2", "F2");
    _fact3 = new Fact("Fact 3", "F3");
  }

  [Fact]
  public void ResultHasFact()
  {
    // Arrange
    var result = Result.Ok().WithFacts([_fact1, _fact2]).WithFact(_fact3);

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.False(result.HasFact("f2"));
    Assert.True(result.HasFact("F2"));
    Assert.True(result.HasFact("F3", out var facts));
    Assert.Single(facts);
    Assert.Equal("Fact 3", facts[0].Message);
    Assert.True(facts[0].HasCode("F3", StringComparison.Ordinal));
    Assert.False(facts[0].HasCode("f3", StringComparison.Ordinal));
  }

  [Fact]
  public void ResultHasFactFromString()
  {
    // Arrange
    var result = Result.Ok().WithFacts([string.Empty, "Fact 2"]).WithFact("Fact 3");

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.False(result.HasFact("f2"));
    Assert.False(result.HasFact("F2"));
    Assert.False(result.HasFact("F3", out var facts));
    Assert.Empty(facts);
  }

  [Fact]
  public void ResultHasFactFrom()
  {
    // Arrange
    var resultOriginal = Result.Ok(new ValueStruct() { Number = 42, String = "Meaning of life." }).WithFacts([_fact1, _fact2]).WithFact(_fact3);

    var result = Result.Ok().WithFactsFrom(resultOriginal);

    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.False(result.HasFact("f2"));
    Assert.True(result.HasFact("F2"));
    Assert.True(result.HasFact("F3", out var facts));
    Assert.Single(facts);
    Assert.Equal("Fact 3", facts[0].Message);
    Assert.True(facts[0].HasCode("F3", StringComparison.Ordinal));
    Assert.False(facts[0].HasCode("f3", StringComparison.Ordinal));
  }

  [Fact]
  public void ResultOfTHasFact()
  {
    // Arrange
    var result = Result<ValueClass>.Error().WithFacts([_fact1, _fact2]).WithFact(_fact3);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.False(result.HasFact("f2"));
    Assert.True(result.HasFact("F2"));
    Assert.True(result.HasFact("F3", out var facts));
    Assert.Single(facts);
    Assert.Equal("Fact 3", facts[0].Message);
    Assert.True(facts[0].HasCode("F3", StringComparison.Ordinal));
    Assert.False(facts[0].HasCode("f3", StringComparison.Ordinal));
  }

  [Fact]
  public void ResultOfTHasFactFromString()
  {
    // Arrange
    var result = Result<ValueClass>.Error().WithFacts([string.Empty, "Fact 2"]).WithFact("Fact 3");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.False(result.HasFact("f2"));
    Assert.False(result.HasFact("F2"));
    Assert.False(result.HasFact("F3", out var facts));
    Assert.Empty(facts);
  }

  [Fact]
  public void ResultOfTHasFactFrom()
  {
    // Arrange
    var resultOriginal = Result.Ok(new ValueStruct() { Number = 42, String = "Meaning of life." }).WithFacts([_fact1, _fact2]).WithFact(_fact3);

    var result = Result<ValueClass>.Error().WithFactsFrom(resultOriginal);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.False(result.HasFact("f2"));
    Assert.True(result.HasFact("F2"));
    Assert.True(result.HasFact("F3", out var facts));
    Assert.Single(facts);
    Assert.Equal("Fact 3", facts[0].Message);
    Assert.True(facts[0].HasCode("F3", StringComparison.Ordinal));
    Assert.False(facts[0].HasCode("f3", StringComparison.Ordinal));
  }
}
