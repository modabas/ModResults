namespace ModResults.Orleans.Tests;

internal interface IFailedResultSerializationGrain : IGrainWithIntegerKey
{
  Task<FailedResult> FailedResultTest();
  Task<FailedResult> BasicFailedResult();
}
