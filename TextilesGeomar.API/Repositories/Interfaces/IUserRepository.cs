using TextilesGeomar.API.Models;

namespace TextilesGeomar.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
