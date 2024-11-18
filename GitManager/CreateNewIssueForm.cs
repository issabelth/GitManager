using GitAPI.Methods;
using GitManager.Methods;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GitManager
{
    public partial class CreateNewIssueForm : Form
    {

        public CreateNewIssueForm()
        {
            InitializeComponent();
        }

        private void CreateNewIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK &&
                string.IsNullOrWhiteSpace(this.TitleTextBox.Text))
            {
                MessageBox.Show("Issue title is mandatory!");
                e.Cancel = true;
                return;
            }
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                return;
            }

            // Await the CreateIssue method to get the result
            var response = await IssuesMethods.CreateIssue(title: this.TitleTextBox.Text, description: this.DescriptionRichTextBox.Text);

            // Optionally handle the response here, e.g., show a message or log it
            MessageBox.Show(response);
        }

    }
}