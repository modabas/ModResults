namespace ModResults;

public class Fact
{
  /// <summary>
  /// The fact message.
  /// </summary>
  public string Message { get; set; }

  /// <summary>
  /// Fact code.
  /// </summary>
  public string? Code { get; set; }

  public Fact(string message, string? code = null)
  {
    Message = message;
    Code = code;
  }

  public Fact() : this(string.Empty, null)
  {
  }
}
