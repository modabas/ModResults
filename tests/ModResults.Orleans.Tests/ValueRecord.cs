namespace ModResults.Orleans.Tests;

[GenerateSerializer]
[Alias("ModResults.Orleans.Tests.ValueRecord")]
internal record ValueRecord(int Number, string String);

