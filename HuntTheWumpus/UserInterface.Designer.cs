namespace HuntTheWumpus
{
    partial class UserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHighScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyAHintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomNW = new System.Windows.Forms.Label();
            this.roomNE = new System.Windows.Forms.Label();
            this.roomN = new System.Windows.Forms.Label();
            this.roomSE = new System.Windows.Forms.Label();
            this.roomS = new System.Windows.Forms.Label();
            this.roomSW = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.playerRoomField = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.instructionText = new System.Windows.Forms.Label();
            this.NpictureBox = new System.Windows.Forms.PictureBox();
            this.NEpictureBox = new System.Windows.Forms.PictureBox();
            this.SEpictureBox = new System.Windows.Forms.PictureBox();
            this.SpictureBox = new System.Windows.Forms.PictureBox();
            this.SWpictureBox = new System.Windows.Forms.PictureBox();
            this.NWpictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.turnField = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.coinsField = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.arrowsField = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.playerNameField = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.errorField = new System.Windows.Forms.Label();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triviaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NEpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SEpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NWpictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1649, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGameToolStripMenuItem,
            this.loadGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(234, 38);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.saveGameToolStripMenuItem_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(234, 38);
            this.loadGameToolStripMenuItem.Text = "Load Game";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(234, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitGameToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.showHighScoresToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(89, 38);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(321, 38);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // quitGameToolStripMenuItem
            // 
            this.quitGameToolStripMenuItem.Name = "quitGameToolStripMenuItem";
            this.quitGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.quitGameToolStripMenuItem.Size = new System.Drawing.Size(321, 38);
            this.quitGameToolStripMenuItem.Text = "Quit Game";
            this.quitGameToolStripMenuItem.Click += new System.EventHandler(this.quitGameToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(321, 38);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // showHighScoresToolStripMenuItem
            // 
            this.showHighScoresToolStripMenuItem.Name = "showHighScoresToolStripMenuItem";
            this.showHighScoresToolStripMenuItem.Size = new System.Drawing.Size(321, 38);
            this.showHighScoresToolStripMenuItem.Text = "Show High Scores...";
            this.showHighScoresToolStripMenuItem.Click += new System.EventHandler(this.showHighScoresToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.buyAHintToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 38);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.howToPlayToolStripMenuItem.Text = "How to Play";
            this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
            // 
            // buyAHintToolStripMenuItem
            // 
            this.buyAHintToolStripMenuItem.Name = "buyAHintToolStripMenuItem";
            this.buyAHintToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.buyAHintToolStripMenuItem.Text = "Buy a hint";
            this.buyAHintToolStripMenuItem.Click += new System.EventHandler(this.buyAHintToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // roomNW
            // 
            this.roomNW.AutoSize = true;
            this.roomNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNW.Location = new System.Drawing.Point(152, 174);
            this.roomNW.Name = "roomNW";
            this.roomNW.Size = new System.Drawing.Size(59, 31);
            this.roomNW.TabIndex = 5;
            this.roomNW.Text = "NW";
            this.roomNW.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roomNW_MouseClick);
            // 
            // roomNE
            // 
            this.roomNE.AutoSize = true;
            this.roomNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNE.Location = new System.Drawing.Point(968, 174);
            this.roomNE.Name = "roomNE";
            this.roomNE.Size = new System.Drawing.Size(52, 31);
            this.roomNE.TabIndex = 6;
            this.roomNE.Text = "NE";
            this.roomNE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roomNE_MouseClick);
            // 
            // roomN
            // 
            this.roomN.AutoSize = true;
            this.roomN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomN.Location = new System.Drawing.Point(582, 70);
            this.roomN.Name = "roomN";
            this.roomN.Size = new System.Drawing.Size(34, 31);
            this.roomN.TabIndex = 7;
            this.roomN.Text = "N";
            this.roomN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roomN_MouseClick);
            // 
            // roomSE
            // 
            this.roomSE.AutoSize = true;
            this.roomSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomSE.Location = new System.Drawing.Point(968, 576);
            this.roomSE.Name = "roomSE";
            this.roomSE.Size = new System.Drawing.Size(50, 31);
            this.roomSE.TabIndex = 8;
            this.roomSE.Text = "SE";
            this.roomSE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roomSE_MouseClick);
            // 
            // roomS
            // 
            this.roomS.AutoSize = true;
            this.roomS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomS.Location = new System.Drawing.Point(584, 672);
            this.roomS.Name = "roomS";
            this.roomS.Size = new System.Drawing.Size(32, 31);
            this.roomS.TabIndex = 9;
            this.roomS.Text = "S";
            this.roomS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roomS_MouseClick);
            // 
            // roomSW
            // 
            this.roomSW.AutoSize = true;
            this.roomSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomSW.Location = new System.Drawing.Point(154, 576);
            this.roomSW.Name = "roomSW";
            this.roomSW.Size = new System.Drawing.Size(57, 31);
            this.roomSW.TabIndex = 10;
            this.roomSW.Text = "SW";
            this.roomSW.MouseClick += new System.Windows.Forms.MouseEventHandler(this.roomSW_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(770, 820);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Player Room";
            // 
            // playerRoomField
            // 
            this.playerRoomField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerRoomField.Location = new System.Drawing.Point(981, 811);
            this.playerRoomField.Name = "playerRoomField";
            this.playerRoomField.Size = new System.Drawing.Size(101, 47);
            this.playerRoomField.TabIndex = 13;
            this.playerRoomField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.instructionText);
            this.panel1.Controls.Add(this.roomSW);
            this.panel1.Controls.Add(this.playerRoomField);
            this.panel1.Controls.Add(this.roomS);
            this.panel1.Controls.Add(this.roomNW);
            this.panel1.Controls.Add(this.roomSE);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.roomN);
            this.panel1.Controls.Add(this.roomNE);
            this.panel1.Controls.Add(this.NpictureBox);
            this.panel1.Controls.Add(this.NEpictureBox);
            this.panel1.Controls.Add(this.SEpictureBox);
            this.panel1.Controls.Add(this.SpictureBox);
            this.panel1.Controls.Add(this.SWpictureBox);
            this.panel1.Controls.Add(this.NWpictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1205, 895);
            this.panel1.TabIndex = 14;
            // 
            // instructionText
            // 
            this.instructionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionText.Location = new System.Drawing.Point(30, 813);
            this.instructionText.Name = "instructionText";
            this.instructionText.Size = new System.Drawing.Size(600, 45);
            this.instructionText.TabIndex = 16;
            this.instructionText.Text = "Left-click to move.  Right-click to shoot.";
            this.instructionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NpictureBox
            // 
            this.NpictureBox.Image = global::HuntTheWumpus.Resource1.N_noTunnel;
            this.NpictureBox.InitialImage = global::HuntTheWumpus.Resource1.N_noTunnel;
            this.NpictureBox.Location = new System.Drawing.Point(400, 0);
            this.NpictureBox.Name = "NpictureBox";
            this.NpictureBox.Size = new System.Drawing.Size(400, 400);
            this.NpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NpictureBox.TabIndex = 17;
            this.NpictureBox.TabStop = false;
            // 
            // NEpictureBox
            // 
            this.NEpictureBox.Image = global::HuntTheWumpus.Resource1.NE_noTunnel;
            this.NEpictureBox.InitialImage = global::HuntTheWumpus.Resource1.NE_noTunnel;
            this.NEpictureBox.Location = new System.Drawing.Point(800, 0);
            this.NEpictureBox.Name = "NEpictureBox";
            this.NEpictureBox.Size = new System.Drawing.Size(400, 400);
            this.NEpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NEpictureBox.TabIndex = 18;
            this.NEpictureBox.TabStop = false;
            // 
            // SEpictureBox
            // 
            this.SEpictureBox.Image = global::HuntTheWumpus.Resource1.SE_noTunnel;
            this.SEpictureBox.InitialImage = global::HuntTheWumpus.Resource1.SE_noTunnel;
            this.SEpictureBox.Location = new System.Drawing.Point(800, 400);
            this.SEpictureBox.Name = "SEpictureBox";
            this.SEpictureBox.Size = new System.Drawing.Size(400, 400);
            this.SEpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SEpictureBox.TabIndex = 21;
            this.SEpictureBox.TabStop = false;
            // 
            // SpictureBox
            // 
            this.SpictureBox.Image = global::HuntTheWumpus.Resource1.S_noTunnel;
            this.SpictureBox.InitialImage = global::HuntTheWumpus.Resource1.S_noTunnel;
            this.SpictureBox.Location = new System.Drawing.Point(400, 400);
            this.SpictureBox.Name = "SpictureBox";
            this.SpictureBox.Size = new System.Drawing.Size(400, 400);
            this.SpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SpictureBox.TabIndex = 20;
            this.SpictureBox.TabStop = false;
            // 
            // SWpictureBox
            // 
            this.SWpictureBox.Image = global::HuntTheWumpus.Resource1.SW_noTunnel;
            this.SWpictureBox.InitialImage = global::HuntTheWumpus.Resource1.SW_noTunnel;
            this.SWpictureBox.Location = new System.Drawing.Point(0, 400);
            this.SWpictureBox.Name = "SWpictureBox";
            this.SWpictureBox.Size = new System.Drawing.Size(400, 400);
            this.SWpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SWpictureBox.TabIndex = 19;
            this.SWpictureBox.TabStop = false;
            // 
            // NWpictureBox
            // 
            this.NWpictureBox.Image = global::HuntTheWumpus.Resource1.NW_noTunnel;
            this.NWpictureBox.InitialImage = global::HuntTheWumpus.Resource1.NW_noTunnel;
            this.NWpictureBox.Location = new System.Drawing.Point(0, 0);
            this.NWpictureBox.Name = "NWpictureBox";
            this.NWpictureBox.Size = new System.Drawing.Size(400, 400);
            this.NWpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NWpictureBox.TabIndex = 14;
            this.NWpictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.turnField);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.coinsField);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.arrowsField);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.messageBox);
            this.panel2.Controls.Add(this.playerNameField);
            this.panel2.Location = new System.Drawing.Point(1274, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 566);
            this.panel2.TabIndex = 15;
            // 
            // turnField
            // 
            this.turnField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnField.Location = new System.Drawing.Point(144, 294);
            this.turnField.Name = "turnField";
            this.turnField.Size = new System.Drawing.Size(120, 35);
            this.turnField.TabIndex = 101;
            this.turnField.Text = "turnField";
            this.turnField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 31);
            this.label5.TabIndex = 100;
            this.label5.Text = "Turn:";
            // 
            // coinsField
            // 
            this.coinsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinsField.Location = new System.Drawing.Point(144, 397);
            this.coinsField.Name = "coinsField";
            this.coinsField.Size = new System.Drawing.Size(120, 35);
            this.coinsField.TabIndex = 5;
            this.coinsField.Text = "coinsField";
            this.coinsField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Coins:";
            // 
            // arrowsField
            // 
            this.arrowsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrowsField.Location = new System.Drawing.Point(144, 348);
            this.arrowsField.Name = "arrowsField";
            this.arrowsField.Size = new System.Drawing.Size(120, 35);
            this.arrowsField.TabIndex = 3;
            this.arrowsField.Text = "arrowsField";
            this.arrowsField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Arrows:";
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBox.CausesValidation = false;
            this.messageBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(10, 119);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(330, 118);
            this.messageBox.TabIndex = 99;
            this.messageBox.TabStop = false;
            this.messageBox.Text = "I smell a Wumpus!!\r\nBats nearby!\r\nI feel a draft!";
            // 
            // playerNameField
            // 
            this.playerNameField.AutoSize = true;
            this.playerNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameField.Location = new System.Drawing.Point(4, 15);
            this.playerNameField.Name = "playerNameField";
            this.playerNameField.Size = new System.Drawing.Size(181, 31);
            this.playerNameField.TabIndex = 0;
            this.playerNameField.Text = "Player Name";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.errorField);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 989);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1649, 100);
            this.panel3.TabIndex = 16;
            // 
            // errorField
            // 
            this.errorField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorField.ForeColor = System.Drawing.Color.Red;
            this.errorField.Location = new System.Drawing.Point(0, 0);
            this.errorField.Name = "errorField";
            this.errorField.Size = new System.Drawing.Size(1649, 100);
            this.errorField.TabIndex = 101;
            this.errorField.Text = "errorField";
            this.errorField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triviaToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(69, 38);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // triviaToolStripMenuItem
            // 
            this.triviaToolStripMenuItem.Name = "triviaToolStripMenuItem";
            this.triviaToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.triviaToolStripMenuItem.Text = "Trivia";
            this.triviaToolStripMenuItem.Click += new System.EventHandler(this.showTestTriviaDialog);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1649, 1089);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1675, 1160);
            this.Name = "UserInterface";
            this.Text = "Hunt The Wumpus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserInterface_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NEpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SEpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NWpictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyAHintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label roomNW;
        private System.Windows.Forms.Label roomNE;
        private System.Windows.Forms.Label roomN;
        private System.Windows.Forms.Label roomSE;
        private System.Windows.Forms.Label roomS;
        private System.Windows.Forms.Label roomSW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label playerRoomField;
        private System.Windows.Forms.ToolStripMenuItem showHighScoresToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label playerNameField;
        private System.Windows.Forms.Label instructionText;
        private System.Windows.Forms.Label coinsField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label arrowsField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label turnField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox NWpictureBox;
        private System.Windows.Forms.PictureBox NpictureBox;
        private System.Windows.Forms.PictureBox NEpictureBox;
        private System.Windows.Forms.PictureBox SEpictureBox;
        private System.Windows.Forms.PictureBox SpictureBox;
        private System.Windows.Forms.PictureBox SWpictureBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label errorField;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triviaToolStripMenuItem;
    }
}

