namespace ModResults.Tests;

public class FailedResultOfTTests
{
  private readonly Error error1, error2;
  private readonly InvalidOperationException ex1;
  private readonly ApplicationException ex2;

  public FailedResultOfTTests()
  {
    error1 = new Error("Error 1");
    error2 = new Error("Error 2", code: "E2");
    ex1 = new InvalidOperationException("Error 4");
    ex2 = new ApplicationException("Error 5", new ArgumentException("Error 5 Inner"));
  }

  [Fact]
  public void Error()
  {
    // Arrange
    var result = Result<ValueClass>.Error();

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
    var result = Result<ValueClass>.Error("Error1", "Error2");

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
    var result = Result<ValueClass>.Error(error1, error2);

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
    var result = Result<ValueClass>.Error(ex1, ex2);

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
    var result = Result<ValueClass>.Forbidden();

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
    var result = Result<ValueClass>.Forbidden("Error1", "Error2");

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
    var result = Result<ValueClass>.Forbidden(error1, error2);

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
    var result = Result<ValueClass>.Forbidden(ex1, ex2);

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
    var result = Result<ValueClass>.Unauthorized();

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
    var result = Result<ValueClass>.Unauthorized("Error1", "Error2");

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
    var result = Result<ValueClass>.Unauthorized(error1, error2);

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
    var result = Result<ValueClass>.Unauthorized(ex1, ex2);

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
    var result = Result<ValueClass>.Invalid();

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
    var result = Result<ValueClass>.Invalid("Error1", "Error2");

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
    var result = Result<ValueClass>.Invalid(error1, error2);

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
    var result = Result<ValueClass>.Invalid(ex1, ex2);

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
    var result = Result<ValueClass>.NotFound();

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
    var result = Result<ValueClass>.NotFound("Error1", "Error2");

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
    var result = Result<ValueClass>.NotFound(error1, error2);

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
    var result = Result<ValueClass>.NotFound(ex1, ex2);

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
    var result = Result<ValueClass>.Conflict();

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
    var result = Result<ValueClass>.Conflict("Error1", "Error2");

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
    var result = Result<ValueClass>.Conflict(error1, error2);

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
    var result = Result<ValueClass>.Conflict(ex1, ex2);

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
    var result = Result<ValueClass>.CriticalError();

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
    var result = Result<ValueClass>.CriticalError("Error1", "Error2");

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
    var result = Result<ValueClass>.CriticalError(error1, error2);

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
    var result = Result<ValueClass>.CriticalError(ex1, ex2);

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
    var result = Result<ValueClass>.Unavailable();

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
    var result = Result<ValueClass>.Unavailable("Error1", "Error2");

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
    var result = Result<ValueClass>.Unavailable(error1, error2);

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
    var result = Result<ValueClass>.Unavailable(ex1, ex2);

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
    var result = Result<ValueClass>.GatewayError();

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
    var result = Result<ValueClass>.GatewayError("Error1", "Error2");

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
    var result = Result<ValueClass>.GatewayError(error1, error2);

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
    var result = Result<ValueClass>.GatewayError(ex1, ex2);

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
    var result = Result<ValueClass>.RateLimited();

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
    var result = Result<ValueClass>.RateLimited("Error1", "Error2");

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
    var result = Result<ValueClass>.RateLimited(error1, error2);

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
    var result = Result<ValueClass>.RateLimited(ex1, ex2);

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
    var result = Result<ValueClass>.TimedOut();

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
    var result = Result<ValueClass>.TimedOut("Error1", "Error2");

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
    var result = Result<ValueClass>.TimedOut(error1, error2);

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
    var result = Result<ValueClass>.TimedOut(ex1, ex2);

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
    var result = Result<ValueClass>.PaymentRequired();

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
    var result = Result<ValueClass>.PaymentRequired("Error1", "Error2");

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
    var result = Result<ValueClass>.PaymentRequired(error1, error2);

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
    var result = Result<ValueClass>.PaymentRequired(ex1, ex2);

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
    Result<ValueClass> result = ex1;

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
    Result<ValueClass> result = FailureType.Forbidden;

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
