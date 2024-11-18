using GitAPI.Schemas;
using GitManager.Methods;
using System;
using System.Windows.Forms;

namespace GitManager
{
    public partial class EditIssueForm : Form
    {
        private Issue _issue = null;

        public EditIssueForm(Issue existingIssue)
        {
            InitializeComponent();

            if (existingIssue == null)
            {
                this.Text = "Create a new issue";
                this.SaveButton.Text = "Create";
            }
            else
            {
                this._issue = existingIssue;
                this.TitleTextBox.Text = existingIssue.Title;
                this.DescriptionRichTextBox.Text = existingIssue.Body;
            }
        }

        private void EditIssueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK &&
                string.IsNullOrWhiteSpace(this.TitleTextBox.Text))
            {
                MessageBox.Show("Issue title is mandatory!");
                e.Cancel = true;
                return;
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                return;
            }

            string response = string.Empty;

            if (this._issue == null)
            {
                response = await IssuesMethods.CreateIssue(
                    title: this.TitleTextBox.Text,
                    description: this.DescriptionRichTextBox.Text);
            }
            else
            {
                response = await IssuesMethods.UpdateIssue(
                    issueId: this._issue.Number,
                    title: this.TitleTextBox.Text,
                    description: this.DescriptionRichTextBox.Text);
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                MessageBox.Show($"Issue saved successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save the issue.");
                this.DialogResult = DialogResult.Cancel;
            }
        }

    }
}