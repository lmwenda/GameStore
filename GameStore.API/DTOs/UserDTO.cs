using System.ComponentModel.DataAnnotations;

namespace GameStore.API.DTOs;

public record UserDTO(
    int UserID,
    string Username,
    string Email,
    List<GameDTO> Games
);

public record CreateUserDTO(
    [Required] string Username,
    [Required] string Email,
    [Required] string Password
);

public record LoginUserDTO(
    [Required] string Email,
    [Required] string Password
);