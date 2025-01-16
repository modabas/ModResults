using FluentValidation.Results;

namespace ModResults.FluentValidation;

public static class ValidationResultExtensions
{
  /// <summary>
  /// Converts a <see cref="ValidationResult"/> to a Failed <see cref="Result"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <param name="validationResult"></param>
  /// <returns></returns>
  public static Result ToInvalidResult(this ValidationResult validationResult)
  {
    return Result.Invalid(
      validationResult.GetValidationErrors().ToArray());

  }

  /// <summary>
  /// Converts a <see cref="ValidationResult"/> to a Failed <see cref="Result{TValue}"/> with failure type <see cref="FailureType.Invalid"/>.
  /// </summary>
  /// <typeparam name="TValue"></typeparam>
  /// <param name="validationResult"></param>
  /// <returns></returns>
  public static Result<TValue> ToInvalidResult<TValue>(this ValidationResult validationResult)
    where TValue : notnull
  {
    return Result<TValue>.Invalid(
      validationResult.GetValidationErrors().ToArray());
  }

  /// <summary>
  /// Converts <see cref="ValidationFailure"/>s of a <see cref="ValidationResult"/> to a collection of <see cref="Error"/>.
  /// </summary>
  /// <param name="validationResult"></param>
  /// <returns></returns>
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
