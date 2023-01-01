namespace XivMate.DataGathering.ACTLogs.Forms
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.actLogLocationTextBox = new System.Windows.Forms.TextBox();
            this.validateBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FilesSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.findFilesBtn = new System.Windows.Forms.Button();
            this.parseFileBtn = new System.Windows.Forms.Button();
            this.parseFileTitleLabel = new System.Windows.Forms.Label();
            this.fileParseLabel = new System.Windows.Forms.Label();
            this.parseFileProgBar = new System.Windows.Forms.ProgressBar();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actLogFileStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTLogFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.outputLogTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCTLogFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ACT Log Location";
            // 
            // actLogLocationTextBox
            // 
            this.actLogLocationTextBox.Location = new System.Drawing.Point(118, 7);
            this.actLogLocationTextBox.Name = "actLogLocationTextBox";
            this.actLogLocationTextBox.Size = new System.Drawing.Size(446, 20);
            this.actLogLocationTextBox.TabIndex = 2;
            // 
            // validateBtn
            // 
            this.validateBtn.Location = new System.Drawing.Point(12, 67);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(75, 23);
            this.validateBtn.TabIndex = 3;
            this.validateBtn.Text = "Validate";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.actLogFileStatusDataGridViewTextBoxColumn,
            this.FilesSize});
            this.dataGridView1.DataSource = this.aCTLogFileBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(548, 168);
            this.dataGridView1.TabIndex = 4;
            // 
            // FilesSize
            // 
            this.FilesSize.DataPropertyName = "FilesSize";
            this.FilesSize.Frozen = true;
            this.FilesSize.HeaderText = "FilesSize";
            this.FilesSize.Name = "FilesSize";
            this.FilesSize.ReadOnly = true;
            // 
            // findFilesBtn
            // 
            this.findFilesBtn.Location = new System.Drawing.Point(16, 270);
            this.findFilesBtn.Name = "findFilesBtn";
            this.findFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.findFilesBtn.TabIndex = 5;
            this.findFilesBtn.Text = "Find Files";
            this.findFilesBtn.UseVisualStyleBackColor = true;
            this.findFilesBtn.Click += new System.EventHandler(this.findFilesBtn_Click);
            // 
            // parseFileBtn
            // 
            this.parseFileBtn.Location = new System.Drawing.Point(16, 390);
            this.parseFileBtn.Name = "parseFileBtn";
            this.parseFileBtn.Size = new System.Drawing.Size(75, 23);
            this.parseFileBtn.TabIndex = 6;
            this.parseFileBtn.Text = "Parse Files";
            this.parseFileBtn.UseVisualStyleBackColor = true;
            this.parseFileBtn.Click += new System.EventHandler(this.parseFileBtn_Click);
            // 
            // parseFileTitleLabel
            // 
            this.parseFileTitleLabel.AutoSize = true;
            this.parseFileTitleLabel.Location = new System.Drawing.Point(13, 336);
            this.parseFileTitleLabel.Name = "parseFileTitleLabel";
            this.parseFileTitleLabel.Size = new System.Drawing.Size(0, 13);
            this.parseFileTitleLabel.TabIndex = 7;
            this.parseFileTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fileParseLabel
            // 
            this.fileParseLabel.AutoSize = true;
            this.fileParseLabel.Location = new System.Drawing.Point(80, 336);
            this.fileParseLabel.Name = "fileParseLabel";
            this.fileParseLabel.Size = new System.Drawing.Size(0, 13);
            this.fileParseLabel.TabIndex = 8;
            this.fileParseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // parseFileProgBar
            // 
            this.parseFileProgBar.Location = new System.Drawing.Point(16, 352);
            this.parseFileProgBar.Name = "parseFileProgBar";
            this.parseFileProgBar.Size = new System.Drawing.Size(543, 16);
            this.parseFileProgBar.TabIndex = 9;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Frozen = true;
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // actLogFileStatusDataGridViewTextBoxColumn
            // 
            this.actLogFileStatusDataGridViewTextBoxColumn.DataPropertyName = "ActLogFileStatus";
            this.actLogFileStatusDataGridViewTextBoxColumn.Frozen = true;
            this.actLogFileStatusDataGridViewTextBoxColumn.HeaderText = "ActLogFileStatus";
            this.actLogFileStatusDataGridViewTextBoxColumn.Name = "actLogFileStatusDataGridViewTextBoxColumn";
            this.actLogFileStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCTLogFileBindingSource
            // 
            this.aCTLogFileBindingSource.DataSource = typeof(ACTLogFile);
            // 
            // outputLogTxt
            // 
            this.outputLogTxt.Location = new System.Drawing.Point(118, 33);
            this.outputLogTxt.Name = "outputLogTxt";
            this.outputLogTxt.Size = new System.Drawing.Size(446, 20);
            this.outputLogTxt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Output Log Location";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 450);
            this.Controls.Add(this.outputLogTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.parseFileProgBar);
            this.Controls.Add(this.fileParseLabel);
            this.Controls.Add(this.parseFileTitleLabel);
            this.Controls.Add(this.parseFileBtn);
            this.Controls.Add(this.findFilesBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.actLogLocationTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ACT Log Uploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCTLogFileBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox actLogLocationTextBox;
        private System.Windows.Forms.Button validateBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button findFilesBtn;
        private System.Windows.Forms.BindingSource aCTLogFileBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actLogFileStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilesSize;
        private System.Windows.Forms.Button parseFileBtn;
        private System.Windows.Forms.Label parseFileTitleLabel;
        private System.Windows.Forms.Label fileParseLabel;
        private System.Windows.Forms.ProgressBar parseFileProgBar;
        private System.Windows.Forms.TextBox outputLogTxt;
        private System.Windows.Forms.Label label2;
    }
}