namespace Scoresheet_Reader
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.scoresheetSplitOutputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.customScoresheetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ssAABC = new System.Windows.Forms.RadioButton();
            this.ssBJCP = new System.Windows.Forms.RadioButton();
            this.competitionName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numberOfScoresheetsInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scoresheetComboBox = new System.Windows.Forms.ComboBox();
            this.scoresheetReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveScoresheetLocationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scoresheetFileNameInput = new System.Windows.Forms.TextBox();
            this.saveScoresheetsButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scannedPdfFileNameTextBox = new System.Windows.Forms.TextBox();
            this.folderSaveTextBox = new System.Windows.Forms.TextBox();
            this.saveScoresheetFolderButton = new System.Windows.Forms.Button();
            this.processScoresheetsButton = new System.Windows.Forms.Button();
            this.openScannedScoresheetButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.customScoresheetOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveGeneratedScoresheetsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfScoresheetsInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoresheetReportsBindingSource)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputFileOpenFileDialog
            // 
            this.inputFileOpenFileDialog.Filter = "Portable Document Format|*.pdf";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 221);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 8, 0);
            this.statusStrip1.Size = new System.Drawing.Size(529, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(218, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Ready...";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.customScoresheetButton);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.competitionName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.numberOfScoresheetsInput);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.scoresheetComboBox);
            this.tabPage2.Controls.Add(this.saveScoresheetLocationButton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.scoresheetFileNameInput);
            this.tabPage2.Controls.Add(this.saveScoresheetsButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Print Scoresheets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // customScoresheetButton
            // 
            this.customScoresheetButton.Location = new System.Drawing.Point(356, 118);
            this.customScoresheetButton.Name = "customScoresheetButton";
            this.customScoresheetButton.Size = new System.Drawing.Size(145, 23);
            this.customScoresheetButton.TabIndex = 12;
            this.customScoresheetButton.Text = "Custom Scoresheet File...";
            this.customScoresheetButton.UseVisualStyleBackColor = true;
            this.customScoresheetButton.Click += new System.EventHandler(this.customScoresheetButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ssAABC);
            this.groupBox1.Controls.Add(this.ssBJCP);
            this.groupBox1.Location = new System.Drawing.Point(372, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 35);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Score Type";
            // 
            // ssAABC
            // 
            this.ssAABC.AutoSize = true;
            this.ssAABC.Location = new System.Drawing.Point(63, 12);
            this.ssAABC.Name = "ssAABC";
            this.ssAABC.Size = new System.Drawing.Size(53, 17);
            this.ssAABC.TabIndex = 10;
            this.ssAABC.Text = "AABC";
            this.ssAABC.UseVisualStyleBackColor = true;
            // 
            // ssBJCP
            // 
            this.ssBJCP.AutoSize = true;
            this.ssBJCP.Checked = true;
            this.ssBJCP.Location = new System.Drawing.Point(6, 12);
            this.ssBJCP.Name = "ssBJCP";
            this.ssBJCP.Size = new System.Drawing.Size(51, 17);
            this.ssBJCP.TabIndex = 9;
            this.ssBJCP.TabStop = true;
            this.ssBJCP.Text = "BJCP";
            this.ssBJCP.UseVisualStyleBackColor = true;
            // 
            // competitionName
            // 
            this.competitionName.Location = new System.Drawing.Point(159, 93);
            this.competitionName.Margin = new System.Windows.Forms.Padding(2);
            this.competitionName.Name = "competitionName";
            this.competitionName.Size = new System.Drawing.Size(340, 20);
            this.competitionName.TabIndex = 8;
            this.competitionName.Text = "Merri Mashers IPA Competition 2017";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Competition Name";
            // 
            // numberOfScoresheetsInput
            // 
            this.numberOfScoresheetsInput.Location = new System.Drawing.Point(8, 93);
            this.numberOfScoresheetsInput.Margin = new System.Windows.Forms.Padding(2);
            this.numberOfScoresheetsInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberOfScoresheetsInput.Name = "numberOfScoresheetsInput";
            this.numberOfScoresheetsInput.Size = new System.Drawing.Size(65, 20);
            this.numberOfScoresheetsInput.TabIndex = 4;
            this.numberOfScoresheetsInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of scoresheets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Scoresheet Type";
            // 
            // scoresheetComboBox
            // 
            this.scoresheetComboBox.DataSource = this.scoresheetReportsBindingSource;
            this.scoresheetComboBox.DisplayMember = "name";
            this.scoresheetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scoresheetComboBox.FormattingEnabled = true;
            this.scoresheetComboBox.Location = new System.Drawing.Point(8, 55);
            this.scoresheetComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.scoresheetComboBox.Name = "scoresheetComboBox";
            this.scoresheetComboBox.Size = new System.Drawing.Size(339, 21);
            this.scoresheetComboBox.TabIndex = 3;
            this.scoresheetComboBox.ValueMember = "filePath";
            // 
            // scoresheetReportsBindingSource
            // 
            this.scoresheetReportsBindingSource.DataSource = typeof(Scoresheet_Reader.scoresheetReports);
            // 
            // saveScoresheetLocationButton
            // 
            this.saveScoresheetLocationButton.Location = new System.Drawing.Point(424, 18);
            this.saveScoresheetLocationButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveScoresheetLocationButton.Name = "saveScoresheetLocationButton";
            this.saveScoresheetLocationButton.Size = new System.Drawing.Size(75, 23);
            this.saveScoresheetLocationButton.TabIndex = 2;
            this.saveScoresheetLocationButton.Text = "Browse...";
            this.saveScoresheetLocationButton.UseVisualStyleBackColor = true;
            this.saveScoresheetLocationButton.Click += new System.EventHandler(this.saveScoresheetLocationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Save As Filename";
            // 
            // scoresheetFileNameInput
            // 
            this.scoresheetFileNameInput.Location = new System.Drawing.Point(7, 18);
            this.scoresheetFileNameInput.Margin = new System.Windows.Forms.Padding(2);
            this.scoresheetFileNameInput.Name = "scoresheetFileNameInput";
            this.scoresheetFileNameInput.Size = new System.Drawing.Size(339, 20);
            this.scoresheetFileNameInput.TabIndex = 1;
            this.scoresheetFileNameInput.Text = "c:\\scoresheets\\example.pdf";
            // 
            // saveScoresheetsButton
            // 
            this.saveScoresheetsButton.Location = new System.Drawing.Point(8, 118);
            this.saveScoresheetsButton.Name = "saveScoresheetsButton";
            this.saveScoresheetsButton.Size = new System.Drawing.Size(75, 23);
            this.saveScoresheetsButton.TabIndex = 5;
            this.saveScoresheetsButton.Text = "Save";
            this.saveScoresheetsButton.UseVisualStyleBackColor = true;
            this.saveScoresheetsButton.Click += new System.EventHandler(this.saveScoresheetsButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.scannedPdfFileNameTextBox);
            this.tabPage1.Controls.Add(this.folderSaveTextBox);
            this.tabPage1.Controls.Add(this.saveScoresheetFolderButton);
            this.tabPage1.Controls.Add(this.processScoresheetsButton);
            this.tabPage1.Controls.Add(this.openScannedScoresheetButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Process Scanned Images";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Save to Folder";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Scanned PDF Filename";
            // 
            // scannedPdfFileNameTextBox
            // 
            this.scannedPdfFileNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.scannedPdfFileNameTextBox.Name = "scannedPdfFileNameTextBox";
            this.scannedPdfFileNameTextBox.Size = new System.Drawing.Size(403, 20);
            this.scannedPdfFileNameTextBox.TabIndex = 1;
            this.scannedPdfFileNameTextBox.Text = "D:\\OneDrive\\Merri Mashers\\IPA Comp 2017\\Scoresheets-With-Barcode-Test.pdf";
            // 
            // folderSaveTextBox
            // 
            this.folderSaveTextBox.Location = new System.Drawing.Point(6, 57);
            this.folderSaveTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.folderSaveTextBox.Name = "folderSaveTextBox";
            this.folderSaveTextBox.Size = new System.Drawing.Size(403, 20);
            this.folderSaveTextBox.TabIndex = 4;
            this.folderSaveTextBox.Text = "C:\\Scoresheets";
            // 
            // saveScoresheetFolderButton
            // 
            this.saveScoresheetFolderButton.Location = new System.Drawing.Point(423, 57);
            this.saveScoresheetFolderButton.Name = "saveScoresheetFolderButton";
            this.saveScoresheetFolderButton.Size = new System.Drawing.Size(75, 23);
            this.saveScoresheetFolderButton.TabIndex = 5;
            this.saveScoresheetFolderButton.Text = "Browse...";
            this.saveScoresheetFolderButton.UseVisualStyleBackColor = true;
            this.saveScoresheetFolderButton.Click += new System.EventHandler(this.saveScoresheetFolderButton_Click);
            // 
            // processScoresheetsButton
            // 
            this.processScoresheetsButton.Location = new System.Drawing.Point(3, 82);
            this.processScoresheetsButton.Name = "processScoresheetsButton";
            this.processScoresheetsButton.Size = new System.Drawing.Size(75, 23);
            this.processScoresheetsButton.TabIndex = 0;
            this.processScoresheetsButton.Text = "Save";
            this.processScoresheetsButton.UseVisualStyleBackColor = true;
            this.processScoresheetsButton.Click += new System.EventHandler(this.processScoresheetsButton_Click);
            // 
            // openScannedScoresheetButton
            // 
            this.openScannedScoresheetButton.Location = new System.Drawing.Point(423, 19);
            this.openScannedScoresheetButton.Name = "openScannedScoresheetButton";
            this.openScannedScoresheetButton.Size = new System.Drawing.Size(75, 23);
            this.openScannedScoresheetButton.TabIndex = 2;
            this.openScannedScoresheetButton.Text = "Browse...";
            this.openScannedScoresheetButton.UseVisualStyleBackColor = true;
            this.openScannedScoresheetButton.Click += new System.EventHandler(this.openScannedScoresheetButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 196);
            this.tabControl1.TabIndex = 6;
            // 
            // customScoresheetOpenFileDialog
            // 
            this.customScoresheetOpenFileDialog.Filter = "Crystal Report Files|*.rpt";
            // 
            // saveGeneratedScoresheetsFileDialog
            // 
            this.saveGeneratedScoresheetsFileDialog.DefaultExt = "pdf";
            this.saveGeneratedScoresheetsFileDialog.Filter = "Portable Document Format|*.pdf";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 243);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Scoresheet Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfScoresheetsInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoresheetReportsBindingSource)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog inputFileOpenFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.FolderBrowserDialog scoresheetSplitOutputFolderBrowserDialog;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox scoresheetComboBox;
        private System.Windows.Forms.BindingSource scoresheetReportsBindingSource;
        private System.Windows.Forms.Button saveScoresheetLocationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scoresheetFileNameInput;
        private System.Windows.Forms.Button saveScoresheetsButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox scannedPdfFileNameTextBox;
        private System.Windows.Forms.TextBox folderSaveTextBox;
        private System.Windows.Forms.Button saveScoresheetFolderButton;
        private System.Windows.Forms.Button processScoresheetsButton;
        private System.Windows.Forms.Button openScannedScoresheetButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.NumericUpDown numberOfScoresheetsInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox competitionName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ssAABC;
        private System.Windows.Forms.RadioButton ssBJCP;
        private System.Windows.Forms.Button customScoresheetButton;
        private System.Windows.Forms.OpenFileDialog customScoresheetOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog saveGeneratedScoresheetsFileDialog;
    }
}

