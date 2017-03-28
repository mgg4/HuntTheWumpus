namespace HuntTheWumpus
{
    partial class PlayerLosesDialog
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
            this.button1 = new System.Windows.Forms.Button();
            this.reasonField = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(135, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // reasonField
            // 
            this.reasonField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonField.Location = new System.Drawing.Point(87, 144);
            this.reasonField.Name = "reasonField";
            this.reasonField.Size = new System.Drawing.Size(600, 42);
            this.reasonField.TabIndex = 4;
            this.reasonField.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "You have Died!";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(440, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Play Again";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PlayerLosesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 393);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reasonField);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerLosesDialog";
            this.Text = "You Lose!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label reasonField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}