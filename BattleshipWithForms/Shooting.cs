
using Battleship;

namespace BattleshipWithForms
{
    public partial class Shooting : Form
    {
        private SettingUpShips settingUpShips = new();
        private Player _player1 = new Player();
        private Player _player2 = new Player();
        private int _playerTurn;
        private bool _buttonStatus;
        private Control _turnLabel;
        private bool _shot;
        private readonly Color _shotColor = Color.DarkOrange;
        private readonly Color _missColor = Color.DarkSlateBlue;

        public Shooting()
        {
            InitializeComponent();
            settingUpShips.InitializeButtons(panel1);
            settingUpShips.InitializeButtons(panel2);
            AddShootingOnClick();
            getPlayers();
            _playerTurn = 1;
            ChangeButtonsStatus(panel1, _buttonStatus = false);
        }

        public void getPlayers()
        {
            _player1 = SettingUpShips._player1;
            _player2 = SettingUpShips._player2;
            MessageBox.Show("Shooting time!");
        }

        private Square GetButtonNumbers(Control button)
        {
            Tuple<int, int> buttonNumbers = button.Tag as Tuple<int, int>;
            Square coords = new Square(buttonNumbers.ToValueTuple());
            return coords;
        }

        public void Shoot(object? sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Square coords = GetButtonNumbers(clickedButton);

            if (_playerTurn == 1)
            {
                HandlePlayerShot(clickedButton, coords, _player1, _player2, panel2);
            }
            else
            {
                HandlePlayerShot(clickedButton, coords, _player2, _player1, panel1);
            }
        }

        private void HandlePlayerShot(Button clickedButton, Square coords, Player player, Player enemyPlayer, Panel panel)
        {
            ShotSequence(coords, player, enemyPlayer, clickedButton, panel);
            enemyPlayer.IsWin();
            if (!enemyPlayer.IsAlive)
                WinSequence();
            else
                PlayerTurnSwitch();
        }

        private void ShotSequence(Square coords, Player player, Player enemyPlayer, Button clickedButton, Panel panel)
        {
            _shot = player.Shooting(coords, enemyPlayer);
            ChangeShotButton(clickedButton, enemyPlayer, coords);
            Thread.Sleep(1000);
            enemyPlayer.CheckIfShipDestroyed();
            SetDestroyedColor(enemyPlayer, panel);
        }

        private void WinSequence()
        {
            _turnLabel.Text = $"Player {_playerTurn} won!";
            _buttonStatus = false;
            ChangeButtonsStatus(panel1, panel2);
        }

        private void SetDestroyedColor(Player player, Panel panel)
        {
            foreach (var coords in player.PlayerBoard.Ocean)
            {
                if (coords.SquareStatus == SquareStatus.Destroyed)
                {
                    foreach (Control button in panel.Controls)
                    {
                        Square buttonCoords = GetButtonNumbers(button);
                        if (buttonCoords.Position == coords.Position)
                        {
                            button.BackColor = Color.IndianRed;
                            button.Refresh();
                        }
                    }
                }
            }
        }

        private void ChangeShotButton(Control clickedButton, Player player, Square coords)
        {
            if (_shot)
            {
                AfterShotSequence(clickedButton, player, coords, SquareStatus.Hit, _shotColor);
            }
            else
            {
                AfterShotSequence(clickedButton, player, coords, SquareStatus.Missed, _missColor);
            }
        }

        private void AfterShotSequence(Control clickedButton, Player player, Square coords, SquareStatus status, Color color)
        {
            clickedButton.BackColor = color;
            clickedButton.Enabled = false;
            player.PlayerBoard.Ocean[coords.Position.row, coords.Position.col].SquareStatus = status;
        }

        private void PlayerTurnSwitch()
        {
            _turnLabel = Controls["turn"];

            if (_playerTurn == 1)
            {
                _playerTurn = 2;
                HandleTurnChange(panel1, panel2, _player1);
            }
            else
            {
                _playerTurn = 1;
                HandleTurnChange(panel2, panel1, _player2);
            }
        }

        private void HandleTurnChange(Panel currentPanel, Panel enemyPanel, Player player)
        {
            Thread.Sleep(1500);
            _turnLabel.Text = $"Player turn: {_playerTurn}";
            ChangeButtonsStatus(currentPanel, _buttonStatus = true);
            ChangeButtonsStatus(enemyPanel, _buttonStatus = false);
            SetDestroyedColor(player, currentPanel);
        }

        private void AddShootingOnClick()
        {
            foreach (Control button in panel1.Controls)
            {
                button.Click += Shoot;
            }
            foreach (Control button in panel2.Controls)
            {
                button.Click += Shoot;
            }
            
        }
        private void ChangeButtonsStatus(Panel panel, bool buttonStatus)
        {
            foreach (Control button in panel.Controls)
            {
                button.Enabled = buttonStatus;
                if (!buttonStatus)
                    button.BackColor = Color.DarkGray;
                else
                {
                    if (_playerTurn == 1)
                        SetShotColors(button, _player2);
                    else
                        SetShotColors(button, _player1);
                }
            }
        }

        private void SetShotColors(Control button, Player player)
        {
            Square buttonCoords = GetButtonNumbers(button);
            button.BackColor = Color.CornflowerBlue;
            foreach (var coords in player.PlayerBoard.Ocean)
            {
                if (buttonCoords.Position.row == coords.Position.row && buttonCoords.Position.col == coords.Position.col)
                {
                    if (coords.SquareStatus == SquareStatus.Hit)
                        button.BackColor = _shotColor;
                    else if (coords.SquareStatus == SquareStatus.Missed)
                        button.BackColor = _missColor;
                }
            }
        }
        private void ChangeButtonsStatus(Panel panel1, Panel panel2)
        {
            foreach (Control button in panel1.Controls)
            {
                button.Enabled = _buttonStatus;
            }
            foreach (Control button in panel2.Controls)
            {
                button.Enabled = _buttonStatus;
            }
        }
    }

}
