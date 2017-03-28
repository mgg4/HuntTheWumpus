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
    public partial class NewGameDialog : Form
    {
        UserInterface mainForm;
        public NewGameDialog(UserInterface mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            playerNameField.Text = mainForm.gc.getPlayerName();
            mapSelection.SelectedIndex = 0;
        }

        private void playerNameField_TextChanged(object sender, EventArgs e)
        {
            mainForm.gc.setPlayerName(playerNameField.Text);
        }

        private void mapSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm.gc.caveSelection = mapSelection.SelectedIndex;
        }
    }
}
