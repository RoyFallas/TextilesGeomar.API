using TextilesGeomar.API.DTOs;
using TextilesGeomar.API.Mappers.Interfaces;
using TextilesGeomar.API.Models;
using TextilesGeomar.API.Repositories.Interfaces;
using TextilesGeomar.API.Services.Interfaces;

namespace TextilesGeomar.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper<User, UserDTO> _userMapper;

        public UserService(IUserRepository userRepository, IMapper<User, UserDTO> userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _userMapper.Map(users);
        }
    }
}
