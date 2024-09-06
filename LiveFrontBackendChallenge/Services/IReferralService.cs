using LiveFrontBackendChallenge.Models;

namespace LiveFrontBackendChallenge.Services
{
    public interface IReferralService
    {
        public Task<ReferralDto> CreateReferral(int userId, string referralCode, string deferredLink, string name, string? phone, string? email);
    }
}