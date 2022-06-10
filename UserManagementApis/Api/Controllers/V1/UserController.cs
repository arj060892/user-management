using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Api.Controllers.V1.Models;
using UserManagementApi.Api.Controllers.V1.Services;

namespace UserManagementApi.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// This endpoint refers to fetch all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("api/GetAllUsers")]
        public async Task<List<UserDetails>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        /// <summary>
        /// This endpoint refers to fetch a user as per the user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userid}")]
        public async Task<ActionResult<UserDetails>> GetUserByIdAsync(int userId)
        {
            UserDetails? user = await _userService.GetUserByIdAsync(userId);
            if (user is null)
            {
                return NotFound();
            }
            return user;
        }

        /// <summary>
        /// This endpoint refers to create a new user entry.
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPost]
        //[Route("api/CreateUser")]
        public async Task<IActionResult> CreateUserAsync(UserDetails userDetails)
        {
            await _userService.CreateUserAsync(userDetails);
            return CreatedAtAction(nameof(GetAllUsersAsync), new { id = userDetails.Id }, userDetails);
        }

        /// <summary>
        /// This endpoint refers to update a user as per the user id.
        /// </summary>
        /// <param name="userDetails"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{userid}")]
        public async Task<IActionResult> UpdateUserAsync(UserDetails userDetails, int userId)
        {
            UserDetails? userDetail = await _userService.GetUserByIdAsync(userId);
            if (userDetail is null)
            {
                return NotFound();
            }
            userDetails.UId = userDetail.UId;
            await _userService.UpdateUserAsync(userDetails, userId);
            return Ok();
        }

        /// <summary>
        /// This endpoint refers to remove a user as per the user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{userid}")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            UserDetails? userDetail = await _userService.GetUserByIdAsync(userId);
            if (userDetail is null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(userId);
            return Ok();
        }
    }
}
