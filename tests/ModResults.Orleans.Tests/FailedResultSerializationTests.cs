using Orleans.TestingHost;

namespace ModResults.Orleans.Tests;

[Collection(ClusterCollection.Name)]
public class FailedResultSerializationTests
{
  private readonly TestCluster _cluster;

  public FailedResultSerializationTests(ClusterFixture fixture)
  {
    _cluster = fixture.Cluster;
  }

  [Fact]
  public async Task FailedResultAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IFailedResultSerializationGrain>(0);

    // Act
    var result = await testGrain.FailedResultTest();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.True(result.HasStatements());
    Assert.True(result.HasFacts());
    Assert.True(result.HasWarnings());
    Assert.True(result.Failure.HasErrors());
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

  [Fact]
  public async Task BasicFailedResultAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IFailedResultSerializationGrain>(0);

    // Act
    var result = await testGrain.BasicFailedResult();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.False(result.HasFacts());
    Assert.False(result.HasWarnings());
    Assert.False(result.HasStatements());
    Assert.False(result.Failure.HasErrors());
    Assert.True(result.IsFailedWith(FailureType.Error));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith<Exception>());
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith(typeof(ArgumentException)));
    Assert.False(result.IsFailedWith<ArgumentException>(true));
  }
}
