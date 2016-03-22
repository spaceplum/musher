namespace Musher.EchoNest.Responses
{
    public enum ResponseStatusCode
    {
        UnknownError = -1,
        Success = 0,
        MissingOrInvalidApiKey = 1,
        ApiKeyNotAllowedToCallMethod = 2,
        RateLimitExceeded = 3,
        MissingParameter = 4,
        InvalidParameter = 5
    }
}
