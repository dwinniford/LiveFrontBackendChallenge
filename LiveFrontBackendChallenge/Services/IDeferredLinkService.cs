namespace LiveFrontBackendChallenge.Services
{
    public interface IDeferredLinkService
    {
        public Task<string> GetDeferredLink(string referralCode);
    }
}