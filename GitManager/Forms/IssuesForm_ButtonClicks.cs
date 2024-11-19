using GitAPI;
using GitAPI.Exceptions;
using GitAPI.Schemas;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GitManager.Forms
{
    /// <summary>
    /// IssuesForm_ButtonClicks: button-click methods of IssuesForm
    /// </summary>
    public partial class IssuesForm
    {

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.OwnerTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.RepoTextBox.Text))
            {
                MessageBox.Show("Provide Git owner's and repo's names!");
                return;
            }

            LoadData();
        }

        private void createNewIssue_button_Click(object sender, EventArgs e)
        {
            OpenEditIssueForm(issueId: null);
        }

        private void IssuesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                int columnIndex = IssuesDataGridView.Columns[nameof(BaseIssue.Number)].Index;
                string issueId = IssuesDataGridView[columnIndex, e.RowIndex].Value?.ToString();
                OpenEditIssueForm(issueId: issueId);
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

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt";
                openFileDialog.Title = "Select an options file";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string filePath = openFileDialog.FileName;
                this.OptionsFilePathTextBox.Text = filePath;

                var appOpts = ApiOptions.FromFile(filePath: filePath);

                if (appOpts == null)
                {
                    MessageBox.Show("Could not load your options file. Check the file and try again.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(appOpts.Host))
                {
                    MessageBox.Show("Host is not provided. Correct the file and try again.");
                    return;
                }

                var hostKey = HostData.GetHostKey(hostName: appOpts.Host);

                if (!hostKey.HasValue)
                {
                    MessageBox.Show("Host does not exist in the dictionary. Correct the host in file or add a new key in dictionary and try again.");
                    return;
                }

                HostData.Host = hostKey.Value;
                this.OwnerTextBox.Text = appOpts.Owner;
                this.RepoTextBox.Text = appOpts.Repo;
                LoadData();
                this.LoadDataButton.Enabled = false;
            }
        }

    }
}