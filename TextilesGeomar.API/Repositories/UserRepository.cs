using Microsoft.EntityFrameworkCore;
using TextilesGeomar.API.Data;
using TextilesGeomar.API.Models;
using TextilesGeomar.API.Repositories.Interfaces;

namespace TextilesGeomar.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TextilesGeomarDBContext _context;

        public UserRepository(TextilesGeomarDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
