﻿using GitAPI;
using GitAPI.Exceptions;
using GitAPI.Methods;
using GitAPI.Schemas;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
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
                $"Token: <your security token>{Environment.NewLine}" +
                $"Owner: <repository owner's name>{Environment.NewLine}" +
                $"Repo:  <repository name>{Environment.NewLine}";
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
                AppClient.CreateClient(
                    ownerName: this.OwnerTextBox.Text,
                    repoName: this.RepoTextBox.Text);

                var responseContent = await GetMethods.GetIssues(AppClient.Client);
                var issues = JsonConvert.DeserializeObject<dynamic>(responseContent);
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
                string issueId = IssuesDataGridView[1, e.RowIndex].Value?.ToString(); // get the number of issue from the row
                var responseContent = await GetMethods.GetIssue(client: AppClient.Client, issueId: issueId);
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
                var createNewIssueForm = new EditIssueForm(client: AppClient.Client, existingIssue: issue);
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

        private void LoadOptionsButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.OptionsFilePathTextBox.Text))
            {
                MessageBox.Show("Provide options file path!");
                return;
            }

            var appOpts = ApiOptions.FromFile(filePath: this.OptionsFilePathTextBox.Text);

            if (appOpts == null)
            {
                MessageBox.Show("Could not load your options file. Check the file and try again.");
                return;
            }

            this.OwnerTextBox.Text = appOpts.Owner;
            this.RepoTextBox.Text = appOpts.Repo;
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

                this.OwnerTextBox.Text = appOpts.Owner;
                this.RepoTextBox.Text = appOpts.Repo;
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