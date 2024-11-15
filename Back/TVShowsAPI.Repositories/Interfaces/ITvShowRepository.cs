using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShowsAPI.Models;

namespace TVShowsAPI.Repositories.Interfaces
{
    public interface ITvShowRepository
    {
        ApiResponse<IEnumerable<TvShow>> GetAll ( int page , int rows );
        ApiResponse<TvShow> GetById ( int id );
        ApiResponse<TvShow> Add ( TvShow show );
        ApiResponse<TvShow> Update ( TvShow show );
        ApiResponse<string> Delete ( int id );
    }
}
