using GameStore.API.DTOs;
using GameStore.API.Database;
using Microsoft.AspNetCore.Identity;
using GameStore.API.Models;
using Microsoft.EntityFrameworkCore;


namespace GameStore.API.Services;

public class UserService
{
    private readonly AppDbContext _appDBContext;
    private readonly PasswordHasher<User> _passwordHasher = new(); 

    public UserService(AppDbContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public async Task LoginUserAsync(LoginUserDTO LoginUser, CancellationToken cancellationToken = default)
    {
        // check if user credentials are correct
        var user = _appDBContext.User.SingleOrDefault(u => 
            u.Email == LoginUser.Email
        );

        if(user == null)
        {
            Console.Write("User doesn't exist...");
        }

        string hashpass = _passwordHasher.HashPassword(user, LoginUser.Password);
        var pass = _passwordHasher.VerifyHashedPassword(user, user.Password, LoginUser.Password);

        Console.Write(hashpass, pass);
    }

    public async Task<UserDTO> RegisterUserAsync(CreateUserDTO createUser, CancellationToken cancellationToken = default)
    {
        // check if user exists 

        bool emailExists = await _appDBContext.User.AnyAsync(
            user => user.Email == createUser.Email,
            cancellationToken
        );

        if (emailExists)
        {
            throw new InvalidOperationException(
                "A user with this email already exists."
            );
        }


        // if user doesn't exist
        var user = new User
        {
            Username = createUser.Username.Trim(),
            Email = createUser.Email.Trim().ToLowerInvariant(),
            Password = ""
        };

        user.Password = _passwordHasher.HashPassword(
            user,
            createUser.Password
        );

        _appDBContext.User.Add(user);

        await _appDBContext.SaveChangesAsync(cancellationToken);

        return new UserDTO(
            user.UserID,
            user.Username,
            user.Email,
            []
        );
    }
}