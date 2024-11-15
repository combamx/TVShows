using Microsoft.EntityFrameworkCore;
using TVShowsAPI.Data.Models;
using TVShowsAPI.Helper;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Repositories.Repositories
{
    public class UserContextRepository : IUserContextRepository
    {
        private readonly TVShowDataContext _context;

        public UserContextRepository ( TVShowDataContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<Data.Models.User>> GetAllAsync ( )
        {
            return await _context.Users.ToListAsync ( );
        }

        public async Task<Data.Models.User> GetByIdAsync ( int id )
        {
            return await _context.Users.FindAsync ( id );
        }

        public async Task<Data.Models.User> AddAsync ( Data.Models.User user )
        {
            user.Password = PasswordHasher.HashPassword ( user.Password );
            _context.Users.Add ( user );
            await _context.SaveChangesAsync ( );
            return user;
        }

        public async Task<Data.Models.User> UpdateAsync ( Data.Models.User user )
        {
            var existingUser = await _context.Users.FindAsync ( user.Id );
            if (existingUser == null) return null;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = PasswordHasher.HashPassword ( user.Password );

            await _context.SaveChangesAsync ( );
            return existingUser;
        }

        public async Task<bool> DeleteAsync ( int id )
        {
            var user = await _context.Users.FindAsync ( id );
            if (user == null) return false;

            _context.Users.Remove ( user );
            await _context.SaveChangesAsync ( );
            return true;
        }

        public async Task<Data.Models.User> GetByEmailPasswordAsync ( string email , string password )
        {
            string hashedPassword = PasswordHasher.HashPassword ( password );
            bool isMatch = PasswordHasher.VerifyPassword ( password , hashedPassword );

            if (isMatch)
            {
                return await _context.Users.Where ( p => p.Email == email && p.Password == hashedPassword ).FirstOrDefaultAsync ( );
            }

            return null;

        }
    }
}
