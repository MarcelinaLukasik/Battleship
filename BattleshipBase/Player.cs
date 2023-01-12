
namespace Battleship
{
    public class Player
    {   
        public List<Ship> PlayerShips;
        public List<Ship> SpaceAroundShips;
        public Board PlayerBoard = new Board(10);
        public Board PlayerTargetBoard = new Board(10);
        public bool IsAlive { get; private set; }
        public Player()
        {
            PlayerShips = new List<Ship>(Enum.GetNames(typeof(ShipType)).Length);
            SpaceAroundShips = new List<Ship>(Enum.GetNames(typeof(ShipType)).Length);
            IsAlive = true;
        }


        public bool Shooting(Square shotCords, Player enemy)
        {
            foreach (var coords in from ship in enemy.PlayerShips from coords in ship.Coordinates 
                     where coords.Position == shotCords.Position select coords)
            {
                ChangeStatusAfterShot(shotCords.Position, SquareStatus.Hit);
                coords.SquareStatus = SquareStatus.Hit;
                return true;
            }

            return false;
        }


        public void ChangeStatus((int row, int col) coords, SquareStatus status)
        {
            PlayerBoard.Ocean[coords.row, coords.col].SquareStatus = status;
        }
        public void ChangeStatusAfterShot((int row, int col) coords, SquareStatus status)
        {
            PlayerTargetBoard.Ocean[coords.row, coords.col].SquareStatus = status;
        }
        public void ChangeStatusAfterShot(Ship ship, SquareStatus status)
        {
            foreach (var coords in ship.Coordinates)
            {
                PlayerTargetBoard.Ocean[coords.Position.row, coords.Position.col].SquareStatus = status;
            }
        }

        public void IsWin()
        {
            foreach (var ship in PlayerShips)
            {
                foreach (var coords in ship.Coordinates)
                {
                    if (coords.SquareStatus == SquareStatus.Ship) 
                        return;
                }
            }
            IsAlive = false;
        }

        public bool CheckIfShipDestroyed(Player enemyPlayer)
        {
            int hitCounter = 0;
            foreach (var ship in enemyPlayer.PlayerShips)
            {
                foreach (var coords in ship.Coordinates)
                {
                    if (coords.SquareStatus == SquareStatus.Hit)
                        hitCounter++;
                }
                if (hitCounter == ship.Coordinates.Capacity)
                {
                    ChangeStatusAfterShot(ship, SquareStatus.Destroyed);
                    return true;
                }
                hitCounter = 0;
            }
            return false;
        }

        public void CheckIfShipDestroyed()
        {
            int hitCounter = 0;
            foreach (var ship in PlayerShips)
            {
                foreach (var coords in ship.Coordinates)
                {
                    if (coords.SquareStatus == SquareStatus.Hit)
                        hitCounter++;
                }
                if (hitCounter == ship.Coordinates.Capacity)
                {
                    foreach (var coords in ship.Coordinates)
                    {
                        PlayerBoard.Ocean[coords.Position.row, coords.Position.col].SquareStatus = SquareStatus.Destroyed;
                    }
                }
                hitCounter = 0;
            }
        }

        public bool CheckShipsCollision(Square coords, string shipDirection, int shipSize)
        {
            foreach (var ship in PlayerShips)
            {
                foreach (var shipCoords in ship.Coordinates)
                {
                    if (shipCoords.Position == coords.Position)
                    {
                        return true;
                    }
                    for (int i = 0; i < shipSize; i++)
                    {
                        switch (shipDirection)
                        {
                            case "W":
                                {
                                    Square nextCoords = new Square((coords.Position.row - i, coords.Position.col));
                                    if (shipCoords.Position == nextCoords.Position)
                                    {
                                        return true;
                                    }
                                    break;
                                }
                            case "S":
                                {
                                    Square nextCoords = new Square((coords.Position.row + i, coords.Position.col));
                                    if (shipCoords.Position == nextCoords.Position)
                                    {
                                        return true;
                                    }
                                    break;
                                }
                            case "A":
                                {
                                    Square nextCoords = new Square((coords.Position.row, coords.Position.col - i));
                                    if (shipCoords.Position == nextCoords.Position)
                                    {
                                        return true;
                                    }
                                    break;
                                }
                            case "D":
                                {
                                    Square nextCoords = new Square((coords.Position.row, coords.Position.col + i));
                                    if (shipCoords.Position == nextCoords.Position)
                                    {
                                        return true;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckShipsCollision(Square coords, int shipSize)
        {
            foreach (var ship in PlayerShips)
            {
                foreach (var shipCoords in ship.Coordinates)
                {
                    if (shipCoords.Position == coords.Position)
                    {
                        return true;
                    }
                    for (int i = 0; i < shipSize; i++)
                    {
                        Square nextCoords = new Square((coords.Position.row, coords.Position.col + i));
                        if (shipCoords.Position == nextCoords.Position)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

