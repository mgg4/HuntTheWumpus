namespace HuntTheWumpus
{
    partial class TriviaTest
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
            this.askRandomQuestionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // askRandomQuestionButton
            // 
            this.askRandomQuestionButton.Location = new System.Drawing.Point(32, 22);
            this.askRandomQuestionButton.Name = "askRandomQuestionButton";
            this.askRandomQuestionButton.Size = new System.Drawing.Size(260, 54);
            this.askRandomQuestionButton.TabIndex = 0;
            this.askRandomQuestionButton.Text = "Random Question";
            this.askRandomQuestionButton.UseVisualStyleBackColor = true;
            this.askRandomQuestionButton.Click += new System.EventHandler(this.askRandomQuestionTest);
            // 
            // TriviaTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 416);
            this.Controls.Add(this.askRandomQuestionButton);
            this.Name = "TriviaTest";
            this.Text = "TriviaTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button askRandomQuestionButton;
    }
}