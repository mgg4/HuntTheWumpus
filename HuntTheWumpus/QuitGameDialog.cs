using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntTheWumpus
{
    public partial class QuitGameDialog : Form
    {
        UserInterface mainForm;
        public bool answer = false;

        public QuitGameDialog(UserInterface mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void QuitGameDialog_Load(object sender, EventArgs e)
        {

        }

        private void QuitGameDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The dialog window is closing for some reason
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    // The user clicked the red "X", just close this dialog.
                    // this.DialogResult = DialogResult.Cancel;  // Don't exit
                    break;
                case CloseReason.WindowsShutDown:
                    // Windows is trying to shutdown
                    // Should try to save the game...
                    break;
                default:
                    // Some other event (user clicked button, etc.)
                    // Don't do anything
                    break;
            }
        }
    }
}
