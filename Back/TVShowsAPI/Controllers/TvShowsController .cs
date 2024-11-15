using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVShowsAPI.Models;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Controllers
{
    [Route ( "api/[controller]" )]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly ITvShowRepository _repository;

        public TvShowsController ( ITvShowRepository repository )
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll ( int page = 1 , int rows = 10 )
        {
            var response = _repository.GetAll ( page , rows );
            if (response.Status == 500)
            {
                return StatusCode ( 500 , response );
            }
            return Ok ( response );
        }

        [HttpGet ( "{id}" )]
        public IActionResult GetById ( int id )
        {
            var response = _repository.GetById ( id );
            if (response.Status == 500)
            {
                return NotFound ( response );
            }
            return Ok ( response );
        }

        [HttpPost]
        public IActionResult Add ( TvShow show )
        {
            var response = _repository.Add ( show );
            if (response.Status == 500)
            {
                return StatusCode ( 500 , response );
            }
            return CreatedAtAction ( nameof ( GetById ) , new { id = show.Id } , response );
        }

        [HttpPut ( "{id}" )]
        public IActionResult Update ( int id , TvShow show )
        {
            if (id != show.Id)
            {
                return BadRequest ( new ApiResponse<TvShow>
                {
                    Data = null ,
                    Page = 1 ,
                    Rows = 1 ,
                    Counts = 0 ,
                    Status = 500 ,
                    ErrorMessage = "Id mismatch"
                } );
            }

            var response = _repository.Update ( show );
            if (response.Status == 500)
            {
                return NotFound ( response );
            }
            return Ok ( response );
        }

        [HttpDelete ( "{id}" )]
        public IActionResult Delete ( int id )
        {
            var response = _repository.Delete ( id );
            if (response.Status == 500)
            {
                return NotFound ( response );
            }
            return Ok ( response );
        }
    }
}
