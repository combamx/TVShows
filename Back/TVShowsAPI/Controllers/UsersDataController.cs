using Microsoft.AspNetCore.Mvc;
using TVShowsAPI.Repositories.Interfaces;

namespace TVShowsAPI.Controllers
{
    [Route ( "api/[controller]" )]
    [ApiController]
    public class UsersDataController : ControllerBase
    {
        private readonly IUserContextRepository _userRepository;

        public UsersDataController ( IUserContextRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route ( "GetAllUsers" )]
        public async Task<IActionResult> GetAllUsers ( )
        {
            var users = await _userRepository.GetAllAsync ( );
            return Ok ( users );
        }

        [HttpGet]
        [Route ( "GetByIdUser/{id}" )]
        public async Task<IActionResult> GetByIdUser ( int id )
        {
            var user = await _userRepository.GetByIdAsync ( id );
            if (user == null) return NotFound ( );
            return Ok ( user );
        }

        [HttpPost]
        [Route ( "AddUser" )]
        public async Task<IActionResult> AddUser ( [FromForm] Data.Models.User user )
        {
            var createdUser = await _userRepository.AddAsync ( user );
            return CreatedAtAction ( nameof ( GetByIdUser ) , new { id = createdUser.Id } , createdUser );
        }

        [HttpPut]
        [Route ( "UpdateUser" )]
        public async Task<IActionResult> UpdateUser ( int id , [FromForm] Data.Models.User user )
        {
            if (id != user.Id) return BadRequest ( );

            var updatedUser = await _userRepository.UpdateAsync ( user );
            if (updatedUser == null) return NotFound ( );

            return Ok ( updatedUser );
        }

        [HttpDelete]
        [Route ( "DeleteUser/{id}" )]
        public async Task<IActionResult> DeleteUser ( int id )
        {
            var result = await _userRepository.DeleteAsync ( id );
            if (!result) return NotFound ( );

            return NoContent ( );
        }

    }
}
