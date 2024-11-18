using GitAPI;
using GitAPI.Exceptions;
using GitAPI.Methods;
using GitAPI.Schemas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace GitManager
{
    public partial class IssuesForm : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        GitClient Client;

        public IssuesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the columns and their names
        /// </summary>
        private void SetupDataGridView()
        {
            IssuesDataGridView.Columns.Clear();

            var properties = typeof(Issue).GetProperties();

            foreach (var property in properties)
            {
                var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                string columnText = displayName ?? property.Name;

                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    HeaderText = columnText,
                    DataPropertyName = property.Name,
                    ReadOnly = true,
                };

                IssuesDataGridView.Columns.Add(column);
            }
        }

        private async void LoadData()
        {
            try
            {
                this.Client = CreateClient();
                var responseContent = await GetMethods.GetIssues(this.Client);
                var issues = JsonConvert.DeserializeObject<dynamic>(responseContent);
                _bindingSource.DataSource = issues;
                IssuesDataGridView.DataSource = _bindingSource;
                SetupDataGridView();
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

        private GitClient CreateClient()
        {
            return new GitClient(
                gitOwnerName: this.OwnerTextBox.Text,
                gitRepoName: this.RepoTextBox.Text);
        }

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
            OpenEditIssueForm(issue: null);
        }

        private async void IssuesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                string issueId = IssuesDataGridView[1, e.RowIndex].Value?.ToString(); // get the number of issue from the row
                var responseContent = await GetMethods.GetIssue(client: this.Client, issueId: issueId);
                var issue = JsonConvert.DeserializeObject<Issue>(responseContent);
                OpenEditIssueForm(issue: issue);
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

        private void OpenEditIssueForm(Issue issue)
        {
            try
            {
                var createNewIssueForm = new EditIssueForm(client: this.Client, existingIssue: issue);
                createNewIssueForm.ShowDialog();
            }
            catch (ResponseException ex)
            {
                MessageBox.Show(ExceptionMethods.ManageResponseExceptions(ex));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            System.Threading.Thread.Sleep(1000); // wait 1 sec
            LoadData();
        }

    }
}