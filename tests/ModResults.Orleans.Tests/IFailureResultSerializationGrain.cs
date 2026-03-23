namespace ModResults.Orleans.Tests;

internal interface IFailureResultSerializationGrain : IGrainWithIntegerKey
{
  Task<FailureResult> FailedResult();
  Task<FailureResult> BasicFailedResult();
}
