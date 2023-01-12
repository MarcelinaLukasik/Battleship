using System;
using System.Text;

namespace Battleship
{
    public class Battleship
    {

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Input input = new Input();
            Display display = new Display();
            Game game = new Game();
            display.DisplayLogo();
            display.DisplayMenu();

            switch (input.ConvertMenuInput())
            {
                case 1:
                    game.MainGameLoop();
                    display.EndOfGameMessage();
                    break;
                case 2:
                    display.NoHighscoreMessage();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }

            Console.ReadKey();
        }
    }
}

