using LiveFrontBackendChallenge.Models;

namespace LiveFrontBackendChallenge.Services
{
    public class MockReferralService : IReferralService
    {
        public async Task<ReferralDto> CreateReferral(int userId, string referralCode, string deferredLink, string name, string? phone, string? email)
        {
            var referralDto = new ReferralDto()
            {
                UserId = userId,
                ReferralCode = referralCode,
                DeferredLink = deferredLink,
                Activated = false,
                ReferralId = 1,
                Name = name,
                Phone = phone,
                Email = email
            };
            return await Task.FromResult(referralDto);
        }
    }
}