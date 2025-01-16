using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceCollectionErrorExtensions
{
  /// <summary>
  /// Gets all the errors of a collection of results.
  /// </summary>
  /// <param name="results"></param>
  /// <returns></returns>
  public static ReadOnlyCollection<Error> GetErrors(this IEnumerable<IModResult<Failure>> results)
  {
    return results.SelectMany(r => r.Failure?.Errors ?? []).ToList().AsReadOnly();
  }

  /// <summary>
  /// Determines whether any one of the collection of results have an error with the specified code.
  /// </summary>
  /// <param name="results"></param>
  /// <param name="code">Error code to check for.</param>
  /// <returns></returns>
  public static bool HaveError(this IEnumerable<IModResult<Failure>> results, string code)
  {
    return results.HaveError(code, Definitions.DefaultComparisonType);
  }

  /// <summary>
  /// Determines whether any one of the collection of results have an error with the specified code.
  /// </summary>
  /// <param name="results"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HaveError(
    this IEnumerable<IModResult<Failure>> results,
    string code,
    StringComparison comparisonType)
  {
    return results.Select(r => r.HasError(code, comparisonType)).Any(h => h);
  }

  /// <summary>
  /// Determines whether any one of the collection of results have an error with the specified code, returning matching errors as out parameter.
  /// </summary>
  /// <param name="results"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="errors">Matching error collection.</param>
  /// <returns></returns>
  public static bool HaveError(
    this IEnumerable<IModResult<Failure>> results,
    string code,
    out ReadOnlyCollection<Error> errors)
  {
    return results.HaveError(code, Definitions.DefaultComparisonType, out errors);
  }

  /// <summary>
  /// Determines whether any one of the collection of results have an error with the specified code, returning matching errors as out parameter.
  /// </summary>
  /// <param name="results"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <param name="errors">Matching error collection.</param>
  /// <returns></returns>
  public static bool HaveError(
    this IEnumerable<IModResult<Failure>> results,
    string code,
    StringComparison comparisonType,
    out ReadOnlyCollection<Error> errors)
  {
    errors = results.GetErrors(code, comparisonType);
    return errors.Count > 0;
  }

  /// <summary>
  /// Gets all errors with the specified code.
  /// </summary>
  /// <param name="results"></param>
  /// <param name="code">Error code to check for.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Error> GetErrors(
    this IEnumerable<IModResult<Failure>> results,
    string code)
  {
    return results.GetErrors(code, Definitions.DefaultComparisonType);
  }

  /// <summary>
  /// Gets all errors with the specified code.
  /// </summary>
  /// <param name="results"></param>
  /// <param name="code">Error code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Error> GetErrors(
    this IEnumerable<IModResult<Failure>> results,
    string code,
    StringComparison comparisonType)
  {
    return results.SelectMany(r => r.GetErrors(code, comparisonType)).ToList().AsReadOnly();
  }
}
