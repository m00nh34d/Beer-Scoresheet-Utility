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
            this.printScoresheetsTabPage = new System.Windows.Forms.TabPage();
            this.customLogoFilenameBrowse = new System.Windows.Forms.Button();
            this.customLogoFilenameInput = new System.Windows.Forms.TextBox();
            this.saveScoresheetReport = new System.Windows.Forms.Button();
            this.customScoresheetLabel = new System.Windows.Forms.Label();
            this.customScoresheetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ssAABC = new System.Windows.Forms.RadioButton();
            this.ssBJCP = new System.Windows.Forms.RadioButton();
            this.competitionName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numberOfScoresheetsInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveScoresheetLocationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scoresheetFileNameInput = new System.Windows.Forms.TextBox();
            this.processImagesTabPage = new System.Windows.Forms.TabPage();
            this.includeLeadingZerosCheckbox = new System.Windows.Forms.CheckBox();
            this.imageFilenamePrefixInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.customLogoFilenameOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.defaultTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.printScoresheetsTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfScoresheetsInput)).BeginInit();
            this.processImagesTabPage.SuspendLayout();
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
            // printScoresheetsTabPage
            // 
            this.printScoresheetsTabPage.Controls.Add(this.customLogoFilenameBrowse);
            this.printScoresheetsTabPage.Controls.Add(this.customLogoFilenameInput);
            this.printScoresheetsTabPage.Controls.Add(this.saveScoresheetReport);
            this.printScoresheetsTabPage.Controls.Add(this.customScoresheetLabel);
            this.printScoresheetsTabPage.Controls.Add(this.customScoresheetButton);
            this.printScoresheetsTabPage.Controls.Add(this.groupBox1);
            this.printScoresheetsTabPage.Controls.Add(this.competitionName);
            this.printScoresheetsTabPage.Controls.Add(this.label4);
            this.printScoresheetsTabPage.Controls.Add(this.numberOfScoresheetsInput);
            this.printScoresheetsTabPage.Controls.Add(this.label3);
            this.printScoresheetsTabPage.Controls.Add(this.label2);
            this.printScoresheetsTabPage.Controls.Add(this.saveScoresheetLocationButton);
            this.printScoresheetsTabPage.Controls.Add(this.label1);
            this.printScoresheetsTabPage.Controls.Add(this.scoresheetFileNameInput);
            this.printScoresheetsTabPage.Location = new System.Drawing.Point(4, 22);
            this.printScoresheetsTabPage.Name = "printScoresheetsTabPage";
            this.printScoresheetsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.printScoresheetsTabPage.Size = new System.Drawing.Size(504, 170);
            this.printScoresheetsTabPage.TabIndex = 1;
            this.printScoresheetsTabPage.Text = "Print Scoresheets";
            this.printScoresheetsTabPage.UseVisualStyleBackColor = true;
            // 
            // customLogoFilenameBrowse
            // 
            this.customLogoFilenameBrowse.Location = new System.Drawing.Point(424, 53);
            this.customLogoFilenameBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.customLogoFilenameBrowse.Name = "customLogoFilenameBrowse";
            this.customLogoFilenameBrowse.Size = new System.Drawing.Size(75, 23);
            this.customLogoFilenameBrowse.TabIndex = 16;
            this.customLogoFilenameBrowse.Text = "Browse...";
            this.customLogoFilenameBrowse.UseVisualStyleBackColor = true;
            this.customLogoFilenameBrowse.Click += new System.EventHandler(this.customLogoFilenameBrowse_Click);
            // 
            // customLogoFilenameInput
            // 
            this.customLogoFilenameInput.Location = new System.Drawing.Point(7, 55);
            this.customLogoFilenameInput.Margin = new System.Windows.Forms.Padding(2);
            this.customLogoFilenameInput.Name = "customLogoFilenameInput";
            this.customLogoFilenameInput.Size = new System.Drawing.Size(413, 20);
            this.customLogoFilenameInput.TabIndex = 15;
            this.defaultTooltip.SetToolTip(this.customLogoFilenameInput, "Image file to use for the logo in these scoresheets.\r\nBJCP style uses a 104x104px" +
        " 96DPI logo\r\nAABC style uses as 491x67px 96DPI logo");
            // 
            // saveScoresheetReport
            // 
            this.saveScoresheetReport.Location = new System.Drawing.Point(8, 117);
            this.saveScoresheetReport.Margin = new System.Windows.Forms.Padding(2);
            this.saveScoresheetReport.Name = "saveScoresheetReport";
            this.saveScoresheetReport.Size = new System.Drawing.Size(65, 24);
            this.saveScoresheetReport.TabIndex = 14;
            this.saveScoresheetReport.Text = "Save";
            this.saveScoresheetReport.UseVisualStyleBackColor = true;
            this.saveScoresheetReport.Click += new System.EventHandler(this.saveScoresheetReport_Click);
            // 
            // customScoresheetLabel
            // 
            this.customScoresheetLabel.AutoSize = true;
            this.customScoresheetLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.customScoresheetLabel.Location = new System.Drawing.Point(209, 146);
            this.customScoresheetLabel.Name = "customScoresheetLabel";
            this.customScoresheetLabel.Size = new System.Drawing.Size(141, 13);
            this.customScoresheetLabel.TabIndex = 13;
            this.customScoresheetLabel.Text = "Custom Scoresheet Loaded!";
            this.customScoresheetLabel.Visible = false;
            // 
            // customScoresheetButton
            // 
            this.customScoresheetButton.Location = new System.Drawing.Point(356, 141);
            this.customScoresheetButton.Name = "customScoresheetButton";
            this.customScoresheetButton.Size = new System.Drawing.Size(145, 23);
            this.customScoresheetButton.TabIndex = 9;
            this.customScoresheetButton.Text = "Custom Scoresheet File...";
            this.customScoresheetButton.UseVisualStyleBackColor = true;
            this.customScoresheetButton.Click += new System.EventHandler(this.customScoresheetButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ssAABC);
            this.groupBox1.Controls.Add(this.ssBJCP);
            this.groupBox1.Location = new System.Drawing.Point(375, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 35);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scoresheet Type";
            this.defaultTooltip.SetToolTip(this.groupBox1, "Select the pre-defined scoresheet style.\r\nScores are as per the guidelines for ea" +
        "ch sheet.");
            // 
            // ssAABC
            // 
            this.ssAABC.AutoSize = true;
            this.ssAABC.Location = new System.Drawing.Point(63, 12);
            this.ssAABC.Name = "ssAABC";
            this.ssAABC.Size = new System.Drawing.Size(53, 17);
            this.ssAABC.TabIndex = 5;
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
            this.ssBJCP.TabIndex = 4;
            this.ssBJCP.TabStop = true;
            this.ssBJCP.Text = "BJCP";
            this.ssBJCP.UseVisualStyleBackColor = true;
            // 
            // competitionName
            // 
            this.competitionName.Location = new System.Drawing.Point(161, 116);
            this.competitionName.Margin = new System.Windows.Forms.Padding(2);
            this.competitionName.Name = "competitionName";
            this.competitionName.Size = new System.Drawing.Size(340, 20);
            this.competitionName.TabIndex = 7;
            this.competitionName.Text = "Homebrew Competition 2017";
            this.defaultTooltip.SetToolTip(this.competitionName, "Name that will appear at the top of each scoresheet.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 101);
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
            this.numberOfScoresheetsInput.TabIndex = 6;
            this.defaultTooltip.SetToolTip(this.numberOfScoresheetsInput, "Number of scoresheets to generate.\r\nYou will need a unique scroesheet for each en" +
        "try/judge. (Do not photocopy scoreshets)");
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
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Custom Logo Path";
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
            this.scoresheetFileNameInput.Size = new System.Drawing.Size(413, 20);
            this.scoresheetFileNameInput.TabIndex = 1;
            this.scoresheetFileNameInput.Text = "c:\\scoresheets\\example.pdf";
            // 
            // processImagesTabPage
            // 
            this.processImagesTabPage.Controls.Add(this.includeLeadingZerosCheckbox);
            this.processImagesTabPage.Controls.Add(this.imageFilenamePrefixInput);
            this.processImagesTabPage.Controls.Add(this.label7);
            this.processImagesTabPage.Controls.Add(this.label6);
            this.processImagesTabPage.Controls.Add(this.label5);
            this.processImagesTabPage.Controls.Add(this.scannedPdfFileNameTextBox);
            this.processImagesTabPage.Controls.Add(this.folderSaveTextBox);
            this.processImagesTabPage.Controls.Add(this.saveScoresheetFolderButton);
            this.processImagesTabPage.Controls.Add(this.processScoresheetsButton);
            this.processImagesTabPage.Controls.Add(this.openScannedScoresheetButton);
            this.processImagesTabPage.Location = new System.Drawing.Point(4, 22);
            this.processImagesTabPage.Name = "processImagesTabPage";
            this.processImagesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.processImagesTabPage.Size = new System.Drawing.Size(504, 170);
            this.processImagesTabPage.TabIndex = 0;
            this.processImagesTabPage.Text = "Process Scanned Images";
            this.processImagesTabPage.UseVisualStyleBackColor = true;
            // 
            // includeLeadingZerosCheckbox
            // 
            this.includeLeadingZerosCheckbox.AutoSize = true;
            this.includeLeadingZerosCheckbox.Checked = true;
            this.includeLeadingZerosCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeLeadingZerosCheckbox.Location = new System.Drawing.Point(167, 96);
            this.includeLeadingZerosCheckbox.Name = "includeLeadingZerosCheckbox";
            this.includeLeadingZerosCheckbox.Size = new System.Drawing.Size(194, 17);
            this.includeLeadingZerosCheckbox.TabIndex = 12;
            this.includeLeadingZerosCheckbox.Text = "Include Leading Zeros in Filename?";
            this.defaultTooltip.SetToolTip(this.includeLeadingZerosCheckbox, resources.GetString("includeLeadingZerosCheckbox.ToolTip"));
            this.includeLeadingZerosCheckbox.UseVisualStyleBackColor = true;
            // 
            // imageFilenamePrefixInput
            // 
            this.imageFilenamePrefixInput.Location = new System.Drawing.Point(6, 94);
            this.imageFilenamePrefixInput.Margin = new System.Windows.Forms.Padding(2);
            this.imageFilenamePrefixInput.Name = "imageFilenamePrefixInput";
            this.imageFilenamePrefixInput.Size = new System.Drawing.Size(156, 20);
            this.imageFilenamePrefixInput.TabIndex = 9;
            this.imageFilenamePrefixInput.Text = "IMG-";
            this.defaultTooltip.SetToolTip(this.imageFilenamePrefixInput, "All files will begin with the text entered here. \r\neg. barcode 00345 with a prefi" +
        "x IMG- will have a filename IMG-00345.jpg");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Filename Prefix";
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
            this.processScoresheetsButton.Location = new System.Drawing.Point(6, 119);
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
            this.tabControl1.Controls.Add(this.printScoresheetsTabPage);
            this.tabControl1.Controls.Add(this.processImagesTabPage);
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
            // customLogoFilenameOpenFileDialog
            // 
            this.customLogoFilenameOpenFileDialog.Filter = "All Supported Image Formats|*.jpg;*.jpeg;*.png;*.bmp|JPEG Files|*.jpg|PNG Files|*" +
    ".png|BMP Files|*.bmp";
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
            this.Text = "Beer Scoresheet Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.printScoresheetsTabPage.ResumeLayout(false);
            this.printScoresheetsTabPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfScoresheetsInput)).EndInit();
            this.processImagesTabPage.ResumeLayout(false);
            this.processImagesTabPage.PerformLayout();
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
        private System.Windows.Forms.TabPage printScoresheetsTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveScoresheetLocationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scoresheetFileNameInput;
        private System.Windows.Forms.TabPage processImagesTabPage;
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
        private System.Windows.Forms.Label customScoresheetLabel;
        private System.Windows.Forms.Button saveScoresheetReport;
        private System.Windows.Forms.Button customLogoFilenameBrowse;
        private System.Windows.Forms.TextBox customLogoFilenameInput;
        private System.Windows.Forms.OpenFileDialog customLogoFilenameOpenFileDialog;
        private System.Windows.Forms.TextBox imageFilenamePrefixInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox includeLeadingZerosCheckbox;
        private System.Windows.Forms.ToolTip defaultTooltip;
    }
}

