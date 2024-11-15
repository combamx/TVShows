using Microsoft.AspNetCore.Mvc;
using TVShowsAPI.Models;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Controllers
{
    [Route ( "api/[controller]" )]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController ( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ( )
        {
            var users = await _userRepository.GetAllAsync ( );
            return Ok ( users );
        }

        [HttpGet ( "{id}" )]
        public async Task<IActionResult> GetById ( int id )
        {
            var user = await _userRepository.GetByIdAsync ( id );
            if (user == null) return NotFound ( );
            return Ok ( user );
        }

        [HttpPost]
        public async Task<IActionResult> Add ( User user )
        {
            var createdUser = await _userRepository.AddAsync ( user );
            return CreatedAtAction ( nameof ( GetById ) , new { id = createdUser.Id } , createdUser );
        }

        [HttpPost]
        [Route ( "GetByEmailPassword" )]
        public async Task<IActionResult> GetByEmailPassword ( string email , string password )
        {
            var user = await _userRepository.GetByEmailPasswordAsync ( email , password );
            if (user == null) return NotFound ( );
            return Ok ( user );
        }

        [HttpPut ( "{id}" )]
        public async Task<IActionResult> Update ( int id , User user )
        {
            if (id != user.Id) return BadRequest ( );

            var updatedUser = await _userRepository.UpdateAsync ( user );
            if (updatedUser == null) return NotFound ( );

            return Ok ( updatedUser );
        }

        [HttpDelete ( "{id}" )]
        public async Task<IActionResult> Delete ( int id )
        {
            var result = await _userRepository.DeleteAsync ( id );
            if (!result) return NotFound ( );

            return NoContent ( );
        }
    }
}
