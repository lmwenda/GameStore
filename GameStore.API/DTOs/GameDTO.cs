namespace GameStore.API.DTOs;

public record GameDTO (
   int GameID,
   string Image,
   string GameName,
   string Description,
   float Price,
   float Reviews,
   int StockCount 
);