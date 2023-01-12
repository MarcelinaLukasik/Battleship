
namespace Battleship
{
    public class Input
    {
        private bool correctRow;
        private bool correctCol;
        private bool correctInput;
        private string userMenuInput;
        readonly Display display = new Display();
        const int maxCol = 10;
        const string letters = "ABCDEFGHIJ";

        private bool CoordinatesInputValidation(string shipPlacement)
        {
            string secondCoord;

            if (shipPlacement.Length is 2 or 3)
            {
                string firstCoord = shipPlacement.Substring(0, 1);
                if (letters.Contains(firstCoord.ToUpper()))
                    correctRow = true;
                else
                    correctRow = false;
                secondCoord = shipPlacement.Substring(1, shipPlacement.Length == 2 ? 1 : 2);
                correctCol = int.TryParse(secondCoord, out int col);
                if (correctRow && correctCol && col <= maxCol)
                    return true;
            }
            return false;
        }


        private bool DirectionInputValidation(string shipDirection)
        {
            const string correctLetters = "WASD";
            return correctLetters.Contains(shipDirection);
        }


        public Square GetShipCoordinates()
        {
            while (true)
            {
                display.AskForInput();
                string shipPlacement = Console.ReadLine().ToUpper();
                correctInput = CoordinatesInputValidation(shipPlacement);
                if (correctInput)
                    return ConvertCoordinates(shipPlacement);
                display.IncorrectInput();
            }
        }


        public Square ConvertCoordinates(string shipPlacement)
        {

            int x = letters.IndexOf(shipPlacement[0]);
            int y = int.Parse(shipPlacement[1..]) - 1;
            Square coordinates = new Square((x, y));
            return coordinates;
        }

        
        public string GetShipDirection()
        {
            while (true)
            {
                display.AskForDirection();
                string shipDirection = Console.ReadLine().ToUpper();
                bool correctDirection = DirectionInputValidation(shipDirection);
                if (correctDirection)
                    return shipDirection;
                display.IncorrectDirection();
            }
        }

        
        public int ConvertMenuInput()
        {
            while (true)
            {
                display.AskForMenuInput();
                userMenuInput = Console.ReadLine();
                bool inputValidation = ValidateMenuInput(userMenuInput);
                if (inputValidation)
                    break;
                display.WrongMenuInputMessage();
            }
            int choice = int.Parse(userMenuInput);
            return choice;
        }


        public bool ValidateMenuInput(string userInput)
        {
            const string correctMenuInput = "123";
            return userInput.Length == 1 && correctMenuInput.Contains(userInput);
        }
    }
}

