namespace ModResults;

public class Fact
{
  public string Message { get; set; }

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
