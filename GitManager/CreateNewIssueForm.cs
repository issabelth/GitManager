using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitManager
{
    public partial class CreateNewIssueForm : Form
    {
        public string IssueTitle;
        public string IssueDescription;
        private bool _checkedOkay = true;


        public CreateNewIssueForm()
        {
            InitializeComponent();
        }

        private void CreateNewIssueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.IssueTitle = this.TitleTextBox.Text;
            this.IssueDescription = this.DescriptionLabel.Text;
        }

        private void CreateNewIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            

        }

    }
}
