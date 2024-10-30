using TextilesGeomar.API.DTOs;
using TextilesGeomar.API.Mappers.Interfaces;
using TextilesGeomar.API.Models;

namespace TextilesGeomar.API.Mappers
{
    public class UserMapper : IMapper<User, UserDTO>
    {
        public UserDTO MapToDto(User entity)
        {
            return new UserDTO
            {
                Name = entity.Name,
                LastName = entity.LastName,
                Email = entity.Email,
            };
        }

        public User MapToEntity(UserDTO dto)
        {
            return new User
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
            };
        }

        public IEnumerable<UserDTO> Map(IEnumerable<User> entities)
        {
            return entities.Select(MapToDto); // Use LINQ to map each User to UserDTO
        }
    }
}
