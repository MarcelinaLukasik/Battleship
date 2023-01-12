
namespace Battleship
{
    public class Display
    {

        public void AskForInput()
        {
            Console.WriteLine("Please select coordinates (example A1)");
        }
        public void IncorrectInput()
        {
            Console.WriteLine("Wrong coordinates");
        }

        public void AskForDirection()
        {
            Console.WriteLine("Please select Ship direction. W for up, S for down, A for left, D for right");
        }


        public void DisplayBoard(Square[,] board)
        {
            string letters = "ABCDEFGHIJ";
            Console.Write("   ");
            for (int col = 0; col < board.GetLength(0); col++)
            {
                Console.Write($"{col + 1}" + "  ");
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write(letters[row] + "  ");

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col].GetCharacter() + "  ");

                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }


        public void DisplayPlayerTurn(int player)
        {
            Console.WriteLine($"Now it is player {player} turn");
        }


        public void AskForShot(int player)
        {
            Console.WriteLine($"Now it is player {player} turn to shoot!");
        }


        public void IncorrectDirection()
        {
            Console.WriteLine("Wrong direction, enter again!");
        }

        public void WinMessage(int player)
        {
            Console.WriteLine($"Player {player} WON!");
        }


        public void DisplayLogo()
        {
            var logo = new[]
            {
                @" _______             __       __     __                   __       __          ",
                @"|       \           |  \     |  \   |  \                 |  \     |  \         ",
                @"| ▓▓▓▓▓▓▓\ ______  _| ▓▓_   _| ▓▓_  | ▓▓ ______   _______| ▓▓____  \▓▓ ______  ",
                @"| ▓▓__/ ▓▓|      \|   ▓▓ \ |   ▓▓ \ | ▓▓/      \ /       \ ▓▓    \|  \/      \ ",
                @"| ▓▓    ▓▓ \▓▓▓▓▓▓\\▓▓▓▓▓▓  \▓▓▓▓▓▓ | ▓▓  ▓▓▓▓▓▓\  ▓▓▓▓▓▓▓ ▓▓▓▓▓▓▓\ ▓▓  ▓▓▓▓▓▓\",
                @"| ▓▓▓▓▓▓▓\/      ▓▓ | ▓▓ __  | ▓▓ __| ▓▓ ▓▓    ▓▓\▓▓    \| ▓▓  | ▓▓ ▓▓ ▓▓  | ▓▓",
                @"| ▓▓__/ ▓▓  ▓▓▓▓▓▓▓ | ▓▓|  \ | ▓▓|  \ ▓▓ ▓▓▓▓▓▓▓▓_\▓▓▓▓▓▓\ ▓▓  | ▓▓ ▓▓ ▓▓__/ ▓▓",
                @"| ▓▓    ▓▓\▓▓    ▓▓  \▓▓  ▓▓  \▓▓  ▓▓ ▓▓\▓▓     \       ▓▓ ▓▓  | ▓▓ ▓▓ ▓▓    ▓▓",
                @" \▓▓▓▓▓▓▓  \▓▓▓▓▓▓▓   \▓▓▓▓    \▓▓▓▓ \▓▓ \▓▓▓▓▓▓▓\▓▓▓▓▓▓▓ \▓▓   \▓▓\▓▓ ▓▓▓▓▓▓▓ ",
                @"                                                                     | ▓▓      ",
                @"                   *** DEVELOPERS ***                                | ▓▓      ",
                @"      Konrad Kiryluk && Marcelina Łukasik && Piotr Palacz             \▓▓      ",
            };

            Console.WriteLine();
            foreach (string line in logo)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\nPress any key to display Menu ...");
            Console.ReadKey();
        }


        public void DisplayMenu()
        {
            var menu = new[]
            {
                @"🚤🚤🚤🚤🚤🚤🚤🚤🚤🚤🚤🚤",
                @"                          ",
                @"   1. Player vs. Player   ",
                @"   2. Highscore           ",
                @"   3. EXIT                ",
                @"                          ",
                @"🚤🚤🚤🚤🚤🚤🚤🚤🚤🚤🚤🚤",
            };

            Console.WriteLine();
            foreach (string line in menu)
            {
                Console.WriteLine(line);
            }
        }


        public void AskForMenuInput()
        {
            Console.WriteLine("\nPlease choose an option: ");
        }


        public void OutOfRangeMessage()
        {
            Console.WriteLine("Position out of range! Try again!");
        }

        public void ShipsTooCloseMessage()
        {
            Console.WriteLine("Ships are too close! Try again!");
        }


        public void NoHighscoreMessage()
        {
            Console.WriteLine("No highscores yet!");
        }


        public void EndOfGameMessage()
        {
            Console.WriteLine("THE END!");
        }


        public void WrongMenuInputMessage()
        {
            Console.WriteLine("Wrong option! Enter 1, 2 or 3 Ludziu!");
        }
    }
}

