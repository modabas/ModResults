using FluentValidation.Results;

namespace ModResults.FluentValidation;

public static class ValidationResultExtensions
{
  public static Result ToInvalidResult(this ValidationResult validationResult)
  {
    return Result.Invalid(
      validationResult.GetValidationErrors().ToArray());

  }

  public static Result<TValue> ToInvalidResult<TValue>(this ValidationResult validationResult)
  {
    return Result<TValue>.Invalid(
      validationResult.GetValidationErrors().ToArray());
  }

  public static IEnumerable<Error> GetValidationErrors(this ValidationResult validationResult)
  {
    return validationResult.Errors
      .Select(
        e => new Error(
          errorMessage: e.ErrorMessage,
          code: e.ErrorCode,
          propertyName: e.PropertyName));
  }
}
