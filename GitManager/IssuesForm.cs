using GitAPI.Methods;
using GitAPI.Schemas;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace GitManager
{
    public partial class IssuesForm : Form
    {
        private BindingSource _BindingSource = new BindingSource();

        public IssuesForm()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var responseContent = await GetMethods.GetIssues();

            var issues = JsonConvert.DeserializeObject<dynamic>(responseContent);
            _BindingSource.DataSource = issues;

            dataGridView1.DataSource = _BindingSource;
            SetupDataGridView();
        }

        /// <summary>
        /// Set the columns and their names
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();

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

                dataGridView1.Columns.Add(column);
            }
        }

        private void createNewIssue_button_Click(object sender, System.EventArgs e)
        {
            var createNewIssueForm = new CreateNewIssueForm();
            var dialogResult = createNewIssueForm.ShowDialog();
            
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            CreateIssue(title: createNewIssueForm.IssueTitle, description: createNewIssueForm.IssueDescription);
        }

        private async void CreateIssue(string title, string description)
        {
            var response = await PostMethods.PostIssue(title: title, description: description);
            // check if ok
            LoadData();
        }

    }
}