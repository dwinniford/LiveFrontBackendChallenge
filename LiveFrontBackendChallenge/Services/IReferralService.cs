using LiveFrontBackendChallenge.Models;

namespace LiveFrontBackendChallenge.Services
{
    public interface IReferralService
    {
        public Task<ReferralDto> CreateReferral(int userId, string referralCode, string deferredLink);
    }
}