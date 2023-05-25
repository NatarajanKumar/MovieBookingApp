using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Services.Contract;

namespace MovieBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        //[Authorize(Policy ="Admin")]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            var all_Users = await _userService.GetAllUsers();
            return Ok(all_Users);
        }
        [HttpGet("{loginId}")]
        public async Task<ActionResult<Users>> GetUserByLoginId(string loginId)
        {
            var all_Users = await _userService.GetUserByUserId(loginId);
            if (all_Users == null)
            {
                return NotFound();
            }
            return Ok(all_Users);
        }
        [HttpPost]
        //[AllowAnonymous]
        public async Task<ActionResult> AddUser(Users user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUser(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{loginId}")]
        //[Authorize(Policy = "User")]
        public async Task<ActionResult> UpdateUser(string loginId, Users user)
        {
            if (loginId != user.LoginID)
            {
                return BadRequest();
            }
            await _userService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete("{loginId}")]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> DeleteUser(string loginId)
        {
            await _userService.DeleteUser(loginId);
            return Ok();
        }
    }
}
