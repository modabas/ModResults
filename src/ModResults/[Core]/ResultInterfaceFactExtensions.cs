﻿using System.Collections.ObjectModel;

namespace ModResults;
public static class ResultInterfaceFactExtensions
{
  /// <summary>
  /// Determines whether the result has a <see cref="Fact"/> with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Fact code to check for.</param>
  /// <returns></returns>
  public static bool HasFact(this IModResult result, string code)
  {
    return result.HasFact(code, Definitions.DefaultComparisonType);
  }

  /// <summary>
  /// Determines whether the result has a <see cref="Fact"/> with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Fact code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static bool HasFact(
    this IModResult result,
    string code,
    StringComparison comparisonType)
  {
    return result.Statements.Facts.Any(f => f.HasCode(code, comparisonType));
  }

  /// <summary>
  /// Checks if the result has a <see cref="Fact"/> with the specified code, returning matching facts as out parameter.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Fact code to check for.</param>
  /// <param name="facts">Matching fact collection.</param>
  /// <returns></returns>
  public static bool HasFact(
    this IModResult result,
    string code,
    out ReadOnlyCollection<Fact> facts)
  {
    return result.HasFact(code, Definitions.DefaultComparisonType, out facts);
  }

  /// <summary>
  /// Checks if the result has a <see cref="Fact"/> with the specified code, returning matching facts as out parameter.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Fact code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <param name="facts">Matching fact collection.</param>
  /// <returns></returns>
  public static bool HasFact(
    this IModResult result,
    string code,
    StringComparison comparisonType,
    out ReadOnlyCollection<Fact> facts)
  {
    facts = result.GetFacts(code, comparisonType);
    return facts.Count > 0;
  }

  /// <summary>
  /// Gets all <see cref="Fact"/>s with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Fact code to check for.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Fact> GetFacts(this IModResult result, string code)
  {
    return result.GetFacts(code, Definitions.DefaultComparisonType);
  }

  /// <summary>
  /// Gets all <see cref="Fact"/>s with the specified code.
  /// </summary>
  /// <param name="result"></param>
  /// <param name="code">Fact code to check for.</param>
  /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
  /// <returns></returns>
  public static ReadOnlyCollection<Fact> GetFacts(
    this IModResult result,
    string code,
    StringComparison comparisonType)
  {
    return result.GetFactsInternal(code, comparisonType).ToList().AsReadOnly();
  }

  private static IEnumerable<Fact> GetFactsInternal(
    this IModResult result,
    string code,
    StringComparison comparisonType)
  {
    return result.Statements.Facts.Where(f => f.HasCode(code, comparisonType));
  }
}
