using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShowsAPI.Models;

namespace TVShowsAPI.Repositories.Interfaces
{
    public interface ITvShowContextRepository
    {
        Task<ApiResponse<IEnumerable<Data.Models.TvShow>>> GetAllAsync ( int page , int rows );
        Task<ApiResponse<Data.Models.TvShow>> GetByIdAsync ( int id );
        Task<ApiResponse<Data.Models.TvShow>> AddAsync ( Data.Models.TvShow show );
        Task<ApiResponse<Data.Models.TvShow>> UpdateAsync ( Data.Models.TvShow show );
        Task<ApiResponse<string>> DeleteAsync ( int id );
    }
}
