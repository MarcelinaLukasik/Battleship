
namespace Battleship
{
    public class Square
    {
        public (int row, int col) Position { get; private set; }
        public SquareStatus SquareStatus { get; set; }


        public Square((int, int) position)
        {
            Position = position;
            SquareStatus = SquareStatus.Empty;
        }

        public char GetCharacter()
        {
            return SquareStatus switch
            {
                SquareStatus.Empty => 'o',
                SquareStatus.Ship => 'X',
                SquareStatus.Hit => 'H',
                SquareStatus.Missed => 'M',
                SquareStatus.Destroyed => 'D',
                _ => "Error"
            };
        }

        public (int, int) MoveUp()
        {
            return (Position.row - 1, Position.col);
        }
        public (int, int) MoveDown()
        {
            return (Position.row + 1, Position.col);
        }
        public (int, int) MoveRight()
        {
            return (Position.row, Position.col + 1);
        }
        public (int, int) MoveLeft()
        {
            return (Position.row, Position.col - 1);
        }
    }
}

