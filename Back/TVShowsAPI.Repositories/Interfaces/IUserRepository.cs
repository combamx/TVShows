using TVShowsAPI.Models;

namespace TVShowsAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync ( );
        Task<User> GetByIdAsync ( int id );
        Task<User> GetByEmailPasswordAsync ( string email , string password );
        Task<User> AddAsync ( User user );
        Task<User> UpdateAsync ( User user );
        Task<bool> DeleteAsync ( int id );
    }
}
