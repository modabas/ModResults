namespace ModResults.Tests;

public class FailureResultExtensionTests
{
  private readonly Error _error1, _error2;
  private readonly InvalidOperationException _ex1;
  private readonly ApplicationException _ex2;

  public FailureResultExtensionTests()
  {
    _error1 = new Error("Error 1");
    _error2 = new Error("Error 2", code: "E2");
    _ex1 = new InvalidOperationException("Error 4");
    _ex2 = new ApplicationException("Error 5", new ArgumentException("Error 5 Inner"));
  }

  [Fact]
  public void Error()
  {
    // Arrange
    var result = FailureResult.Error();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.Error));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Error"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ErrorWithMessages()
  {
    // Arrange
    var result = FailureResult.Error("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Error));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Error"));
    Assert.False(result.IsFailedWith("failure.Error"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ErrorWithErrors()
  {
    // Arrange
    var result = FailureResult.Error(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Error));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Error"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ErrorWithExceptions()
  {
    // Arrange
    var result = FailureResult.Error(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Error));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Error"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void Forbidden()
  {
    // Arrange
    var result = FailureResult.Forbidden();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Forbidden"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ForbiddenWithMessages()
  {
    // Arrange
    var result = FailureResult.Forbidden("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Forbidden"));
    Assert.False(result.IsFailedWith("failure.Forbidden"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ForbiddenWithErrors()
  {
    // Arrange
    var result = FailureResult.Forbidden(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Forbidden"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ForbiddenWithExceptions()
  {
    // Arrange
    var result = FailureResult.Forbidden(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Forbidden"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void Unauthorized()
  {
    // Arrange
    var result = FailureResult.Unauthorized();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.Unauthorized));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Unauthorized"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void UnauthorizedWithMessages()
  {
    // Arrange
    var result = FailureResult.Unauthorized("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Unauthorized));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Unauthorized"));
    Assert.False(result.IsFailedWith("failure.Unauthorized"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void UnauthorizedWithErrors()
  {
    // Arrange
    var result = FailureResult.Unauthorized(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Unauthorized));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Unauthorized"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void UnauthorizedWithExceptions()
  {
    // Arrange
    var result = FailureResult.Unauthorized(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Unauthorized));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Unauthorized"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void Invalid()
  {
    // Arrange
    var result = FailureResult.Invalid();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.Invalid));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Invalid"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void InvalidWithMessages()
  {
    // Arrange
    var result = FailureResult.Invalid("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Invalid));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Invalid"));
    Assert.False(result.IsFailedWith("failure.Invalid"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void InvalidWithErrors()
  {
    // Arrange
    var result = FailureResult.Invalid(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Invalid));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Invalid"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void InvalidWithExceptions()
  {
    // Arrange
    var result = FailureResult.Invalid(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Invalid));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Invalid"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void NotFound()
  {
    // Arrange
    var result = FailureResult.NotFound();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.NotFound));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.NotFound"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void NotFoundWithMessages()
  {
    // Arrange
    var result = FailureResult.NotFound("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.NotFound));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.NotFound"));
    Assert.False(result.IsFailedWith("failure.NotFound"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void NotFoundWithErrors()
  {
    // Arrange
    var result = FailureResult.NotFound(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.NotFound));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.NotFound"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void NotFoundWithExceptions()
  {
    // Arrange
    var result = FailureResult.NotFound(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.NotFound));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.NotFound"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void Conflict()
  {
    // Arrange
    var result = FailureResult.Conflict();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.Conflict));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Conflict"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ConflictWithMessages()
  {
    // Arrange
    var result = FailureResult.Conflict("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Conflict));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Conflict"));
    Assert.False(result.IsFailedWith("failure.Conflict"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ConflictWithErrors()
  {
    // Arrange
    var result = FailureResult.Conflict(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Conflict));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Conflict"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void ConflictWithExceptions()
  {
    // Arrange
    var result = FailureResult.Conflict(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Conflict));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Conflict"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void CriticalError()
  {
    // Arrange
    var result = FailureResult.CriticalError();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.CriticalError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.CriticalError"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void CriticalErrorWithMessages()
  {
    // Arrange
    var result = FailureResult.CriticalError("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.CriticalError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.CriticalError"));
    Assert.False(result.IsFailedWith("failure.CriticalError"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void CriticalErrorWithErrors()
  {
    // Arrange
    var result = FailureResult.CriticalError(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.CriticalError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.CriticalError"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void CriticalErrorWithExceptions()
  {
    // Arrange
    var result = FailureResult.CriticalError(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.CriticalError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.CriticalError"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void Unavailable()
  {
    // Arrange
    var result = FailureResult.Unavailable();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.Unavailable));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Unavailable"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void UnavailableWithMessages()
  {
    // Arrange
    var result = FailureResult.Unavailable("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Unavailable));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Unavailable"));
    Assert.False(result.IsFailedWith("failure.Unavailable"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void UnavailableWithErrors()
  {
    // Arrange
    var result = FailureResult.Unavailable(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Unavailable));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Unavailable"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void UnavailableWithExceptions()
  {
    // Arrange
    var result = FailureResult.Unavailable(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.Unavailable));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.Unavailable"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void GatewayError()
  {
    // Arrange
    var result = FailureResult.GatewayError();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.GatewayError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.GatewayError"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void GatewayErrorWithMessages()
  {
    // Arrange
    var result = FailureResult.GatewayError("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.GatewayError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.GatewayError"));
    Assert.False(result.IsFailedWith("failure.GatewayError"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void GatewayErrorWithErrors()
  {
    // Arrange
    var result = FailureResult.GatewayError(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.GatewayError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.GatewayError"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void GatewayErrorWithExceptions()
  {
    // Arrange
    var result = FailureResult.GatewayError(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.GatewayError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.GatewayError"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void RateLimited()
  {
    // Arrange
    var result = FailureResult.RateLimited();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.RateLimited));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.RateLimited"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void RateLimitedWithMessages()
  {
    // Arrange
    var result = FailureResult.RateLimited("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.RateLimited));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.RateLimited"));
    Assert.False(result.IsFailedWith("failure.RateLimited"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void RateLimitedWithErrors()
  {
    // Arrange
    var result = FailureResult.RateLimited(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.RateLimited));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.RateLimited"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void RateLimitedWithExceptions()
  {
    // Arrange
    var result = FailureResult.RateLimited(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.RateLimited));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.RateLimited"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void TimedOut()
  {
    // Arrange
    var result = FailureResult.TimedOut();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.TimedOut));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.TimedOut"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void TimedOutWithMessages()
  {
    // Arrange
    var result = FailureResult.TimedOut("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.TimedOut));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.TimedOut"));
    Assert.False(result.IsFailedWith("failure.TimedOut"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void TimedOutWithErrors()
  {
    // Arrange
    var result = FailureResult.TimedOut(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.TimedOut));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.TimedOut"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void TimedOutWithExceptions()
  {
    // Arrange
    var result = FailureResult.TimedOut(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.TimedOut));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.TimedOut"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void PaymentRequired()
  {
    // Arrange
    var result = FailureResult.PaymentRequired();

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.PaymentRequired));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.PaymentRequired"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void PaymentRequiredWithMessages()
  {
    // Arrange
    var result = FailureResult.PaymentRequired("Error1", "Error2");

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error1", result.Failure.Errors[0].Message);
    Assert.Equal("Error2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.PaymentRequired));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.PaymentRequired"));
    Assert.False(result.IsFailedWith("failure.PaymentRequired"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void PaymentRequiredWithErrors()
  {
    // Arrange
    var result = FailureResult.PaymentRequired(_error1, _error2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 1", result.Failure.Errors[0].Message);
    Assert.Equal("Error 2", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.PaymentRequired));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.PaymentRequired"));
    Assert.True(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }

  [Fact]
  public void PaymentRequiredWithExceptions()
  {
    // Arrange
    var result = FailureResult.PaymentRequired(_ex1, _ex2);

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Equal(2, result.Failure.Errors.Count);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.Equal("Error 5", result.Failure.Errors[1].Message);
    Assert.True(result.IsFailedWith(FailureType.PaymentRequired));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.PaymentRequired"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.True(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void ExceptionImplicitOperator()
  {
    // Arrange
    Result result = _ex1;

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Single(result.Failure.Errors);
    Assert.Equal("Error 4", result.Failure.Errors[0].Message);
    Assert.True(result.IsFailedWith(FailureType.CriticalError));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.True(result.IsFailedWith("Failure.CriticalError"));
    Assert.False(result.IsFailedWith("E2"));
    Assert.False(result.IsFailedWith("e2"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.True(result.IsFailedWith<Exception>(true));
    Assert.True(result.IsFailedWith<InvalidOperationException>());
    Assert.False(result.IsFailedWith<ApplicationException>());
  }

  [Fact]
  public void FailureTypeImplicitOperator()
  {
    // Arrange
    Result result = FailureType.Forbidden;

    // Assert
    Assert.NotNull(result);
    Assert.False(result.IsOk);
    Assert.True(result.IsFailed);
    Assert.NotNull(result.Failure);
    Assert.Empty(result.Failure.Errors);
    Assert.True(result.IsFailedWith(FailureType.Forbidden));
    Assert.False(result.IsFailedWith(FailureType.Unspecified));
    Assert.False(result.IsFailedWith("Failure.Forbidden"));
    Assert.False(result.IsFailedWith(typeof(Exception)));
    Assert.False(result.IsFailedWith<Exception>(true));
  }
}
