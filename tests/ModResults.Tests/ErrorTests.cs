namespace ModResults.Tests;
public class ErrorTests
{
  private readonly ApplicationException ex1;
  private readonly ArgumentNullException ex2;

  public ErrorTests()
  {
    ex1 = new ApplicationException("Error 5", new ArgumentException("Error 5 Inner"));
    ex2 = new ArgumentNullException();
  }

  [Fact]
  public void ErrorCtorFromException()
  {
    // Arrange
    var error = new Error(ex1, 10, "E1", "P1");

    Assert.True(error.IsFromException);
    Assert.True(error.HasCode("E1", StringComparison.Ordinal));
    Assert.False(error.HasCode("e1", StringComparison.Ordinal));
    Assert.Equal(ex1.Message, error.Message);
    Assert.NotNull(error.PropertyName);
    Assert.Equal("P1", error.PropertyName);
    Assert.True(error.HasException<ApplicationException>());
    Assert.True(error.HasException<ApplicationException>(true));
    Assert.True(error.HasException(typeof(ApplicationException)));
    Assert.True(error.HasException(typeof(ApplicationException), true));
    Assert.False(error.HasException<InvalidOperationException>());
    Assert.False(error.HasException<InvalidOperationException>(true));
    Assert.False(error.HasException(typeof(InvalidOperationException)));
    Assert.False(error.HasException(typeof(InvalidOperationException), true));
    Assert.False(error.HasException<Exception>());
    Assert.True(error.HasException<Exception>(true));
    Assert.False(error.HasException(typeof(Exception)));
    Assert.True(error.HasException(typeof(Exception), true));
    Assert.False(error.HasException(typeof(ValueClass)));
    Assert.False(error.HasException(typeof(ValueClass), true));
  }

  [Fact]
  public void ErrorCtorFromExceptionTypeName()
  {
    // Arrange
    var exceptionTypeName = ex1.GetType().AssemblyQualifiedName;
    var errorMessage = ex1.Message;
    Error innerError = new Error(ex1.InnerException!, 10, null, null);
    var error = new Error(errorMessage, exceptionTypeName, innerError, "E1", "P1");

    Assert.True(error.IsFromException);
    Assert.True(error.HasCode("E1", StringComparison.Ordinal));
    Assert.False(error.HasCode("e1", StringComparison.Ordinal));
    Assert.Equal(ex1.Message, error.Message);
    Assert.NotNull(error.PropertyName);
    Assert.Equal("P1", error.PropertyName);
    Assert.True(error.HasException<ApplicationException>());
    Assert.True(error.HasException<ApplicationException>(true));
    Assert.True(error.HasException(typeof(ApplicationException)));
    Assert.True(error.HasException(typeof(ApplicationException), true));
    Assert.False(error.HasException<InvalidOperationException>());
    Assert.False(error.HasException<InvalidOperationException>(true));
    Assert.False(error.HasException(typeof(InvalidOperationException)));
    Assert.False(error.HasException(typeof(InvalidOperationException), true));
    Assert.False(error.HasException<Exception>());
    Assert.True(error.HasException<Exception>(true));
    Assert.False(error.HasException(typeof(Exception)));
    Assert.True(error.HasException(typeof(Exception), true));
    Assert.False(error.HasException(typeof(ValueClass)));
    Assert.False(error.HasException(typeof(ValueClass), true));
  }

  [Fact]
  public void ResultHasError()
  {
    // Arrange
    var error1 = new Error(ex1, 10, "E1", "P1");
    var error2 = new Error("Error 2", code: "E2");
    var error3 = new Error(ex2, 10, "E3", "P3");
    var errors = new List<Error> { error1, error2, error3 };
    var result = Result.Forbidden(errors.ToArray());


    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);

    Assert.True(result.HasErrorWithException<ApplicationException>());
    Assert.True(result.HasErrorWithException<ApplicationException>(true));
    Assert.True(result.HasErrorWithException(typeof(ApplicationException)));
    Assert.True(result.HasErrorWithException(typeof(ApplicationException), true));
    Assert.False(result.HasErrorWithException<InvalidOperationException>());
    Assert.False(result.HasErrorWithException<InvalidOperationException>(true));
    Assert.False(result.HasErrorWithException(typeof(InvalidOperationException)));
    Assert.False(result.HasErrorWithException(typeof(InvalidOperationException), true));
    Assert.False(result.HasErrorWithException<Exception>());
    Assert.True(result.HasErrorWithException<Exception>(true));
    Assert.False(result.HasErrorWithException(typeof(Exception)));
    Assert.True(result.HasErrorWithException(typeof(Exception), true));
    Assert.False(result.HasErrorWithException(typeof(ValueClass)));
    Assert.False(result.HasErrorWithException(typeof(ValueClass), true));
    Assert.True(result.HasErrorWithException<Exception>(out var matchedErrors, true));
    Assert.Equal(2, matchedErrors.Count);
    Assert.True(result.HasErrorWithException(typeof(ApplicationException), out matchedErrors, true));
    Assert.Single(matchedErrors);

    Assert.True(result.HasError("E1"));
    Assert.False(result.HasError("e1"));
    Assert.True(result.HasError("E2"));
    Assert.True(result.HasError("E3", out matchedErrors));
    Assert.Single(matchedErrors);
    Assert.False(result.HasError("e3", out matchedErrors));
    Assert.Empty(matchedErrors);
  }

  //[Fact]
  //public void ResultOfTHasError()
  //{
  //  // Arrange
  //  var error1 = new Error(ex1, 10, "E1", "P1");
  //  var error2 = new Error("Error 2", code: "E2");
  //  var error3 = new Error(ex2, 10, "E3", "P3");
  //  var errors = new List<Error> { error1, error2, error3 };
  //  var resultOfT = Result<ValueStruct>.Forbidden(errors.ToArray());


  //  // Assert
  //  Assert.NotNull(resultOfT);
  //  Assert.False(resultOfT.IsOk);
  //  Assert.True(resultOfT.IsFailed);
  //  Assert.NotNull(resultOfT.Failure);
  //  Assert.True(resultOfT.HasErrorWithException<ApplicationException>());
  //  Assert.True(resultOfT.HasErrorWithException<ApplicationException>(true));
  //  Assert.True(resultOfT.HasErrorWithException(typeof(ApplicationException)));
  //  Assert.True(resultOfT.HasErrorWithException(typeof(ApplicationException), true));
  //  Assert.False(resultOfT.HasErrorWithException<InvalidOperationException>());
  //  Assert.False(resultOfT.HasErrorWithException<InvalidOperationException>(true));
  //  Assert.False(resultOfT.HasErrorWithException(typeof(InvalidOperationException)));
  //  Assert.False(resultOfT.HasErrorWithException(typeof(InvalidOperationException), true));
  //  Assert.False(resultOfT.HasErrorWithException<Exception>());
  //  Assert.True(resultOfT.HasErrorWithException<Exception>(true));
  //  Assert.False(resultOfT.HasErrorWithException(typeof(Exception)));
  //  Assert.True(resultOfT.HasErrorWithException(typeof(Exception), true));
  //  Assert.False(resultOfT.HasErrorWithException(typeof(ValueClass)));
  //  Assert.False(resultOfT.HasErrorWithException(typeof(ValueClass), true));
  //  Assert.True(resultOfT.HasErrorWithException<Exception>(out var matchedErrors, true));
  //  Assert.Equal(2, matchedErrors.Count);
  //  Assert.True(resultOfT.HasErrorWithException(typeof(ApplicationException), out matchedErrors, true));
  //  Assert.Single(matchedErrors);
  //}
}
