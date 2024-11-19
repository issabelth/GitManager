using GitAPI;
using GitAPI.Exceptions;
using GitAPI.Methods;
using GitAPI.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GitManager.Forms
{
    public partial class IssuesForm : Form
    {
        private BindingSource _bindingSource = new BindingSource();
        bool _ownerFilled = false;
        bool _repoFilled = false;

        public IssuesForm()
        {
            InitializeComponent();
            this.ExampleRichTextBox.Text = 
                $"Prepare a .txt file with this example:{Environment.NewLine}" +
                $"Host: <host name (Github/Gitlab/Bitbucket)>{Environment.NewLine}" +
                $"Token: <your security token>{Environment.NewLine}" +
                $"Owner: <repository owner's name (needed for GitHub)>{Environment.NewLine}" +
                $"Repo:  <repository name (needed for GitHub)>{Environment.NewLine}";
        }

        /// <summary>
        /// Set the columns and their names
        /// </summary>
        private void SetupDataGridView()
        {
            IssuesDataGridView.Columns.Clear();
            var properties = typeof(BaseIssue).GetProperties();

            if (properties == null ||
                properties.Count() <= 0)
            {
                return;
            }

            foreach (var property in properties)
            {
                var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                string columnText = displayName ?? property.Name;

                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    Name = property.Name,
                    HeaderText = columnText,
                    DataPropertyName = property.Name,
                    ReadOnly = true,
                };

                IssuesDataGridView.Columns.Add(column);
            }
        }

        public async void LoadData()
        {
            try
            {
                ApiOptions.ProjectName = this.RepoTextBox.Text;

                AppClient.CreateClient(
                    ownerName: this.OwnerTextBox.Text,
                    repoName: this.RepoTextBox.Text);

                var responseContent = await GetMethods.GetIssues(AppClient.Client);
                var issues = JsonConvert.DeserializeObject<List<BaseIssue>>(responseContent);

                _bindingSource.DataSource = issues;
                IssuesDataGridView.DataSource = _bindingSource;
                SetupDataGridView();
                CreateNewIssueButton.Enabled = true;
                RefreshButton.Enabled = true;
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
                int columnIndex = IssuesDataGridView.Columns[nameof(BaseIssue.Number)].Index;
                string issueId = IssuesDataGridView[columnIndex, e.RowIndex].Value?.ToString();

                var responseContent = await GetMethods.GetIssue(client: AppClient.Client, issueId: issueId);
                var issue = JsonConvert.DeserializeObject<BaseIssue>(responseContent);
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

        private void OpenEditIssueForm(BaseIssue issue)
        {
            try
            {
                var createNewIssueForm = new EditIssueForm(client: AppClient.Client, existingIssue: issue, parentForm: this);
                createNewIssueForm.ShowDialog(this);
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

                if (!HostData.HostNameDictionary.Any(x => x.Value == appOpts.Host.ToLower()))
                {
                    MessageBox.Show("Host is incorrect. Correct the file and try again.");
                    return;
                }

                HostData.Host = HostData.HostNameDictionary.FirstOrDefault(x => x.Value == appOpts.Host.ToLower()).Key;
                this.OwnerTextBox.Text = appOpts.Owner;
                this.RepoTextBox.Text = appOpts.Repo;
                LoadData();
                this.LoadDataButton.Enabled = false;
            }
        }

        private void RepoTextBox_TextChanged(object sender, EventArgs e)
        {
            this._repoFilled = !string.IsNullOrWhiteSpace(this.RepoTextBox.Text);
            EnableLoadDataButton();
        }

        private void OwnerTextBox_TextChanged(object sender, EventArgs e)
        {
            this._ownerFilled = !string.IsNullOrWhiteSpace(this.OwnerTextBox.Text);
            EnableLoadDataButton();
        }

        private void EnableLoadDataButton()
        {
            if (this._repoFilled &&
                this._ownerFilled)
            {
                this.LoadDataButton.Enabled = true;
            }
            else
            {
                this.LoadDataButton.Enabled = false;
            }
        }

    }
}