namespace ModResults.Tests;

public class ResultOfTConversionTests
{
  private readonly Fact _fact1, _fact2, _fact3;
  private readonly Warning _warning1, _warning2, _warning3;
  private readonly Error _error1, _error2;
  private readonly InvalidOperationException _ex1;
  private readonly ApplicationException _ex2;

  public ResultOfTConversionTests()
  {
    _fact1 = new Fact();
    _fact2 = new Fact("Fact 2", "F2");
    _fact3 = new Fact("Fact 3", "F3");
    _warning1 = new Warning();
    _warning2 = new Warning("Warning 2", "W2");
    _warning3 = new Warning("Warning 3", "W3");
    _error1 = new Error("Error 1");
    _error2 = new Error("Error 2", code: "E2");
    _ex1 = new InvalidOperationException("Error 4");
    _ex2 = new ApplicationException("Error 5", new ArgumentException("Error 5 Inner"));
  }

  [Fact]
  public void OkResultOfTToResult()
  {
    //Arrange
    var resultOriginal = Result.Ok(new ValueClass() { Number = 42, String = "Meaning of life." }).WithFacts([_fact1, _fact2, _fact3]).WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var result = resultOriginal.ToResult();

    // Assert
    Assert.True(result.IsOk);
    Assert.False(result.IsFailed);
    Assert.Null(result.Failure);
    Assert.Equal(3, result.Statements.Facts.Count);
    Assert.Equal(string.Empty, result.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", result.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", result.Statements.Facts[2].Message);
    Assert.True(result.HasFact("F3"));
    Assert.False(result.HasFact("f3"));
    Assert.Equal(3, result.Statements.Warnings.Count);
    Assert.Equal(string.Empty, result.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", result.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", result.Statements.Warnings[2].Message);
    Assert.False(result.IsFailedWith(FailureType.Error));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith<ApplicationException>());
    Assert.False(result.IsFailedWith(typeof(InvalidOperationException)));
    Assert.False(result.IsFailedWith<InvalidCastException>());
    Assert.False(result.IsFailedWith<Exception>());
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
    Assert.False(result.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void FailedResultOfTToResult()
  {
    //Arrange
    var resultOriginal = Result<ValueClass>
      .Error(
        _error1,
        _error2,
        new Error(_ex1),
        new Error(_ex2))
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult();

    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.Equal(4, resultOfT.Failure.Errors.Count);
    Assert.Equal("Error 1", resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("Failure.Error"));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith<InvalidOperationException>());
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void OkResultOfTToResultWithValueOnOk()
  {
    //Arrange
    var result = Result.Ok(new ValueStruct() { Number = 42, String = "Meaning of life." }).WithFacts([_fact1, _fact2, _fact3]).WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = result.ToResult<ValueStruct, ValueClass>(
      (source) => new ValueClass() { Number = source.Number, String = source.String });

    // Assert
    Assert.True(resultOfT.IsOk);
    Assert.False(resultOfT.IsFailed);
    Assert.Null(resultOfT.Failure);
    Assert.NotNull(resultOfT.Value);
    Assert.Equal(42, resultOfT.Value.Number);
    Assert.Equal("Meaning of life.", resultOfT.Value.String);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.False(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith(typeof(InvalidOperationException)));
    Assert.False(resultOfT.IsFailedWith<InvalidCastException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.False(resultOfT.IsFailedWith<Exception>(true));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void FailedResultOfTToResultWithValueOnOk()
  {
    //Arrange
    var resultOriginal = Result<ValueStruct>
      .Error(
        _error1,
        _error2,
        new Error(_ex1),
        new Error(_ex2))
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult<ValueStruct, ValueClass>(
      (source) => new ValueClass() { Number = source.Number, String = source.String });

    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Null(resultOfT.Value);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.Equal(4, resultOfT.Failure.Errors.Count);
    Assert.Equal("Error 1", resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("Failure.Error"));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith<InvalidOperationException>());
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void OkResultOfTToResultWithValueFuncOnOk()
  {
    //Arrange
    var resultOriginal = Result
      .Ok(new ValueStruct() { Number = 42, String = "Meaning of life" })
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult<ValueStruct, string, ValueClass>(
      (source, state) => new ValueClass() { Number = source.Number, String = source.String + state },
      ("."));

    // Assert
    Assert.True(resultOfT.IsOk);
    Assert.False(resultOfT.IsFailed);
    Assert.Null(resultOfT.Failure);
    Assert.NotNull(resultOfT.Value);
    Assert.Equal(42, resultOfT.Value.Number);
    Assert.Equal("Meaning of life.", resultOfT.Value.String);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.False(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith(typeof(InvalidOperationException)));
    Assert.False(resultOfT.IsFailedWith<InvalidCastException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.False(resultOfT.IsFailedWith<Exception>(true));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public void FailedResultOfTToResultWithValueFuncOnOk()
  {
    //Arrange
    var resultOriginal = Result<ValueStruct>
      .Error(
        _error1,
        _error2,
        new Error(_ex1),
        new Error(_ex2))
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult<ValueStruct, string, ValueClass>(
      (source, state) => new ValueClass() { Number = source.Number, String = source.String + state },
      ("."));

    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Null(resultOfT.Value);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.Equal(4, resultOfT.Failure.Errors.Count);
    Assert.Equal("Error 1", resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("Failure.Error"));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith<InvalidOperationException>());
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public async Task OkResultOfTToResultWithValueFuncOnOkAsync()
  {
    //Arrange
    var resultOriginal = Result
      .Ok(new ValueStruct() { Number = 42, String = "Meaning of life" })
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);
    //Act
    var resultOfT = await resultOriginal.ToResultAsync<ValueStruct, ValueClass>(
      async (source, ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = source.Number, String = source.String + "." };
      },
      TestContext.Current.CancellationToken);

    // Assert
    Assert.True(resultOfT.IsOk);
    Assert.False(resultOfT.IsFailed);
    Assert.Null(resultOfT.Failure);
    Assert.NotNull(resultOfT.Value);
    Assert.Equal(42, resultOfT.Value.Number);
    Assert.Equal("Meaning of life.", resultOfT.Value.String);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.False(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith(typeof(InvalidOperationException)));
    Assert.False(resultOfT.IsFailedWith<InvalidCastException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.False(resultOfT.IsFailedWith<Exception>(true));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public async Task FailedResultOfTToResultWithValueFuncOnOkAsync()
  {
    //Arrange
    var resultOriginal = Result<ValueStruct>
      .Error(
        _error1,
        _error2,
        new Error(_ex1),
        new Error(_ex2))
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = await resultOriginal.ToResultAsync<ValueStruct, ValueClass>(
      async (source, ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = source.Number, String = source.String + "." };
      },
      TestContext.Current.CancellationToken);

    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Null(resultOfT.Value);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.Equal(4, resultOfT.Failure.Errors.Count);
    Assert.Equal("Error 1", resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("Failure.Error"));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith<InvalidOperationException>());
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public async Task OkResultOfTToResultWithValueFuncOnOkAndStateAsync()
  {
    //Arrange
    var resultOriginal = Result
      .Ok(new ValueStruct() { Number = 42, String = "Meaning of life" })
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);
    //Act
    var resultOfT = await resultOriginal.ToResultAsync<ValueStruct, string, ValueClass>(
      async (source, state, ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = source.Number, String = source.String + state };
      },
      ("."),
      TestContext.Current.CancellationToken);

    // Assert
    Assert.True(resultOfT.IsOk);
    Assert.False(resultOfT.IsFailed);
    Assert.Null(resultOfT.Failure);
    Assert.NotNull(resultOfT.Value);
    Assert.Equal(42, resultOfT.Value.Number);
    Assert.Equal("Meaning of life.", resultOfT.Value.String);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.False(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith<ApplicationException>());
    Assert.False(resultOfT.IsFailedWith(typeof(InvalidOperationException)));
    Assert.False(resultOfT.IsFailedWith<InvalidCastException>());
    Assert.False(resultOfT.IsFailedWith<Exception>());
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.False(resultOfT.IsFailedWith<Exception>(true));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception), true));
  }

  [Fact]
  public async Task FailedResultOfTToResultWithValueFuncOnOkAndStateAsync()
  {
    //Arrange
    var resultOriginal = Result<ValueStruct>
      .Error(
        _error1,
        _error2,
        new Error(_ex1),
        new Error(_ex2))
      .WithFacts([_fact1, _fact2, _fact3])
      .WithWarnings([_warning1, _warning2, _warning3]);

    //Act
    var resultOfT = await resultOriginal.ToResultAsync<ValueStruct, string, ValueClass>(
      async (source, state, ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = source.Number, String = source.String + state };
      },
      ("."),
      TestContext.Current.CancellationToken);

    // Assert
    Assert.NotNull(resultOfT);
    Assert.False(resultOfT.IsOk);
    Assert.True(resultOfT.IsFailed);
    Assert.NotNull(resultOfT.Failure);
    Assert.Null(resultOfT.Value);
    Assert.Equal(3, resultOfT.Statements.Facts.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Facts[0].Message);
    Assert.Equal("Fact 2", resultOfT.Statements.Facts[1].Message);
    Assert.Equal("Fact 3", resultOfT.Statements.Facts[2].Message);
    Assert.True(resultOfT.HasFact("F3"));
    Assert.False(resultOfT.HasFact("f3"));
    Assert.Equal(3, resultOfT.Statements.Warnings.Count);
    Assert.Equal(string.Empty, resultOfT.Statements.Warnings[0].Message);
    Assert.Equal("Warning 2", resultOfT.Statements.Warnings[1].Message);
    Assert.Equal("Warning 3", resultOfT.Statements.Warnings[2].Message);
    Assert.Equal(4, resultOfT.Failure.Errors.Count);
    Assert.Equal("Error 1", resultOfT.Failure.Errors[0].Message);
    Assert.Equal("Error 2", resultOfT.Failure.Errors[1].Message);
    Assert.True(resultOfT.IsFailedWith(FailureType.Error));
    Assert.False(resultOfT.IsFailedWith(FailureType.Unspecified));
    Assert.False(resultOfT.IsFailedWith("Failure.Error"));
    Assert.True(resultOfT.IsFailedWith("E2"));
    Assert.False(resultOfT.IsFailedWith("e2"));
    Assert.False(resultOfT.IsFailedWith(typeof(Exception)));
    Assert.True(resultOfT.IsFailedWith<Exception>(true));
    Assert.True(resultOfT.IsFailedWith<InvalidOperationException>());
    Assert.True(resultOfT.IsFailedWith<ApplicationException>());
  }

}
