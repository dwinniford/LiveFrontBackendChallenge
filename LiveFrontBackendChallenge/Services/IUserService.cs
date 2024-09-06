using LiveFrontBackendChallenge.Models;

namespace LiveFrontBackendChallenge.Services
{
    public interface IUserService
    {
        Task<User?> GetUser(int userId);
    }
}