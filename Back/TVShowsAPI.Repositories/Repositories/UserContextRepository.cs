using Microsoft.EntityFrameworkCore;
using TVShowsAPI.Data.Models;
using TVShowsAPI.Helper;
using TVShowsAPI.Models;
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

        public async Task<ApiResponse<IEnumerable<Data.Models.User>>> GetAllAsync ( )
        {
            var data = await _context.Users.ToListAsync ( );

            return new ApiResponse<IEnumerable<Data.Models.User>>
            {
                Data = data ,
                Page = 1 ,
                Rows = 1 ,
                Counts = 1 ,
                Status = 200 ,
                ErrorMessage = null
            };
        }

        public async Task<ApiResponse<Data.Models.User>> GetByIdAsync ( int id )
        {
            var data = await _context.Users.FindAsync ( id );

            return new ApiResponse<Data.Models.User>
            {
                Data = data ,
                Page = 1 ,
                Rows = 1 ,
                Counts = 1 ,
                Status = 200 ,
                ErrorMessage = null
            };
        }

        public async Task<ApiResponse<Data.Models.User>> AddAsync ( Data.Models.User user )
        {
            user.Password = PasswordHasher.HashPassword ( user.Password );
            _context.Users.Add ( user );
            await _context.SaveChangesAsync ( );
            return new ApiResponse<Data.Models.User>
            {
                Data = user ,
                Page = 1 ,
                Rows = 1 ,
                Counts = 1 ,
                Status = 200 ,
                ErrorMessage = null
            };
        }

        public async Task<ApiResponse<Data.Models.User>> UpdateAsync ( Data.Models.User user )
        {
            var existingUser = await _context.Users.FindAsync ( user.Id );
            if (existingUser == null) return null;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = PasswordHasher.HashPassword ( user.Password );

            await _context.SaveChangesAsync ( );
            return new ApiResponse<Data.Models.User>
            {
                Data = existingUser ,
                Page = 1 ,
                Rows = 1 ,
                Counts = 1 ,
                Status = 200 ,
                ErrorMessage = null
            };
        }

        public async Task<ApiResponse<string>> DeleteAsync ( int id )
        {
            var user = await _context.Users.FindAsync ( id );
            if (user == null)
            {
                return new ApiResponse<string>
                {
                    Data = null ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 0 ,
                    Status = 500 ,
                    ErrorMessage = "user not found"
                };
            }

            _context.Users.Remove ( user );
            await _context.SaveChangesAsync ( );
            return new ApiResponse<string>
            {
                Data = "User deleted successfully" ,
                Page = 1 ,
                Rows = 1 ,
                Counts = await _context.TvShows.CountAsync ( ) ,
                Status = 200 ,
                ErrorMessage = null
            };
        }

        public async Task<ApiResponse<Data.Models.User>> GetByEmailPasswordAsync ( string email , string password )
        {
            string hashedPassword = PasswordHasher.HashPassword ( password );
            bool isMatch = PasswordHasher.VerifyPassword ( password , hashedPassword );

            if (isMatch)
            {
                var data = await _context.Users.Where ( p => p.Email == email && p.Password == hashedPassword ).FirstOrDefaultAsync ( );

                return new ApiResponse<Data.Models.User>
                {
                    Data = data ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 1 ,
                    Status = 200 ,
                    ErrorMessage = null
                };
            }

            return null;

        }
    }
}
