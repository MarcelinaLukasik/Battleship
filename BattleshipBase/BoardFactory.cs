
namespace Battleship
{
    public class BoardFactory : Player
    {
        public void ManualPlacement(Ship ship, Player player)
        {
            foreach (Square coordinates in ship.Coordinates)
            {
                player.ChangeStatus(coordinates.Position, SquareStatus.Ship);
            }
        }
    }
}

