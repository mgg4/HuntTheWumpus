namespace HuntTheWumpus
{
    partial class NewGameDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGameDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.playerNameField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mapSelection = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // playerNameField
            // 
            this.playerNameField.Location = new System.Drawing.Point(168, 36);
            this.playerNameField.MaxLength = 40;
            this.playerNameField.Name = "playerNameField";
            this.playerNameField.Size = new System.Drawing.Size(400, 31);
            this.playerNameField.TabIndex = 1;
            this.playerNameField.TextChanged += new System.EventHandler(this.playerNameField_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Map";
            // 
            // mapSelection
            // 
            this.mapSelection.DisplayMember = "Default";
            this.mapSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapSelection.FormattingEnabled = true;
            this.mapSelection.ItemHeight = 31;
            this.mapSelection.Items.AddRange(new object[] {
            "Random",
            "Cave #1",
            "Cave #2",
            "Cave #3"});
            this.mapSelection.Location = new System.Drawing.Point(168, 97);
            this.mapSelection.Name = "mapSelection";
            this.mapSelection.Size = new System.Drawing.Size(400, 190);
            this.mapSelection.TabIndex = 3;
            this.mapSelection.ValueMember = "Random";
            this.mapSelection.SelectedIndexChanged += new System.EventHandler(this.mapSelection_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(168, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(396, 430);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 65);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // NewGameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 534);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mapSelection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playerNameField);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGameDialog";
            this.Text = "Hunt The Wumpus - New Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerNameField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox mapSelection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}