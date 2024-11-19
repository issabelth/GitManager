using System.Drawing;
using System;

namespace GitManager.Forms
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
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CreateNewIssueButton = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.MiddlePanel = new System.Windows.Forms.Panel();
            this.UpperPanel = new System.Windows.Forms.Panel();
            this.PrepareFileLabel = new System.Windows.Forms.Label();
            this.ExampleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.OptionsFilePathTextBox = new System.Windows.Forms.TextBox();
            this.OptionsFilePathLabel = new System.Windows.Forms.Label();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.RepoTextBox = new System.Windows.Forms.TextBox();
            this.OwnerTextBox = new System.Windows.Forms.TextBox();
            this.RepoLabel = new System.Windows.Forms.Label();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.TipsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IssuesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
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
            this.IssuesDataGridView.Size = new System.Drawing.Size(1147, 736);
            this.IssuesDataGridView.TabIndex = 0;
            this.IssuesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IssuesDataGridView_CellDoubleClick);
            // 
            // CreateNewIssueButton
            // 
            this.CreateNewIssueButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CreateNewIssueButton.Enabled = false;
            this.CreateNewIssueButton.Location = new System.Drawing.Point(0, 0);
            this.CreateNewIssueButton.Name = "CreateNewIssueButton";
            this.CreateNewIssueButton.Size = new System.Drawing.Size(200, 41);
            this.CreateNewIssueButton.TabIndex = 1;
            this.CreateNewIssueButton.Text = "Create new issue";
            this.CreateNewIssueButton.UseVisualStyleBackColor = true;
            this.CreateNewIssueButton.Click += new System.EventHandler(this.createNewIssue_button_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.RefreshButton);
            this.BottomPanel.Controls.Add(this.CreateNewIssueButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 845);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1147, 41);
            this.BottomPanel.TabIndex = 2;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(200, 0);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(200, 41);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh data";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.Controls.Add(this.IssuesDataGridView);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MiddlePanel.Location = new System.Drawing.Point(0, 109);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Size = new System.Drawing.Size(1147, 736);
            this.MiddlePanel.TabIndex = 3;
            // 
            // UpperPanel
            // 
            this.UpperPanel.Controls.Add(this.PrepareFileLabel);
            this.UpperPanel.Controls.Add(this.ExampleRichTextBox);
            this.UpperPanel.Controls.Add(this.SelectFileButton);
            this.UpperPanel.Controls.Add(this.OptionsFilePathTextBox);
            this.UpperPanel.Controls.Add(this.OptionsFilePathLabel);
            this.UpperPanel.Controls.Add(this.LoadDataButton);
            this.UpperPanel.Controls.Add(this.RepoTextBox);
            this.UpperPanel.Controls.Add(this.OwnerTextBox);
            this.UpperPanel.Controls.Add(this.RepoLabel);
            this.UpperPanel.Controls.Add(this.OwnerLabel);
            this.UpperPanel.Controls.Add(this.TipsLabel);
            this.UpperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpperPanel.Location = new System.Drawing.Point(0, 0);
            this.UpperPanel.Name = "UpperPanel";
            this.UpperPanel.Size = new System.Drawing.Size(1147, 103);
            this.UpperPanel.TabIndex = 4;
            // 
            // PrepareFileLabel
            // 
            this.PrepareFileLabel.AutoSize = true;
            this.PrepareFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrepareFileLabel.Location = new System.Drawing.Point(594, 9);
            this.PrepareFileLabel.Name = "PrepareFileLabel";
            this.PrepareFileLabel.Size = new System.Drawing.Size(205, 13);
            this.PrepareFileLabel.TabIndex = 11;
            this.PrepareFileLabel.Text = "Prepare .txt files with this example:";
            // 
            // ExampleRichTextBox
            // 
            this.ExampleRichTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExampleRichTextBox.Location = new System.Drawing.Point(810, 0);
            this.ExampleRichTextBox.Name = "ExampleRichTextBox";
            this.ExampleRichTextBox.ReadOnly = true;
            this.ExampleRichTextBox.Size = new System.Drawing.Size(337, 103);
            this.ExampleRichTextBox.TabIndex = 10;
            this.ExampleRichTextBox.Text = "";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(695, 37);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(97, 23);
            this.SelectFileButton.TabIndex = 9;
            this.SelectFileButton.Text = "Select file";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // OptionsFilePathTextBox
            // 
            this.OptionsFilePathTextBox.Enabled = false;
            this.OptionsFilePathTextBox.Location = new System.Drawing.Point(123, 39);
            this.OptionsFilePathTextBox.Name = "OptionsFilePathTextBox";
            this.OptionsFilePathTextBox.Size = new System.Drawing.Size(566, 20);
            this.OptionsFilePathTextBox.TabIndex = 7;
            this.OptionsFilePathTextBox.Text = "Select .txt file with Owner, Repo and Token to load your app options";
            // 
            // OptionsFilePathLabel
            // 
            this.OptionsFilePathLabel.AutoSize = true;
            this.OptionsFilePathLabel.Location = new System.Drawing.Point(31, 44);
            this.OptionsFilePathLabel.Name = "OptionsFilePathLabel";
            this.OptionsFilePathLabel.Size = new System.Drawing.Size(86, 13);
            this.OptionsFilePathLabel.TabIndex = 6;
            this.OptionsFilePathLabel.Text = "Options file path:";
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Enabled = false;
            this.LoadDataButton.Location = new System.Drawing.Point(695, 66);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(97, 23);
            this.LoadDataButton.TabIndex = 5;
            this.LoadDataButton.Text = "Load data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // RepoTextBox
            // 
            this.RepoTextBox.Location = new System.Drawing.Point(430, 67);
            this.RepoTextBox.Name = "RepoTextBox";
            this.RepoTextBox.Size = new System.Drawing.Size(259, 20);
            this.RepoTextBox.TabIndex = 4;
            this.RepoTextBox.TextChanged += new System.EventHandler(this.RepoTextBox_TextChanged);
            // 
            // OwnerTextBox
            // 
            this.OwnerTextBox.Location = new System.Drawing.Point(123, 68);
            this.OwnerTextBox.Name = "OwnerTextBox";
            this.OwnerTextBox.Size = new System.Drawing.Size(205, 20);
            this.OwnerTextBox.TabIndex = 3;
            this.OwnerTextBox.TextChanged += new System.EventHandler(this.OwnerTextBox_TextChanged);
            // 
            // RepoLabel
            // 
            this.RepoLabel.AutoSize = true;
            this.RepoLabel.Location = new System.Drawing.Point(335, 71);
            this.RepoLabel.Name = "RepoLabel";
            this.RepoLabel.Size = new System.Drawing.Size(89, 13);
            this.RepoLabel.TabIndex = 2;
            this.RepoLabel.Text = "Repository name:";
            // 
            // OwnerLabel
            // 
            this.OwnerLabel.AutoSize = true;
            this.OwnerLabel.Location = new System.Drawing.Point(8, 71);
            this.OwnerLabel.Name = "OwnerLabel";
            this.OwnerLabel.Size = new System.Drawing.Size(109, 13);
            this.OwnerLabel.TabIndex = 1;
            this.OwnerLabel.Text = "Github owner\'s name:";
            // 
            // TipsLabel
            // 
            this.TipsLabel.AutoSize = true;
            this.TipsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TipsLabel.Location = new System.Drawing.Point(12, 9);
            this.TipsLabel.Name = "TipsLabel";
            this.TipsLabel.Size = new System.Drawing.Size(218, 13);
            this.TipsLabel.TabIndex = 0;
            this.TipsLabel.Text = "Doubleclick to edit or close the issue";
            // 
            // IssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 886);
            this.Controls.Add(this.UpperPanel);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.BottomPanel);
            this.Name = "IssuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.IssuesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.MiddlePanel.ResumeLayout(false);
            this.UpperPanel.ResumeLayout(false);
            this.UpperPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView IssuesDataGridView;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button CreateNewIssueButton;
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
        private System.Windows.Forms.TextBox OptionsFilePathTextBox;
        private System.Windows.Forms.Label OptionsFilePathLabel;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.RichTextBox ExampleRichTextBox;
        private System.Windows.Forms.Label PrepareFileLabel;
    }
}

