using System;
namespace Battleship
{
    public class Ship
    {
        public List<Square> Coordinates;


        public Ship(int shipSize)
        {
            Coordinates = new List<Square>(shipSize);
        }
    }
    
}

