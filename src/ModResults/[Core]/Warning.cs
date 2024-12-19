namespace ModResults;

public class Warning
{
  public string Message { get; set; }

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
