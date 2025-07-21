namespace ModResults;
public enum FailureType
{
  Unspecified = 0,
  Error = 1,
  Forbidden = 2,
  Unauthorized = 3,
  Invalid = 4,
  NotFound = 5,
  Conflict = 6,
  CriticalError = 7,
  Unavailable = 8,
  GatewayError = 9,
  RateLimited = 10,
  TimedOut = 11,
  PaymentRequired = 12
}
