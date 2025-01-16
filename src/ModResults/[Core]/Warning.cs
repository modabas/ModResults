namespace ModResults;

public class Warning
{
  /// <summary>
  /// The warning message.
  /// </summary>
  public string Message { get; set; }

  /// <summary>
  /// Warning code.
  /// </summary>
  public string? Code { get; set; }

  public Warning(string message, string? code = null)
  {
    Message = message;
    Code = code;
  }

  public Warning() : this(string.Empty, null)
  {
  }
}
