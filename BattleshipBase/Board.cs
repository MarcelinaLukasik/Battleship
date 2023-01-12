
namespace Battleship
{
    public class Board
    {
        public Square[,] Ocean { get; set; }
        private readonly int _size;
        

        public Board(int size)
        {
            _size = size;
            Ocean = new Square[size, size];
            InitializeOcean();
        }


        private void InitializeOcean()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Ocean[i, j] = new Square((i, j));
                }
            }
        }


        public bool IsPlacementOk(Square coords, string shipDirection, int shipSize)
        {
            int directionToCheck;
            switch (shipDirection)
            {
                case "W":
                    directionToCheck = coords.Position.row - shipSize + 1;
                    return DirectionValidation(directionToCheck);
                case "A":
                    directionToCheck = coords.Position.col - shipSize + 1;
                    return DirectionValidation(directionToCheck);
                case "S":
                    directionToCheck = coords.Position.row + shipSize - 1;
                    return DirectionValidation(directionToCheck);
                case "D":
                    directionToCheck = coords.Position.col + shipSize - 1;
                    return DirectionValidation(directionToCheck);
            }
                return false;
        }


        private bool DirectionValidation(int directionToCheck)
        {
            if (directionToCheck >= 0 && directionToCheck < Ocean.GetLength(0))
                return true;
            return false;
        }

        public bool IsPlacementOk(Square coords, int shipSize)
        {
            int directionToCheck;
            directionToCheck = coords.Position.col + shipSize - 1;
            if (DirectionValidation(directionToCheck))
                return true;
            return false;
        }
    }
}

