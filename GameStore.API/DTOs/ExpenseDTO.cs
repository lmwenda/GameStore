namespace GameStore.API.DTOs;

public record ExpenseDTO(
    int ExpenseID,
    string ReceiptNO,
    UserDTO User,
    List<GameDTO> Games
);