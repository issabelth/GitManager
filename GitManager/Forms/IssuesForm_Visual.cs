using GitAPI;
using System;
using System.Drawing;

namespace GitManager.Forms
{
    /// <summary>
    /// IssuesForm_Visual: visual methods for IssuesForm
    /// </summary>
    public partial class IssuesForm
    {

        /// <summary>
        /// Setting the examples text look clear
        /// </summary>
        private void SetExampleTextLookGood()
        {
            this.ExampleRichTextBox.Clear();

            string hostText = "Host: ";
            string tokenText = "Token: ";
            string ownerText = "Owner: ";
            string repoText = "Repo: ";

            // Append the Host text in bold
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Bold);
            this.ExampleRichTextBox.AppendText(hostText);
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Regular);
            this.ExampleRichTextBox.SelectionStart = this.ExampleRichTextBox.TextLength;
            this.ExampleRichTextBox.SelectionLength = 0;
            this.ExampleRichTextBox.AppendText($"<one of the following: {HostData.GetAllHostsString()} >");
            this.ExampleRichTextBox.AppendText(Environment.NewLine);

            // Append the Token text in bold
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Bold);
            this.ExampleRichTextBox.AppendText(tokenText);
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Regular);
            this.ExampleRichTextBox.SelectionStart = this.ExampleRichTextBox.TextLength;
            this.ExampleRichTextBox.SelectionLength = 0;
            this.ExampleRichTextBox.AppendText("<your generated personal access token>");
            this.ExampleRichTextBox.AppendText(Environment.NewLine);

            // Append the Owner text in bold
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Bold);
            this.ExampleRichTextBox.AppendText(ownerText);
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Regular);
            this.ExampleRichTextBox.SelectionStart = this.ExampleRichTextBox.TextLength;
            this.ExampleRichTextBox.SelectionLength = 0;
            this.ExampleRichTextBox.AppendText("<repository owner's name (needed for GitHub)>");
            this.ExampleRichTextBox.AppendText(Environment.NewLine);

            // Append the Repo text in bold
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Bold);
            this.ExampleRichTextBox.AppendText(repoText);
            this.ExampleRichTextBox.SelectionFont = new Font(this.ExampleRichTextBox.Font, FontStyle.Regular);
            this.ExampleRichTextBox.SelectionStart = this.ExampleRichTextBox.TextLength;
            this.ExampleRichTextBox.SelectionLength = 0;
            this.ExampleRichTextBox.AppendText("<repository/project name>");
            this.ExampleRichTextBox.AppendText(Environment.NewLine);
        }
    }
}
