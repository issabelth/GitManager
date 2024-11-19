using GitAPI;
using GitAPI.Exceptions;
using GitAPI.Methods;
using GitAPI.Schemas;
using GitManager.Methods;
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
        private EditIssueForm _editIssueForm;
        private BindingSource _bindingSource = new BindingSource();
        bool _ownerFilled = false;
        bool _repoFilled = false;

        public IssuesForm()
        {
            InitializeComponent();
            SetExampleTextLookGood();
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

        private async void OpenEditIssueForm(string issueId)
        {
            if (_editIssueForm != null &&
                !_editIssueForm.IsDisposed)
            {
                _editIssueForm.BringToFront();
                _editIssueForm.Focus();
                return;
            }
            try
            {
                BaseIssue issue = null;

                if (!string.IsNullOrWhiteSpace(issueId))
                {
                    var responseContent = await IssuesMethods.GetIssue(client: AppClient.Client, issueId: issueId);
                    issue = JsonConvert.DeserializeObject<BaseIssue>(responseContent);
                }

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