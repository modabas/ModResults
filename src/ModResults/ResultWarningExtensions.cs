namespace ModResults;

public static partial class ResultWarningExtensions
{
  extension(Result result)
  {
    /// <summary>
    /// Adds a collection of <see cref="Warning"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="warnings"></param>
    /// <returns></returns>
    public Result WithWarnings(
      IReadOnlyList<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    /// <summary>
    /// Adds a collection of <see cref="Warning"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="warnings"></param>
    /// <returns></returns>
    public Result WithWarnings(
      IEnumerable<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    /// <summary>
    /// Adds a collection of string messages as a collection of <see cref="Warning"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    public Result WithWarnings(
      IEnumerable<string> messages)
    {
      result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
      return result;
    }

    /// <summary>
    /// Adds all <see cref="Warning"/>s of another result object.
    /// </summary>
    /// <param name="fromResult"></param>
    /// <returns></returns>
    public Result WithWarningsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasWarnings())
      {
        result.WithWarnings(fromResult.Statements.Warnings);
      }
      return result;
    }

    /// <summary>
    /// Adds a <see cref="Warning"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="warning"></param>
    /// <returns></returns>
    public Result WithWarning(Warning warning)
    {
      result.Statements.AddWarning(warning);
      return result;
    }

    /// <summary>
    /// Adds a string message as a <see cref="Warning"/> to the <see cref="Result"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Result WithWarning(string message)
    {
      result.Statements.AddWarning(new Warning(message));
      return result;
    }
  }

  extension<TValue>(Result<TValue> result) where TValue : notnull
  {
    /// <summary>
    /// Adds a collection of <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="warnings"></param>
    /// <returns></returns>
    public Result<TValue> WithWarnings(
      IReadOnlyList<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    /// <summary>
    /// Adds a collection of <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="warnings"></param>
    /// <returns></returns>
    public Result<TValue> WithWarnings(
      IEnumerable<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    /// <summary>
    /// Adds a collection of string messages as a collection of <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    public Result<TValue> WithWarnings(
      IEnumerable<string> messages)
    {
      result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
      return result;
    }

    /// <summary>
    /// Adds all <see cref="Warning"/>s of another result object.
    /// </summary>
    /// <param name="fromResult"></param>
    /// <returns></returns>
    public Result<TValue> WithWarningsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasWarnings())
      {
        result.WithWarnings(fromResult.Statements.Warnings);
      }
      return result;
    }

    /// <summary>
    /// Adds a <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="warning"></param>
    /// <returns></returns>
    public Result<TValue> WithWarning(
      Warning warning)
    {
      result.Statements.AddWarning(warning);
      return result;
    }

    /// <summary>
    /// Adds a string message as a <see cref="Warning"/> to the <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Result<TValue> WithWarning(
      string message)
    {
      result.Statements.AddWarning(new Warning(message));
      return result;
    }
  }

  extension(FailedResult result)
  {
    /// <summary>
    /// Adds a collection of <see cref="Warning"/> to the <see cref="FailedResult"/>.
    /// </summary>
    /// <param name="warnings"></param>
    /// <returns></returns>
    public FailedResult WithWarnings(
      IReadOnlyList<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    /// <summary>
    /// Adds a collection of <see cref="Warning"/> to the <see cref="FailedResult"/>.
    /// </summary>
    /// <param name="warnings"></param>
    /// <returns></returns>
    public FailedResult WithWarnings(
      IEnumerable<Warning> warnings)
    {
      result.Statements.AddWarnings(warnings);
      return result;
    }

    /// <summary>
    /// Adds a collection of string messages as a collection of <see cref="Warning"/> to the <see cref="FailedResult"/>.
    /// </summary>
    /// <param name="messages"></param>
    /// <returns></returns>
    public FailedResult WithWarnings(
      IEnumerable<string> messages)
    {
      result.Statements.AddWarnings(messages.Select(m => new Warning(m)));
      return result;
    }

    /// <summary>
    /// Adds all <see cref="Warning"/>s of another result object.
    /// </summary>
    /// <param name="fromResult"></param>
    /// <returns></returns>
    public FailedResult WithWarningsFrom(
      BaseResult fromResult)
    {
      if (fromResult.HasWarnings())
      {
        result.WithWarnings(fromResult.Statements.Warnings);
      }
      return result;
    }

    /// <summary>
    /// Adds a <see cref="Warning"/> to the <see cref="FailedResult"/>.
    /// </summary>
    /// <param name="warning"></param>
    /// <returns></returns>
    public FailedResult WithWarning(Warning warning)
    {
      result.Statements.AddWarning(warning);
      return result;
    }

    /// <summary>
    /// Adds a string message as a <see cref="Warning"/> to the <see cref="FailedResult"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public FailedResult WithWarning(string message)
    {
      result.Statements.AddWarning(new Warning(message));
      return result;
    }
  }
}
