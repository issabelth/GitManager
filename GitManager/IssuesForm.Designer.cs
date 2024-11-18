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
            this.ViewPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.IssuesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.ViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IssuesDataGridView
            // 
            this.IssuesDataGridView.AllowUserToOrderColumns = true;
            this.IssuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IssuesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IssuesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.IssuesDataGridView.Name = "IssuesDataGridView";
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
            // ViewPanel
            // 
            this.ViewPanel.Controls.Add(this.IssuesDataGridView);
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewPanel.Location = new System.Drawing.Point(0, 0);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(1042, 807);
            this.ViewPanel.TabIndex = 3;
            // 
            // IssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 886);
            this.Controls.Add(this.ViewPanel);
            this.Controls.Add(this.BottomPanel);
            this.Name = "IssuesForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.IssuesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.ViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView IssuesDataGridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button createNewIssueButton;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel ViewPanel;
        private System.Windows.Forms.Button RefreshButton;
    }
}

