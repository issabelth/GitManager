using GitManager.Methods;
using System;
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

            var response = await IssuesMethods.CreateIssue(title: this.TitleTextBox.Text, description: this.DescriptionRichTextBox.Text);

            if (!string.IsNullOrWhiteSpace(response))
            {
                MessageBox.Show("Issue created successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create the issue.");
                this.DialogResult = DialogResult.Cancel;
            }
        }

    }
}