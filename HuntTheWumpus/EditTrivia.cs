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
    public partial class EditTrivia : Form
    {
        Trivia trivia;
        public EditTrivia(Trivia trivia)
        {
            InitializeComponent();
            this.trivia = trivia;
            int i;

            // Columns and structure already defined

            // Populate the fields
            i = 1;
            foreach (Question q in trivia.questions)
            {
                string[] item = { i.ToString(), q.questionType.ToString(), q.questionText };
                ListViewItem lvi = new ListViewItem(item);
                triviaListView.Items.Add(lvi);
                i++;
            }
            // Display the form
            this.Show();

            // The rest of the actions will be handled as events
        }

        // Examples found at http://stackoverflow.com/questions/11311153/creating-columns-in-listview-and-add-items

        
    }
}
