namespace BattleshipWithForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            SettingUpShips settingUpShips = new SettingUpShips();
            Hide();
            settingUpShips.ShowDialog();
            Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}