using Microsoft.AspNetCore.Mvc;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Controllers
{
    [Route ( "api/[controller]" )]
    [ApiController]
    [Produces ( "application/json" )]
    public class TvShowsDataController : ControllerBase
    {
        private readonly ITvShowContextRepository _repository;

        public TvShowsDataController ( ITvShowContextRepository repository )
        {
            _repository = repository;
        }

        [HttpGet]
        [Route ( "GetAllContext" )]
        public async Task<IActionResult> GetAll ( int page = 1 , int rows = 10 )
        {
            var response = await _repository.GetAllAsync ( page , rows );
            if (response.Status == 500)
            {
                return StatusCode ( 500 , response );
            }
            return Ok ( response );
        }

        [HttpGet]
        [Route ( "GetByIdContext/{id}" )]
        public async Task<IActionResult> GetById ( int id )
        {
            var response = await _repository.GetByIdAsync ( id );
            if (response.Status == 500)
            {
                return NotFound ( response );
            }
            return Ok ( response );
        }

        [HttpPost]
        [Route ( "AddContext" )]
        public async Task<IActionResult> AddContext ( [FromForm] Data.Models.TvShow show )
        {
            var response = await _repository.AddAsync ( show );
            if (response.Status == 500)
            {
                return StatusCode ( 500 , response );
            }
            return CreatedAtAction ( nameof ( GetById ) , new { id = show.Id } , response );
        }

        [HttpPut]
        [Route ( "UpdateContext" )]
        public async Task<IActionResult> UpdateContext ( [FromForm] Data.Models.TvShow show )
        {
            var response = await _repository.UpdateAsync ( show );
            if (response.Status == 500)
            {
                return NotFound ( response );
            }
            return Ok ( response );
        }

        [HttpDelete]
        [Route ( "DeleteContext/{id}" )]
        public async Task<IActionResult> DeleteContext ( int id )
        {
            var response = await _repository.DeleteAsync ( id );
            if (response.Status == 500)
            {
                return NotFound ( response );
            }
            return Ok ( response );
        }


    }
}
