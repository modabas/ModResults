namespace ModResults;
public static class ResultInterfaceCollectionExtensions
{
  public static bool AllOk(this IEnumerable<IModResult> results)
  {
    return results.All(r => r.IsOk);
  }

  public static bool AnyFailed(this IEnumerable<IModResult> results)
  {
    return results.Any(r => r.IsFailed);
  }
}
