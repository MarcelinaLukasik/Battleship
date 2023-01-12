
namespace Battleship
{
    public class Game : Display
    {
        private readonly Input _input = new Input();
        private readonly BoardFactory _boardFactory = new BoardFactory();
        private Player _player1 = new Player();
        private Player _player2 = new Player();
        private Square _shipCoordinates;
        public string ShipDirection;
        private bool _directionValidation;
        private bool _isHit;
        private readonly int _player1Id;
        private readonly int _player2Id;


        public Game()
        {
            _player1Id = 1;
            _player2Id = 2;
        }


        public void GetUserInput()
        {
            _shipCoordinates = _input.GetShipCoordinates();
            ShipDirection = _input.GetShipDirection();
        }

        private void PlayerTurns(int playerNumber, Player player, Player enemyPlayer)
        {
            AskForShot(playerNumber);
            DisplayBoard(player.PlayerTargetBoard.Ocean);
            _shipCoordinates = _input.GetShipCoordinates();
            _isHit = player.Shooting(_shipCoordinates, enemyPlayer);
            if (!_isHit)
            {
                player.ChangeStatusAfterShot(_shipCoordinates.Position, SquareStatus.Missed);
            }
        }


        public void MainGameLoop()
        {
            SettingUpStage(_player1, _player1Id);
            Console.Clear();
            SettingUpStage(_player2, _player2Id);
            ShootingStage();
        }

        private void SettingUpStage(Player player, int playerNumber)
        {
            DisplayBoard(player.PlayerBoard.Ocean);
            DisplayPlayerTurn(playerNumber);
            ChooseShipToPlace(player);
        }

        private void ShootingStage()
        {
            while (true)
            {
                PlayerShotTurn(_player1, _player2, _player1Id);
                if (!_player2.IsAlive)
                    break;
                PlayerShotTurn(_player2, _player1, _player2Id);
                if (!_player1.IsAlive)
                    break;
            }
        }

        private void PlayerShotTurn(Player player, Player enemyPlayer, int playerNumber)
        {
            PlayerTurns(playerNumber, player, enemyPlayer);
            player.CheckIfShipDestroyed(enemyPlayer);
            enemyPlayer.IsWin();
            DisplayBoard(player.PlayerTargetBoard.Ocean);
            if (!enemyPlayer.IsAlive)
            {
                DisplayBoard(player.PlayerTargetBoard.Ocean);
                WinMessage(playerNumber);
            }
        }
        private void ChooseShipToPlace(Player player)
        {
            bool collision = false;
            foreach (int shipSize in Enum.GetValues<ShipType>())
            {
                while (true)
                {
                    GetUserInput();
                    if (shipSize > 1)
                    {
                        _directionValidation = player.PlayerBoard.IsPlacementOk(_shipCoordinates, ShipDirection, shipSize);
                        if (_directionValidation)
                            collision = player.CheckShipsCollision(_shipCoordinates, ShipDirection, shipSize);
                        if (!_directionValidation)
                            OutOfRangeMessage();
                        else if (collision)
                            ShipsTooCloseMessage();
                        else
                            break;
                    }
                    else
                        break;
                }
                player.PlayerBoard = AddShipCoordinates(_shipCoordinates, shipSize, player);
                DisplayBoard(player.PlayerBoard.Ocean);
            }
        }
        public Board AddShipCoordinates(Square shipCoordinates, int shipSize, Player player)
        {
            Ship ship = new Ship(shipSize);
            
            shipCoordinates.SquareStatus = SquareStatus.Ship;
            if (shipSize == 1)
            {
                ship.Coordinates.Add(shipCoordinates);
            }
            else if (shipSize > 1)
            {
                ship.Coordinates.Add(shipCoordinates);
                SwitchDirection(shipCoordinates, shipSize, ship);
            }
            player.PlayerShips.Add(ship);
            _boardFactory.ManualPlacement(ship, player);
            return player.PlayerBoard;
        }

        private void SwitchDirection(Square shipCoordinates, int shipSize, Ship ship)
        {
            switch (ShipDirection)
            {
                case "W":
                    for (int i = 1; i < shipSize; i++)
                    {
                        shipCoordinates = new Square(shipCoordinates.MoveUp());
                        AddCoordsAndStatus(ship, shipCoordinates);
                    }
                    break;

                case "A":
                    for (int i = 1; i < shipSize; i++)
                    {
                        shipCoordinates = new Square(shipCoordinates.MoveLeft());
                        AddCoordsAndStatus(ship, shipCoordinates);
                    }
                    break;

                case "S":
                    for (int i = 1; i < shipSize; i++)
                    {
                        shipCoordinates = new Square(shipCoordinates.MoveDown());
                        AddCoordsAndStatus(ship, shipCoordinates);
                    }
                    break;

                case "D":
                    for (int i = 1; i < shipSize; i++)
                    {
                        shipCoordinates = new Square(shipCoordinates.MoveRight());
                        AddCoordsAndStatus(ship, shipCoordinates);
                    }
                    break;
            }
        }

        private void AddCoordsAndStatus(Ship ship, Square coords)
        {
            coords.SquareStatus = SquareStatus.Ship;
            ship.Coordinates.Add(coords);
        }
    }
    
}

