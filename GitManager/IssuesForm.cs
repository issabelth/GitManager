using GitAPI.Methods;
using GitAPI.Schemas;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace GitManager
{
    public partial class IssuesForm : Form
    {
        private BindingSource _bindingSource = new BindingSource();

        public IssuesForm()
        {
            InitializeComponent();
            LoadData();
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
            var responseContent = await GetMethods.GetIssues();

            var issues = JsonConvert.DeserializeObject<dynamic>(responseContent);
            _bindingSource.DataSource = issues;
            IssuesDataGridView.DataSource = _bindingSource;
            SetupDataGridView();
        }

        private void createNewIssue_button_Click(object sender, EventArgs e)
        {
            var createNewIssueForm = new EditIssueForm(createNew: true);
            var dialogResult = createNewIssueForm.ShowDialog();
            System.Threading.Thread.Sleep(1000); // wait 1 sec
            LoadData();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void IssuesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}