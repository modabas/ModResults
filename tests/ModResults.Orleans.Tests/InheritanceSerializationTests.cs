using Orleans.TestingHost;

namespace ModResults.Orleans.Tests;

[Collection(ClusterCollection.Name)]
public class InheritanceSerializationTests
{
  private readonly TestCluster _cluster;

  public InheritanceSerializationTests(ClusterFixture fixture)
  {
    _cluster = fixture.Cluster;
  }

  [Fact]
  public async Task WarningInheritanceAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IInheritanceSerializationGrain>(0);
    // Act
    var warning = await testGrain.GetWarningChild("Warning Message", "Warning Code", "Warning Extra");

    // Assert
    Assert.Equal("Warning Message", warning.Message);
    Assert.NotEqual("Warning message", warning.Message);
    Assert.Equal("Warning Code", warning.Code);
    Assert.NotEqual("Warning code", warning.Code);
    Assert.Equal("Warning Extra", warning.Extra);
    Assert.NotEqual("Warning extra", warning.Extra);
  }

  [Fact]
  public async Task ErrorInheritanceAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IInheritanceSerializationGrain>(0);
    // Act
    var error = await testGrain.GetErrorChild("Error Message", "Error Code", "Error Extra");

    // Assert
    Assert.Equal("Error Message", error.Message);
    Assert.NotEqual("Error message", error.Message);
    Assert.Equal("Error Code", error.Code);
    Assert.NotEqual("Error code", error.Code);
    Assert.Equal("Error Extra", error.Extra);
    Assert.NotEqual("Error extra", error.Extra);
  }

  [Fact]
  public async Task FactInheritanceAsync()
  {
    // Arrange
    var testGrain = _cluster.GrainFactory.GetGrain<IInheritanceSerializationGrain>(0);
    // Act
    var fact = await testGrain.GetFactChild("Fact Message", "Fact Code", "Fact Extra");

    // Assert
    Assert.Equal("Fact Message", fact.Message);
    Assert.NotEqual("Fact message", fact.Message);
    Assert.Equal("Fact Code", fact.Code);
    Assert.NotEqual("Fact code", fact.Code);
    Assert.Equal("Fact Extra", fact.Extra);
    Assert.NotEqual("Fact extra", fact.Extra);
  }
}
