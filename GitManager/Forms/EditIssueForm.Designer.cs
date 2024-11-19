namespace GitManager.Forms
{
    partial class EditIssueForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CloseIssueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveButton.Location = new System.Drawing.Point(0, 427);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(584, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(63, 40);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(30, 72);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Description";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(110, 37);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(455, 20);
            this.TitleTextBox.TabIndex = 3;
            // 
            // DescriptionRichTextBox
            // 
            this.DescriptionRichTextBox.Location = new System.Drawing.Point(110, 72);
            this.DescriptionRichTextBox.Name = "DescriptionRichTextBox";
            this.DescriptionRichTextBox.Size = new System.Drawing.Size(455, 330);
            this.DescriptionRichTextBox.TabIndex = 4;
            this.DescriptionRichTextBox.Text = "";
            // 
            // CloseIssueButton
            // 
            this.CloseIssueButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CloseIssueButton.Enabled = false;
            this.CloseIssueButton.Location = new System.Drawing.Point(0, 0);
            this.CloseIssueButton.Name = "CloseIssueButton";
            this.CloseIssueButton.Size = new System.Drawing.Size(584, 23);
            this.CloseIssueButton.TabIndex = 5;
            this.CloseIssueButton.Text = "Close issue";
            this.CloseIssueButton.UseVisualStyleBackColor = true;
            this.CloseIssueButton.Click += new System.EventHandler(this.CloseIssueButton_Click);
            // 
            // EditIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.CloseIssueButton);
            this.Controls.Add(this.DescriptionRichTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.SaveButton);
            this.Name = "EditIssueForm";
            this.Text = "Edit an issue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditIssueForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.RichTextBox DescriptionRichTextBox;
        private System.Windows.Forms.Button CloseIssueButton;
    }
}