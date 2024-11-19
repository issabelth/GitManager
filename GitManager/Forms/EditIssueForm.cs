using GitAPI;
using GitAPI.Exceptions;
using GitAPI.Schemas;
using GitManager.Methods;
using System;
using System.Windows.Forms;

namespace GitManager.Forms
{
    public partial class EditIssueForm : Form
    {
        private BaseIssue _issue = null;
        private GitClient Client;

        public EditIssueForm(BaseIssue existingIssue, GitClient client)
        {
            InitializeComponent();
            this.Client = client;

            if (existingIssue == null)
            {
                this.Text = "Create a new issue";
                this.SaveButton.Text = "Create";
            }
            else
            {
                this._issue = existingIssue;
                this.TitleTextBox.Text = existingIssue.Title;
                this.DescriptionRichTextBox.Text = existingIssue.Description;
                this.CloseButton.Enabled = true;
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

            if (this._issue == null)
            {
                this._issue = new BaseIssue();
            }

            this._issue.Title = this.TitleTextBox.Text;
            this._issue.Description = this.DescriptionRichTextBox.Text;

            try
            {
                await IssuesMethods.SaveIssue(issue: this._issue, client: this.Client);
                MessageBox.Show($"[{this._issue.Number}] {this._issue.Title} : saved succesfully");
            }
            catch (ResponseException ex)
            {
                MessageBox.Show(ExceptionMethods.ManageResponseExceptions(ex));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void CloseButton_Click(object sender, EventArgs e)
        {
            if (this._issue == null)
            {
                return;
            }

            this._issue.State = "closed";

            try
            {
                await IssuesMethods.SaveIssue(issue: this._issue, client: this.Client);
                MessageBox.Show($"[{this._issue.Number}] {this._issue.Title} : closed succesfully");
            }
            catch (ResponseException ex)
            {
                MessageBox.Show(ExceptionMethods.ManageResponseExceptions(ex));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}