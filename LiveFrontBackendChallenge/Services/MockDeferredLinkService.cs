namespace LiveFrontBackendChallenge.Services
{
    public class MockDeferredLinkService : IDeferredLinkService
    {
        public MockDeferredLinkService()
        {
        }

        public async Task<string> GetDeferredLink(string referralCode)
        {
            return await Task.FromResult($"3rdparty.service.com/deferredlink?referralCode={referralCode}");
        }
    }
}