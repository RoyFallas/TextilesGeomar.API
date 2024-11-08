using TextilesGeomar.API.DTOs;

namespace TextilesGeomar.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
    }
}