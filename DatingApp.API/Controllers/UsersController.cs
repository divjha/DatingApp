
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mappper;
        public UsersController(IDatingRepository repo, IMapper mappper)
        {
            _mappper = mappper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var userToReturn = _mappper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mappper.Map<UserForDetailedDto>(user);
            return Ok(userToReturn);
        }

    }
}