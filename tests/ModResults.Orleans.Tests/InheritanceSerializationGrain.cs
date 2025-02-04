namespace ModResults.Orleans.Tests;
internal class InheritanceSerializationGrain : IInheritanceSerializationGrain
{
  public Task<ErrorChild> GetErrorChild(string message, string? code, string extra)
  {
    //Arrange
    var error = new ErrorChild(message, code, extra);

    //Act
    return Task.FromResult(error);
  }

  public Task<FactChild> GetFactChild(string message, string? code, string extra)
  {
    //Arrange
    var fact = new FactChild(message, code, extra);
    //Act
    return Task.FromResult(fact);
  }

  public Task<WarningChild> GetWarningChild(string message, string? code, string extra)
  {
    //Arrange
    var warning = new WarningChild(message, code, extra);
    //Act
    return Task.FromResult(warning);
  }
}
