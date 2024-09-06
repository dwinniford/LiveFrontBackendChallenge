using LiveFrontBackendChallenge.Models;

namespace LiveFrontBackendChallenge.Services
{
    public class MockUserService : IUserService
    {
        private static List<User> _mockUserStore;
        public MockUserService()
        {
            _mockUserStore = GetMockUsers();
        }

        public async Task<User?> GetUser(int userId)
        {
            User? user = _mockUserStore.FirstOrDefault(u => u.UserId == userId);
            return await Task.FromResult(user);
        }

        private List<User> GetMockUsers()
        {
            return new List<User>
            {
                new User() {
                    UserId = 1,
                    ReferralCode = "111111"
                },
                new User() {
                    UserId = 2,
                    ReferralCode = "222222"
                },
                new User() {
                    UserId = 3,
                    ReferralCode = "333333"
                }
            };
        }
    }
}