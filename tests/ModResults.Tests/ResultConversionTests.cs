namespace ModResults.Tests;

public class ResultConversionTests
{
  private readonly Fact fact1, fact2, fact3;
  private readonly Warning warning1, warning2, warning3;
  private readonly Error error1, error2;
  private readonly InvalidOperationException ex1;
  private readonly ApplicationException ex2;

  public ResultConversionTests()
  {
    fact1 = new Fact();
    fact2 = new Fact("Fact 2", "F2");
    fact3 = new Fact("Fact 3", "F3");
    warning1 = new Warning();
    warning2 = new Warning("Warning 2", "W2");
    warning3 = new Warning("Warning 3", "W3");
    error1 = new Error("Error 1");
    error2 = new Error("Error 2", code: "E2");
    ex1 = new InvalidOperationException("Error 4");
    ex2 = new ApplicationException("Error 5", new ArgumentException("Error 5 Inner"));
  }

  [Fact]
  public void OkResultToResultWithValueOnOk()
  {
    //Arrange
    var result = Result.Ok().WithFacts([fact1, fact2, fact3]).WithWarnings([warning1, warning2, warning3]);

    //Act
    var resultOfT = result.ToResult<ValueClass>(new ValueClass() { Number = 42, String = "Meaning of life." });

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
  public void FailedResultToResultWithValueOnOk()
  {
    //Arrange
    var resultOriginal = Result
      .Error(
        error1,
        error2,
        new Error(ex1),
        new Error(ex2))
      .WithFacts([fact1, fact2, fact3])
      .WithWarnings([warning1, warning2, warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult<ValueClass>(new ValueClass() { Number = 42, String = "Meaning of life." });

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
  public void OkResultToResultWithValueFuncOnOk()
  {
    //Arrange
    var resultOriginal = Result.Ok().WithFacts([fact1, fact2, fact3]).WithWarnings([warning1, warning2, warning3]);
    var item1 = 42;
    var item2 = "Meaning of life.";

    //Act
    var resultOfT = resultOriginal.ToResult<ValueClass>(
      () => new ValueClass() { Number = item1, String = item2 });

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
  public void FailedResultToResultWithValueFuncOnOk()
  {
    //Arrange
    var resultOriginal = Result
      .Error(
        error1,
        error2,
        new Error(ex1),
        new Error(ex2))
      .WithFacts([fact1, fact2, fact3])
      .WithWarnings([warning1, warning2, warning3]);
    var item1 = 42;
    var item2 = "Meaning of life.";

    //Act
    var resultOfT = resultOriginal.ToResult<ValueClass>(
      () => new ValueClass() { Number = item1, String = item2 });

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
  public void OkResultToResultWithValueFuncOnOkAndState()
  {
    //Arrange
    var resultOriginal = Result.Ok().WithFacts([fact1, fact2, fact3]).WithWarnings([warning1, warning2, warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult<(int, string), ValueClass>(
      (state) => new ValueClass() { Number = state.Item1, String = state.Item2 },
      (42, "Meaning of life."));

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
  public void FailedResultToResultWithValueFuncOnOkAndState()
  {
    //Arrange
    var resultOriginal = Result
      .Error(
        error1,
        error2,
        new Error(ex1),
        new Error(ex2))
      .WithFacts([fact1, fact2, fact3])
      .WithWarnings([warning1, warning2, warning3]);

    //Act
    var resultOfT = resultOriginal.ToResult<(int, string), ValueClass>(
      (state) => new ValueClass() { Number = state.Item1, String = state.Item2 },
      (42, "Meaning of life."));

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
  public async Task OkResultToResultWithValueFuncOnOkAsync()
  {
    //Arrange
    var resultOriginal = Result.Ok().WithFacts([fact1, fact2, fact3]).WithWarnings([warning1, warning2, warning3]);
    var item1 = 42;
    var item2 = "Meaning of life.";

    //Act
    var resultOfT = await resultOriginal.ToResultAsync<ValueClass>(
      async (ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = item1, String = item2 };
      },
      default);

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
  public async Task FailedResultToResultWithValueFuncOnOkAsync()
  {
    //Arrange
    var resultOriginal = Result
      .Error(
        error1,
        error2,
        new Error(ex1),
        new Error(ex2))
      .WithFacts([fact1, fact2, fact3])
      .WithWarnings([warning1, warning2, warning3]);
    var item1 = 42;
    var item2 = "Meaning of life.";

    //Act
    var resultOfT = await resultOriginal.ToResultAsync<ValueClass>(
      async (ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = item1, String = item2 };
      },
      default);

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
  public async Task OkResultToResultWithValueFuncOnOkAndStateAsync()
  {
    //Arrange
    var resultOriginal = Result.Ok().WithFacts([fact1, fact2, fact3]).WithWarnings([warning1, warning2, warning3]);

    //Act
    var resultOfT = await resultOriginal.ToResultAsync<(int, string), ValueClass>(
      async (state, ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = state.Item1, String = state.Item2 };
      },
      (42, "Meaning of life."),
      default);

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
  public async Task FailedResultToResultWithValueFuncOnOkAndStateAsync()
  {
    //Arrange
    var resultOriginal = Result
      .Error(
        error1,
        error2,
        new Error(ex1),
        new Error(ex2))
      .WithFacts([fact1, fact2, fact3])
      .WithWarnings([warning1, warning2, warning3]);

    //Act
    var resultOfT = await resultOriginal.ToResultAsync<(int, string), ValueClass>(
      async (state, ct) =>
      {
        await Task.Delay(1, ct);
        return new ValueClass() { Number = state.Item1, String = state.Item2 };
      },
      (42, "Meaning of life."),
      default);

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
