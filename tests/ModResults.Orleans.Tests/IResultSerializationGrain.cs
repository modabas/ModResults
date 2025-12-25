namespace ModResults.Orleans.Tests;

internal interface IResultSerializationGrain : IGrainWithIntegerKey
{
  Task<Result> OkResult();
  Task<Result> FailedResult();
}
