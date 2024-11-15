using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShowsAPI.Models;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Repositories.Repositories
{
    public class TvShowRepository : ITvShowRepository
    {
        private readonly List<TvShow> _tvShows;

        public TvShowRepository ( )
        {
            _tvShows = new List<TvShow>
            {
                new TvShow { Id = 1, Name = "Breaking Bad", Favorite = true, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "50-60 minutes", Scenarios = "Various interior and exterior settings", Classification = "R" },
                new TvShow { Id = 2, Name = "Game of Thrones", Favorite = false, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "60 minutes or longer", Scenarios = "Various interior and exterior settings", Classification = "18A" },
                new TvShow { Id = 3, Name = "The Office", Favorite = true, Content = "Fiction", Format = "Comedy", Episodes = "Individual narrative units", Duration = "20-30 minutes", Scenarios = "Office interior settings", Classification = "PG" },
                new TvShow { Id = 4, Name = "Friends", Favorite = true, Content = "Fiction", Format = "Comedy", Episodes = "Individual narrative units", Duration = "20-30 minutes", Scenarios = "Apartment interior settings", Classification = "PG" },
                new TvShow { Id = 5, Name = "Stranger Things", Favorite = false, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "50-60 minutes", Scenarios = "Various interior and exterior settings", Classification = "14A" },
                new TvShow { Id = 6, Name = "The Mandalorian", Favorite = true, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "30-40 minutes", Scenarios = "Various interior and exterior settings", Classification = "PG" },
                new TvShow { Id = 7, Name = "Black Mirror", Favorite = false, Content = "Fiction", Format = "Series", Episodes = "Standalone narrative units", Duration = "50-60 minutes", Scenarios = "Various settings, futuristic and dystopian", Classification = "18A" },
                new TvShow { Id = 8, Name = "Rick and Morty", Favorite = true, Content = "Animation", Format = "Animation Series", Episodes = "Individual narrative units", Duration = "20-30 minutes", Scenarios = "Various sci-fi settings", Classification = "R" },
                new TvShow { Id = 9, Name = "The Crown", Favorite = false, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "50-60 minutes", Scenarios = "Historical settings, interior and exterior", Classification = "PG" },
                new TvShow { Id = 10, Name = "Brooklyn Nine-Nine", Favorite = true, Content = "Fiction", Format = "Comedy", Episodes = "Individual narrative units", Duration = "20-30 minutes", Scenarios = "Police station interior settings", Classification = "PG" },
                new TvShow { Id = 11, Name = "Sherlock", Favorite = false, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "90 minutes", Scenarios = "Modern London settings", Classification = "14A" },
                new TvShow { Id = 12, Name = "Chernobyl", Favorite = true, Content = "Docudrama", Format = "Series", Episodes = "Narrative units with continuity", Duration = "50-60 minutes", Scenarios = "Historical settings", Classification = "18A" },
                new TvShow { Id = 13, Name = "House of Cards", Favorite = false, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "50-60 minutes", Scenarios = "Political interior settings", Classification = "18A" },
                new TvShow { Id = 14, Name = "The Simpsons", Favorite = true, Content = "Animation", Format = "Animation Series", Episodes = "Individual narrative units", Duration = "20-30 minutes", Scenarios = "Springfield settings", Classification = "PG" },
                new TvShow { Id = 15, Name = "Narcos", Favorite = false, Content = "Fiction", Format = "Series", Episodes = "Narrative units with continuity", Duration = "50-60 minutes", Scenarios = "Various settings, interior and exterior", Classification = "18A" }
            };
        }

        // Obtener todos los elementos de la colección
        public ApiResponse<IEnumerable<TvShow>> GetAll ( int page , int rows )
        {
            try
            {
                var totalRecords = _tvShows.Count;
                var data = _tvShows.Skip ( (page - 1) * rows ).Take ( rows );

                return new ApiResponse<IEnumerable<TvShow>>
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
                return new ApiResponse<IEnumerable<TvShow>>
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

        // Obtener un elemento de la colección
        public ApiResponse<TvShow> GetById ( int id )
        {
            try
            {
                var show = _tvShows.FirstOrDefault ( x => x.Id == id );
                if (show == null)
                {
                    return new ApiResponse<TvShow>
                    {
                        Data = null ,
                        Page = 1 ,
                        Rows = 1 ,
                        Counts = 0 ,
                        Status = 500 ,
                        ErrorMessage = "TvShow not found"
                    };
                }

                return new ApiResponse<TvShow>
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
                return new ApiResponse<TvShow>
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

        // Agregar un nuevo elemento
        public ApiResponse<TvShow> Add ( TvShow show )
        {
            try
            {
                _tvShows.Add ( show );
                return new ApiResponse<TvShow>
                {
                    Data = show ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = _tvShows.Count ,
                    Status = 201 ,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<TvShow>
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

        // Actualizar un elemento
        public ApiResponse<TvShow> Update ( TvShow show )
        {
            try
            {
                var existingShow = _tvShows.FirstOrDefault ( x => x.Id == show.Id );
                if (existingShow == null)
                {
                    return new ApiResponse<TvShow>
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

                return new ApiResponse<TvShow>
                {
                    Data = existingShow ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = _tvShows.Count ,
                    Status = 201 ,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<TvShow>
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

        // Eliminar un elemento
        public ApiResponse<string> Delete ( int id )
        {
            try
            {
                var show = _tvShows.FirstOrDefault ( x => x.Id == id );
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

                _tvShows.Remove ( show );

                return new ApiResponse<string>
                {
                    Data = "TvShow deleted successfully" ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = _tvShows.Count ,
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


