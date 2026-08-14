namespace GameStore.API.Models;

public class User
{
    public int UserID {get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; } // It is Required but just to allow the error when creating the password
    public List<Game>? Games { get; set; }
}