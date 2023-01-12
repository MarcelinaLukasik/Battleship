namespace BattleshipWithForms
{
    partial class SettingUpShips
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Destroyer = new System.Windows.Forms.Button();
            this.Submarine = new System.Windows.Forms.Button();
            this.Battleship = new System.Windows.Forms.Button();
            this.Cruiser = new System.Windows.Forms.Button();
            this.Carrier = new System.Windows.Forms.Button();
            this.Done = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.settingTurn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Location = new System.Drawing.Point(495, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(144, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ships to set:";
            // 
            // Destroyer
            // 
            this.Destroyer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Destroyer.BackColor = System.Drawing.Color.Brown;
            this.Destroyer.FlatAppearance.BorderSize = 0;
            this.Destroyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Destroyer.Location = new System.Drawing.Point(144, 191);
            this.Destroyer.Name = "Destroyer";
            this.Destroyer.Size = new System.Drawing.Size(50, 50);
            this.Destroyer.TabIndex = 2;
            this.Destroyer.UseVisualStyleBackColor = false;
            this.Destroyer.Click += new System.EventHandler(this.Destroyer_Click);
            // 
            // Submarine
            // 
            this.Submarine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Submarine.BackColor = System.Drawing.Color.Tomato;
            this.Submarine.FlatAppearance.BorderSize = 0;
            this.Submarine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Submarine.Location = new System.Drawing.Point(144, 298);
            this.Submarine.Name = "Submarine";
            this.Submarine.Size = new System.Drawing.Size(100, 50);
            this.Submarine.TabIndex = 3;
            this.Submarine.UseVisualStyleBackColor = false;
            this.Submarine.Click += new System.EventHandler(this.Submarine_Click);
            // 
            // Battleship
            // 
            this.Battleship.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Battleship.BackColor = System.Drawing.Color.Coral;
            this.Battleship.FlatAppearance.BorderSize = 0;
            this.Battleship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Battleship.Location = new System.Drawing.Point(144, 414);
            this.Battleship.Name = "Battleship";
            this.Battleship.Size = new System.Drawing.Size(150, 50);
            this.Battleship.TabIndex = 4;
            this.Battleship.UseVisualStyleBackColor = false;
            this.Battleship.Click += new System.EventHandler(this.Battleship_Click);
            // 
            // Cruiser
            // 
            this.Cruiser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cruiser.BackColor = System.Drawing.Color.SandyBrown;
            this.Cruiser.FlatAppearance.BorderSize = 0;
            this.Cruiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cruiser.Location = new System.Drawing.Point(144, 530);
            this.Cruiser.Name = "Cruiser";
            this.Cruiser.Size = new System.Drawing.Size(200, 50);
            this.Cruiser.TabIndex = 5;
            this.Cruiser.UseVisualStyleBackColor = false;
            this.Cruiser.Click += new System.EventHandler(this.Cruiser_Click);
            // 
            // Carrier
            // 
            this.Carrier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Carrier.BackColor = System.Drawing.Color.BurlyWood;
            this.Carrier.FlatAppearance.BorderSize = 0;
            this.Carrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Carrier.Location = new System.Drawing.Point(144, 638);
            this.Carrier.Name = "Carrier";
            this.Carrier.Size = new System.Drawing.Size(250, 50);
            this.Carrier.TabIndex = 6;
            this.Carrier.UseVisualStyleBackColor = false;
            this.Carrier.Click += new System.EventHandler(this.Carrier_Click);
            // 
            // Done
            // 
            this.Done.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Done.BackColor = System.Drawing.Color.SandyBrown;
            this.Done.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Done.Location = new System.Drawing.Point(681, 641);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(246, 68);
            this.Done.TabIndex = 7;
            this.Done.Text = "DONE";
            this.Done.UseVisualStyleBackColor = false;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(144, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destroyer";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(144, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Submarine";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(144, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Battleship";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(144, 480);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cruiser";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(144, 598);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "Carrier";
            // 
            // settingTurn
            // 
            this.settingTurn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.settingTurn.AutoSize = true;
            this.settingTurn.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.settingTurn.Location = new System.Drawing.Point(144, 22);
            this.settingTurn.Name = "settingTurn";
            this.settingTurn.Size = new System.Drawing.Size(276, 38);
            this.settingTurn.TabIndex = 13;
            this.settingTurn.Text = "Player turn: 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(115, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 694);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Location = new System.Drawing.Point(478, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(634, 632);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // SettingUpShips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleshipWithForms.Properties.Resources.ocean_view_1;
            this.ClientSize = new System.Drawing.Size(1224, 721);
            this.Controls.Add(this.settingTurn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.Carrier);
            this.Controls.Add(this.Cruiser);
            this.Controls.Add(this.Battleship);
            this.Controls.Add(this.Submarine);
            this.Controls.Add(this.Destroyer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "SettingUpShips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingUpShips";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SettingUpShips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button Destroyer;
        private Button Submarine;
        private Button Battleship;
        private Button Cruiser;
        private Button Carrier;
        private Button Done;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label settingTurn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}