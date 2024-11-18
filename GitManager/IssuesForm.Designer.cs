namespace GitManager
{
    partial class IssuesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.IssuesDataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.createNewIssueButton = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.MiddlePanel = new System.Windows.Forms.Panel();
            this.UpperPanel = new System.Windows.Forms.Panel();
            this.TipsLabel = new System.Windows.Forms.Label();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.RepoLabel = new System.Windows.Forms.Label();
            this.OwnerTextBox = new System.Windows.Forms.TextBox();
            this.RepoTextBox = new System.Windows.Forms.TextBox();
            this.LoadDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IssuesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.MiddlePanel.SuspendLayout();
            this.UpperPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IssuesDataGridView
            // 
            this.IssuesDataGridView.AllowUserToAddRows = false;
            this.IssuesDataGridView.AllowUserToDeleteRows = false;
            this.IssuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IssuesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IssuesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.IssuesDataGridView.Name = "IssuesDataGridView";
            this.IssuesDataGridView.ReadOnly = true;
            this.IssuesDataGridView.Size = new System.Drawing.Size(1042, 807);
            this.IssuesDataGridView.TabIndex = 0;
            this.IssuesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IssuesDataGridView_CellDoubleClick);
            // 
            // createNewIssueButton
            // 
            this.createNewIssueButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.createNewIssueButton.Location = new System.Drawing.Point(0, 0);
            this.createNewIssueButton.Name = "createNewIssueButton";
            this.createNewIssueButton.Size = new System.Drawing.Size(200, 79);
            this.createNewIssueButton.TabIndex = 1;
            this.createNewIssueButton.Text = "Create new issue";
            this.createNewIssueButton.UseVisualStyleBackColor = true;
            this.createNewIssueButton.Click += new System.EventHandler(this.createNewIssue_button_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.RefreshButton);
            this.BottomPanel.Controls.Add(this.createNewIssueButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 807);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1042, 79);
            this.BottomPanel.TabIndex = 2;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.RefreshButton.Location = new System.Drawing.Point(200, 0);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(200, 79);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh data";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.Controls.Add(this.IssuesDataGridView);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiddlePanel.Location = new System.Drawing.Point(0, 0);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Size = new System.Drawing.Size(1042, 807);
            this.MiddlePanel.TabIndex = 3;
            // 
            // UpperPanel
            // 
            this.UpperPanel.Controls.Add(this.LoadDataButton);
            this.UpperPanel.Controls.Add(this.RepoTextBox);
            this.UpperPanel.Controls.Add(this.OwnerTextBox);
            this.UpperPanel.Controls.Add(this.RepoLabel);
            this.UpperPanel.Controls.Add(this.OwnerLabel);
            this.UpperPanel.Controls.Add(this.TipsLabel);
            this.UpperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpperPanel.Location = new System.Drawing.Point(0, 0);
            this.UpperPanel.Name = "UpperPanel";
            this.UpperPanel.Size = new System.Drawing.Size(1042, 100);
            this.UpperPanel.TabIndex = 4;
            // 
            // TipsLabel
            // 
            this.TipsLabel.AutoSize = true;
            this.TipsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TipsLabel.Location = new System.Drawing.Point(12, 9);
            this.TipsLabel.Name = "TipsLabel";
            this.TipsLabel.Size = new System.Drawing.Size(169, 13);
            this.TipsLabel.TabIndex = 0;
            this.TipsLabel.Text = "Doubleclick to edit the issue";
            // 
            // OwnerLabel
            // 
            this.OwnerLabel.AutoSize = true;
            this.OwnerLabel.Location = new System.Drawing.Point(16, 46);
            this.OwnerLabel.Name = "OwnerLabel";
            this.OwnerLabel.Size = new System.Drawing.Size(109, 13);
            this.OwnerLabel.TabIndex = 1;
            this.OwnerLabel.Text = "Github owner\'s name:";
            // 
            // RepoLabel
            // 
            this.RepoLabel.AutoSize = true;
            this.RepoLabel.Location = new System.Drawing.Point(343, 46);
            this.RepoLabel.Name = "RepoLabel";
            this.RepoLabel.Size = new System.Drawing.Size(89, 13);
            this.RepoLabel.TabIndex = 2;
            this.RepoLabel.Text = "Repository name:";
            // 
            // OwnerTextBox
            // 
            this.OwnerTextBox.Location = new System.Drawing.Point(131, 43);
            this.OwnerTextBox.Name = "OwnerTextBox";
            this.OwnerTextBox.Size = new System.Drawing.Size(205, 20);
            this.OwnerTextBox.TabIndex = 3;
            // 
            // RepoTextBox
            // 
            this.RepoTextBox.Location = new System.Drawing.Point(438, 42);
            this.RepoTextBox.Name = "RepoTextBox";
            this.RepoTextBox.Size = new System.Drawing.Size(259, 20);
            this.RepoTextBox.TabIndex = 4;
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(718, 39);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 5;
            this.LoadDataButton.Text = "Load data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // IssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 886);
            this.Controls.Add(this.UpperPanel);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.BottomPanel);
            this.Name = "IssuesForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.IssuesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.MiddlePanel.ResumeLayout(false);
            this.UpperPanel.ResumeLayout(false);
            this.UpperPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView IssuesDataGridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button createNewIssueButton;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel MiddlePanel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Panel UpperPanel;
        private System.Windows.Forms.TextBox RepoTextBox;
        private System.Windows.Forms.TextBox OwnerTextBox;
        private System.Windows.Forms.Label RepoLabel;
        private System.Windows.Forms.Label OwnerLabel;
        private System.Windows.Forms.Label TipsLabel;
        private System.Windows.Forms.Button LoadDataButton;
    }
}

