namespace TVShowsAPI.Repositories.Interfaces
{
    public interface IUserContextRepository
    {
        Task<IEnumerable<Data.Models.User>> GetAllAsync ( );
        Task<Data.Models.User> GetByIdAsync ( int id );
        Task<Data.Models.User> AddAsync ( Data.Models.User user );
        Task<Data.Models.User> UpdateAsync ( Data.Models.User user );
        Task<bool> DeleteAsync ( int id );
    }
}
