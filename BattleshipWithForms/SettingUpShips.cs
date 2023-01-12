
using Battleship;


namespace BattleshipWithForms
{
    public partial class SettingUpShips : Form
    {
        private int _shipSize;
        private const int BoardSize = 10;
        Button[,] buttons = new Button[BoardSize, BoardSize];
        private Game game = new Game();
        public static Player _player1 = new Player();
        public static Player _player2 = new Player();
        private int _setShipCounter;
        private int _playerTurn;
        private readonly int _buttonSize;
        readonly Color _baseColor = Color.CornflowerBlue;
        private readonly Color shipColor = Color.DarkOrchid;
        private readonly Color disabledColor = Color.DimGray;
        private readonly Color collisonColor = Color.Brown;
        private readonly Color highlightColor = Color.Aqua;
        private readonly Color borderColor = Color.AliceBlue;


        public SettingUpShips()
        {
            _setShipCounter = 0;
            _playerTurn = 1;
            _buttonSize = 60;
            InitializeComponent();
            InitializeButtons();
            Controls["Done"].Enabled = false;
            Controls["Done"].BackColor = disabledColor;
        }

        public void InitializeButtons()
        {
            for (int row = 0; row < buttons.GetLength(0); row++)
            {
                for (int col = 0; col < buttons.GetLength(0); col++)
                {
                    Button button = new Button();
                    buttons[row, col] = button;
                    buttons[row, col].Tag = new Tuple<int, int>(row, col);
                    button.Name = (row,col).ToString();
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = borderColor;
                    button.BackColor = _baseColor;
                    button.MouseEnter += OnMouseEnterButton1;
                    button.MouseLeave += OnMouseLeaveButton1;
                    button.Click += HandleButton;
                    button.Size = new Size(_buttonSize, _buttonSize);
                    button.Location = new Point(_buttonSize * col, _buttonSize * row);
                    panel1.Controls.Add(button);
                }
            }
        }

        public void InitializeButtons(Panel panel)
        {
            for (int row = 0; row < buttons.GetLength(0); row++)
            {
                for (int col = 0; col < buttons.GetLength(0); col++)
                {
                    Button button = new Button();
                    buttons[row, col] = button;
                    buttons[row, col].Tag = new Tuple<int, int>(row, col);
                    button.Name = (row, col).ToString();
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = borderColor;
                    button.BackColor = _baseColor;
                    button.Size = new Size(_buttonSize, _buttonSize);
                    button.Location = new Point(_buttonSize * col, _buttonSize * row);
                    button.Parent = panel;
                }
            }
        }
        private void SettingUpShips_Load(object sender, EventArgs e) {}

        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackColor != shipColor)
            {
                button.BackColor = highlightColor;
                Tuple<int, int> coords = button.Tag as Tuple<int, int>;

                for (int i = 0; i < _shipSize; i++)
                {
                    if (coords.Item2 + i < buttons.GetLength(0))
                    {
                        ShipCollideChangeColor(i, coords, _playerTurn == 1 ? _player1 : _player2);
                        ChangeButtonColors(coords, highlightColor, i);
                    }
                    else
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (coords.Item2 + j < buttons.GetLength(0))
                            {
                                ChangeButtonColors(coords, collisonColor, j);
                            }
                        }
                    }
                }
            }
        }

        private void ChangeButtonColors(Tuple<int,int> coords, Color color, int i)
        {
            Control nextButton = buttons[coords.Item1, coords.Item2 + i];
            if (nextButton.BackColor != shipColor)
                nextButton.BackColor = color;
        }

        private void ShipCollideChangeColor(int i, Tuple<int, int> coords, Player player)
        {
            foreach (var ship in player.PlayerShips)
            {
                foreach (var shipCords in ship.Coordinates)
                {
                    if ((coords.Item1, coords.Item2 + i) == shipCords.Position)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if ((coords.Item1, coords.Item2 + j) != shipCords.Position)
                            {
                                ChangeButtonColors(coords, collisonColor, j);
                            }
                        }
                    }
                }
            }
        }
        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackColor != shipColor)
            {
                button.BackColor = _baseColor;
                Tuple<int, int> coords = button.Tag as Tuple<int, int>;

                for (int i = 0; i < _shipSize; i++)
                {
                    if (coords.Item2 + i < buttons.GetLength(0))
                    {
                        ChangeButtonColors(coords, _baseColor, i);
                    }
                }
            }
        }

        private void HandleButton(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Tuple<int, int> buttonNumbers = clickedButton.Tag as Tuple<int, int>;
            Square coords = new Square(buttonNumbers.ToValueTuple());
            game.ShipDirection = "D";
            bool isPlacementOk = _player1.PlayerBoard.IsPlacementOk(coords, _shipSize);
            
            if (isPlacementOk)
                HandleCollision(coords, _playerTurn == 1 ? _player1 : _player2);
        }

        private void HandleCollision(Square coords, Player player)
        {
            bool collision = player.CheckShipsCollision(coords, _shipSize);
            if (!collision)
                SetUpShip(coords, player);
        }

        private void SetUpShip(Square coords, Player player)
        {
            game.AddShipCoordinates(coords, _shipSize, player);
            SetShipColorOnBoard(coords);
            DisableSetShipButton(_shipSize);
            _setShipCounter++;
            CheckShipCounter();
        }


        private void CheckShipCounter()
        {
            if (_setShipCounter == Enum.GetNames<ShipType>().Length)
            {
                Controls["Done"].Enabled = true;
                Controls["Done"].BackColor = Color.Chocolate;
                _setShipCounter = 0;
            }
        }

        private void DisableSetShipButton(int shipSize)
        {
            switch (shipSize)
            {
                case 1:
                    Controls["Destroyer"].Enabled = false;
                    Controls["Destroyer"].BackColor = disabledColor;
                    _shipSize = 0;
                    break;
                case 2:
                    Controls["Submarine"].Enabled = false;
                    Controls["Submarine"].BackColor = disabledColor;
                    _shipSize = 0;
                    break;
                case 3:
                    Controls["Battleship"].Enabled = false;
                    Controls["Battleship"].BackColor = disabledColor;
                    _shipSize = 0;
                    break;
                case 4:
                    Controls["Cruiser"].Enabled = false;
                    Controls["Cruiser"].BackColor = disabledColor;
                    _shipSize = 0;
                    break;
                case 5:
                    Controls["Carrier"].Enabled = false;
                    Controls["Carrier"].BackColor = disabledColor;
                    _shipSize = 0;
                    break;
            }
        }

        private void SetShipColorOnBoard(Square coords)
        {
            for (int i = 0; i < _shipSize; i++)
            {
                if (coords.Position.col + i < buttons.GetLength(0))
                {
                    Control nextButton = buttons[coords.Position.row, coords.Position.col + i];
                    nextButton.BackColor = shipColor;
                }
            }
        }

        private void Destroyer_Click(object sender, EventArgs e)
        {
            _shipSize = 1;
        }

        private void Submarine_Click(object sender, EventArgs e)
        {
            _shipSize = 2;
        }

        private void Battleship_Click(object sender, EventArgs e)
        {
            _shipSize = 3;
        }

        private void Cruiser_Click(object sender, EventArgs e)
        {
            _shipSize = 4;
        }

        private void Carrier_Click(object sender, EventArgs e)
        {
            _shipSize = 5;
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (_playerTurn == 2)
            {
                Shooting shootingForm = new Shooting();
                Hide();
                shootingForm.ShowDialog();
                Close();
            }
            _playerTurn = 2;
            ResetButtons();
            Control playerTurnLabel = Controls["settingTurn"];
            playerTurnLabel.Text = "Player turn: 2";
        }

        private void ResetButtons()
        {
            if (_playerTurn == 2)
            {
                foreach (Control control in panel1.Controls)
                {
                    control.BackColor = _baseColor;
                }
                foreach (Control control in Controls)
                {
                    control.Enabled = true;
                }
                Controls["Done"].Enabled = false;
                Controls["Done"].BackColor = disabledColor;
                Controls["Destroyer"].BackColor = Color.Brown;
                Controls["Submarine"].BackColor = Color.Tomato;
                Controls["Battleship"].BackColor = Color.Coral;
                Controls["Cruiser"].BackColor = Color.SandyBrown;
                Controls["Carrier"].BackColor = Color.BurlyWood;
            }
        }
    }
}
