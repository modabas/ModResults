namespace ModResults.MinimalApis;

/// <summary>
/// Used to pass information about which HTTP 2XX success response will be produced if <see cref="Result"/> is in Ok state.
/// </summary>
public enum SuccessfulResponseType
{
  Ok = 1,
  Created = 2,
  NoContent = 3,
  Accepted = 4,
  ResetContent = 5
}
