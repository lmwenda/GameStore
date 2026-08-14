namespace GameStore.API.Models;

public class Game
{
    public int GameID { get; set; }
    public required string GameName { get; set; }
    public required string Description { get; set; }
    public required float Price { get; set; }
    public float Reviews { get; set; }
    public required int StockCount{ get; set; }
}