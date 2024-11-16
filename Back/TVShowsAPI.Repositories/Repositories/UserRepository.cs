using TVShowsAPI.Helper;
using TVShowsAPI.Models;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Lista en memoria para almacenar usuarios
        private static List<User> _users;
        private int _nextId = 1; // Contador para los Ids de los usuarios

        public UserRepository ( )
        {
            // Inicializando la lista con algunos datos de ejemplo
            LoadData ( );
        }

        public Task<IEnumerable<User>> GetAllAsync ( )
        {
            return Task.FromResult ( _users.AsEnumerable ( ) );
        }

        public Task<User> GetByIdAsync ( int id )
        {
            var user = _users.FirstOrDefault ( u => u.Id == id );
            return Task.FromResult ( user );
        }

        public Task<User> AddAsync ( User user )
        {
            user.Id = _nextId++; // Asignar un Id único al nuevo usuario
            _users.Add ( user );
            return Task.FromResult ( user );
        }

        public Task<User> UpdateAsync ( User user )
        {
            var existingUser = _users.FirstOrDefault ( u => u.Id == user.Id );
            if (existingUser == null)
                return Task.FromResult<User> ( null );

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            return Task.FromResult ( existingUser );
        }

        public Task<bool> DeleteAsync ( int id )
        {
            var user = _users.FirstOrDefault ( u => u.Id == id );
            if (user == null)
                return Task.FromResult ( false );

            _users.Remove ( user );
            return Task.FromResult ( true );
        }

        public Task<User> GetByEmailPasswordAsync ( string email , string password )
        {
            string hashedPassword = PasswordHasher.HashPassword ( password );
            bool isMatch = PasswordHasher.VerifyPassword ( password , hashedPassword );

            if (isMatch)
            {
                return Task.FromResult ( _users.FirstOrDefault ( u => u.Email.Equals ( email , StringComparison.OrdinalIgnoreCase ) && u.Password == hashedPassword ) );
            }

            return null;
        }

        private void LoadData ( )
        {
            if (_users == null)
            {
                _users = new List<User>
                {
                    new User { Id = _nextId++, Name = "Omar Cortes", Email = "omar.cortes@example.com", Password = "hashed_password_123" },
                };
            }
        }
    }
}
