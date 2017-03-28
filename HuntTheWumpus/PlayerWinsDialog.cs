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
    public partial class PlayerWinsDialog : Form
    {
        public PlayerWinsDialog(int score)
        {
            InitializeComponent();
            scoreField.Text = score.ToString();
        }
    }
}
