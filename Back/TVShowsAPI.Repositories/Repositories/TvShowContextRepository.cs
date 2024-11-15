using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShowsAPI.Data.Models;
using TVShowsAPI.Models;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Repositories.Repositories
{
    public class TvShowContextRepository : ITvShowContextRepository
    {
        private readonly TVShowDataContext _context;

        public TvShowContextRepository ( TVShowDataContext context )
        {
            _context = context;
        }

        public async Task<ApiResponse<IEnumerable<Data.Models.TvShow>>> GetAllAsync ( int page , int rows )
        {
            try
            {
                var totalRecords = await _context.TvShows.CountAsync ( );
                var data = await _context.TvShows
                    .Skip ( (page - 1) * rows )
                    .Take ( rows )
                    .ToListAsync ( );

                return new ApiResponse<IEnumerable<Data.Models.TvShow>>
                {
                    Data = data ,
                    Page = page ,
                    Rows = rows ,
                    Counts = totalRecords ,
                    Status = 200 ,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Data.Models.TvShow>>
                {
                    Data = null ,
                    Page = page ,
                    Rows = rows ,
                    Counts = 0 ,
                    Status = 500 ,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponse<Data.Models.TvShow>> GetByIdAsync ( int id )
        {
            try
            {
                var show = await _context.TvShows.FindAsync ( id );
                if (show == null)
                {
                    return new ApiResponse<Data.Models.TvShow>
                    {
                        Data = null ,
                        Page = 1 ,
                        Rows = 1 ,
                        Counts = 0 ,
                        Status = 500 ,
                        ErrorMessage = "TvShow not found"
                    };
                }

                return new ApiResponse<Data.Models.TvShow>
                {
                    Data = show ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 1 ,
                    Status = 200 ,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Data.Models.TvShow>
                {
                    Data = null ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 0 ,
                    Status = 500 ,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponse<Data.Models.TvShow>> AddAsync ( Data.Models.TvShow show )
        {
            try
            {
                _context.TvShows.Add ( show );
                await _context.SaveChangesAsync ( );

                return new ApiResponse<Data.Models.TvShow>
                {
                    Data = show ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = await _context.TvShows.CountAsync ( ) ,
                    Status = 201 ,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Data.Models.TvShow>
                {
                    Data = null ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 0 ,
                    Status = 500 ,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponse<Data.Models.TvShow>> UpdateAsync ( Data.Models.TvShow show )
        {
            try
            {
                var existingShow = await _context.TvShows.FindAsync ( show.Id );
                if (existingShow == null)
                {
                    return new ApiResponse<Data.Models.TvShow>
                    {
                        Data = null ,
                        Page = 1 ,
                        Rows = 1 ,
                        Counts = 0 ,
                        Status = 500 ,
                        ErrorMessage = "TvShow not found"
                    };
                }

                existingShow.Name = show.Name;
                existingShow.Favorite = show.Favorite;
                existingShow.Content = show.Content;
                existingShow.Format = show.Format;
                existingShow.Episodes = show.Episodes;
                existingShow.Duration = show.Duration;
                existingShow.Scenarios = show.Scenarios;
                existingShow.Classification = show.Classification;

                _context.TvShows.Update ( existingShow );
                await _context.SaveChangesAsync ( );

                return new ApiResponse<Data.Models.TvShow>
                {
                    Data = existingShow ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = await _context.TvShows.CountAsync ( ) ,
                    Status = 201 ,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Data.Models.TvShow>
                {
                    Data = null ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 0 ,
                    Status = 500 ,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponse<string>> DeleteAsync ( int id )
        {
            try
            {
                var show = await _context.TvShows.FindAsync ( id );
                if (show == null)
                {
                    return new ApiResponse<string>
                    {
                        Data = null ,
                        Page = 1 ,
                        Rows = 1 ,
                        Counts = 0 ,
                        Status = 500 ,
                        ErrorMessage = "TvShow not found"
                    };
                }

                _context.TvShows.Remove ( show );
                await _context.SaveChangesAsync ( );

                return new ApiResponse<string>
                {
                    Data = "TvShow deleted successfully" ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = await _context.TvShows.CountAsync ( ) ,
                    Status = 200 ,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>
                {
                    Data = null ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 0 ,
                    Status = 500 ,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
