namespace ModResults.Orleans.Tests;
internal interface IInheritanceSerializationGrain : IGrainWithIntegerKey
{
  Task<ErrorChild> GetErrorChild(string message, string? code, string extra);
  Task<FactChild> GetFactChild(string message, string? code, string extra);
  Task<WarningChild> GetWarningChild(string message, string? code, string extra);
}
