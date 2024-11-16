using TVShowsAPI.Models;

namespace TVShowsAPI.Repositories.Interfaces
{
    public interface IUserContextRepository
    {
        Task<ApiResponse<IEnumerable<Data.Models.User>>> GetAllAsync ( );
        Task<ApiResponse<Data.Models.User>> GetByIdAsync ( int id );
        Task<ApiResponse<Data.Models.User>> GetByEmailPasswordAsync ( string email , string password );
        Task<ApiResponse<Data.Models.User>> AddAsync ( Data.Models.User user );
        Task<ApiResponse<Data.Models.User>> UpdateAsync ( Data.Models.User user );
        Task<ApiResponse<string>> DeleteAsync ( int id );
    }
}
