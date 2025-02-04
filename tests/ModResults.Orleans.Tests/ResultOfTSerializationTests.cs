using Orleans.TestingHost;

namespace ModResults.Orleans.Tests;


[Collection(ClusterCollection.Name)]
public class ResultOfTSerializationTests
{
  private readonly TestCluster _cluster;

  public ResultOfTSerializationTests(ClusterFixture fixture)
  {
    _cluster = fixture.Cluster;
  }

  [Fact]
  public async Task OkResultWithValueStructAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var resultOfT = await testGrain.OkResultWithValueStruct();

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
  public async Task OkResultWithValueClassAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var resultOfT = await testGrain.OkResultWithValueClass();

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
  public async Task OkResultWithValueRecordAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var resultOfT = await testGrain.OkResultWithValueRecord();

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
  public async Task FailedResultWithValueStructAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var resultOfT = await testGrain.FailedResultWithValueStruct();

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
  public async Task FailedResultWithValueClassAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var resultOfT = await testGrain.FailedResultWithValueClass();

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
  public async Task FailedResultWithValueRecordAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IResultOfTSerializationGrain>(0);

    // Act
    var resultOfT = await testGrain.FailedResultWithValueRecord();

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
