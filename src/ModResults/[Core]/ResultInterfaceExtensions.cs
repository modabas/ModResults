using System.Text;

namespace ModResults;

public static class ResultInterfaceExtensions
{
  /// <summary>
  /// Dumps the state, failure type, errors, facts and warnings of the result as a formatted string.
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
  public static string DumpMessages(this BaseResult<Failure> result)
  {
    var sb = new StringBuilder();
    sb.AppendLine($"IsOk: {result.IsOk}");
    if (result.Failure is not null)
    {
      sb.AppendLine($"FailureType: {Enum.GetName(typeof(FailureType), result.Failure.Type)}");
      if (result.Failure.HasErrors())
      {
        sb.AppendLine("Errors:");
        sb = result.Failure.Errors.Select(e => e.Message)
          .Aggregate(sb, (sb, m) => sb.AppendLine($"  {m}"));
      }
    }
    if (result.HasFacts())
    {
      sb.AppendLine("Facts:");
      sb = result.Statements.Facts.Select(e => e.Message)
        .Aggregate(sb, (sb, m) => sb.AppendLine($"  {m}"));
    }
    if (result.HasWarnings())
    {
      sb.AppendLine("Warnings:");
      sb = result.Statements.Warnings.Select(e => e.Message)
        .Aggregate(sb, (sb, m) => sb.AppendLine($"  {m}"));
    }
    return sb.ToString();
  }

  /// <summary>
  /// Dumps the state, facts and warnings of the result as a formatted string.
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
  public static string DumpStatements(this BaseResult result)
  {
    var sb = new StringBuilder();
    sb.AppendLine($"IsOk: {result.IsOk}");
    if (result.HasFacts())
    {
      sb.AppendLine("Facts:");
      sb = result.Statements.Facts.Select(e => e.Message)
        .Aggregate(sb, (sb, m) => sb.AppendLine($"  {m}"));
    }
    if (result.HasWarnings())
    {
      sb.AppendLine("Warnings:");
      sb = result.Statements.Warnings.Select(e => e.Message)
        .Aggregate(sb, (sb, m) => sb.AppendLine($"  {m}"));
    }
    return sb.ToString();
  }
}
