namespace GameStore.API.Controllers;

using GameStore.API.DTOs;
using GameStore.API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService userService;
    public UserController(UserService _userService)
    {
        userService = _userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> RegisterUser([FromBody] CreateUserDTO CreateUser, CancellationToken cancellationToken)
    {
        try
        {
            UserDTO user = await userService.RegisterUserAsync(
                CreateUser,
                cancellationToken
            );

            return Created("/api/users/" + user.UserID, user);
        }

        catch(InvalidOperationException exception)
        {
            return Conflict(
                new
                {
                    message = exception.Message
                }
            );
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> LoginUser([FromBody] LoginUserDTO LoginUser, CancellationToken cancellationToken)
    {
        try
        {
            // login user
            await userService.LoginUserAsync(LoginUser, cancellationToken);

            return Ok();
        }

        catch(InvalidOperationException exception)
        {
            return Conflict(
                new
                {
                    message = exception.Message
                }
            );
        }
    }

    public void GetAllUsers()
    {

    }

    public void GetUser()
    {

    }
}

