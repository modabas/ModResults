namespace ModResults.Orleans.Tests;

internal interface IResultOfTSerializationGrain : IGrainWithIntegerKey
{
  Task<Result<ValueClass>> FailedResultWithValueClass();
  Task<Result<ValueRecord>> FailedResultWithValueRecord();
  Task<Result<ValueStruct>> FailedResultWithValueStruct();
  Task<Result<ValueClass>> OkResultWithValueClass();
  Task<Result<ValueRecord>> OkResultWithValueRecord();
  Task<Result<ValueStruct>> OkResultWithValueStruct();
}
