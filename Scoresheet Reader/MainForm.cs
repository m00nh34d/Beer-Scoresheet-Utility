/*
    Beer Scoresheet Utility - A small utility to create and scan in scoresheets for beer judging competitions
    Copyright (C) 2017  Cameron Eldridge

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Jot;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using NLog;
using NLog.Targets;

namespace Scoresheet_Reader
{
    public partial class MainForm : Form
    {

        enum runState { Running, Ready }
        runState runStateValue = new runState();
        string reportPath = "";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        bool backgroundWorkerError = false;

        public MainForm()
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            runStateValue = runState.Ready;

            logger.Debug("Program started");
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //Using JOT to store field changes and window position between each run of the application
            Services.Tracker.Configure(this)
                 .IdentifyAs("main window")
                 .AddProperties<MainForm>(w => w.Height, w => w.Width, w => w.Top, w => w.Left, w => w.WindowState)
                 .RegisterPersistTrigger(nameof(SizeChanged))
                 .Apply();

            Services.Tracker.Configure(scannedPdfFileNameTextBox)
                .IdentifyAs("fileNameTxtBox")
                .AddProperties(nameof(scannedPdfFileNameTextBox.Text))
                .RegisterPersistTrigger(nameof(scannedPdfFileNameTextBox.TextChanged))
                .SetAutoPersistEnabled(false)
                .Apply();

            Services.Tracker.Configure(folderSaveTextBox)
                .IdentifyAs("folderSaveTextBox")
                .AddProperties(nameof(folderSaveTextBox.Text))
                .RegisterPersistTrigger(nameof(folderSaveTextBox.TextChanged))
                .SetAutoPersistEnabled(false)
                .Apply();

            Services.Tracker.Configure(scoresheetFileNameInput)
                .IdentifyAs("scoresheetFileNameInput")
                .AddProperties(nameof(scoresheetFileNameInput.Text))
                .RegisterPersistTrigger(nameof(scoresheetFileNameInput.TextChanged))
                .SetAutoPersistEnabled(false)
                .Apply();

            Services.Tracker.Configure(numberOfScoresheetsInput)
                .IdentifyAs("numberOfScoresheetsInput")
                .AddProperties(nameof(numberOfScoresheetsInput.Value))
                .RegisterPersistTrigger(nameof(numberOfScoresheetsInput.ValueChanged))
                .SetAutoPersistEnabled(false)
                .Apply();

            Services.Tracker.Configure(competitionName)
                .IdentifyAs("competitionName")
                .AddProperties(nameof(competitionName.Text))
                .RegisterPersistTrigger(nameof(competitionName.TextChanged))
                .SetAutoPersistEnabled(false)
                .Apply();

            Services.Tracker.Configure(customLogoFilenameInput)
                .IdentifyAs("customLogoFilenameInput")
                .AddProperties(nameof(customLogoFilenameInput.Text))
                .RegisterPersistTrigger(nameof(customLogoFilenameInput.TextChanged))
                .SetAutoPersistEnabled(false)
                .Apply();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState.GetType() == typeof(Tuple<string, int>))
            {
                Tuple<string, int> message = (Tuple<string, int>)e.UserState;
                string messageType = message.Item1;
                int messageValue = message.Item2;
                switch (messageType)
                {
                    case "progressBarValue":
                        toolStripProgressBar1.Value = messageValue;
                        break;
                    case "progressBarMaximum":
                        toolStripProgressBar1.Maximum = messageValue;
                        break;
                    default:
                        break;
                }
            }
            if (e.UserState.GetType() == typeof(Tuple<string, string>))
            {
                Tuple<string, string> message = (Tuple<string, string>)e.UserState;
                string messageType = message.Item1;
                string messageValue = message.Item2;
                switch (messageType)
                {
                    case "msgBoxAppendText":
                        //msgBox.AppendText(messageValue);
                        break;
                    case "statusLabelText":
                        toolStripStatusLabel1.Text = messageValue;
                        break;
                    default:
                        break;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                processScoresheetsButton.Enabled = true;
                toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
                toolStripStatusLabel1.Text = "Cancelled!";
                logger.Debug("Cancel pressed");
            }
            else if(backgroundWorkerError)
            {
                toolStripStatusLabel1.Text = "Error Occured...";
            }
            else
            {
                toolStripStatusLabel1.Text = "Done!";
            }
            processScoresheetsButton.Text = "Run";
            runStateValue = runState.Ready;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Reader rdr = new Reader();

            string filename = scannedPdfFileNameTextBox.Text;
            string outputFolder = folderSaveTextBox.Text;
            string filenamePrefix = imageFilenamePrefixInput.Text;
            bool barcodeLeadingZeros = includeLeadingZerosCheckbox.Checked;
            string filenameOut;
            string barcode;
            Rectangle rec = new Rectangle(0, 0, 1000, 200);

            worker.ReportProgress(0, new Tuple<string, int>("progressBarValue", 0));

            try
            {
                int numberOfPages = rdr.numberOfPagesInPdf(rdr.openPDFFile(filename));
                worker.ReportProgress(0, new Tuple<string, int>("progressBarMaximum", numberOfPages));

                using (FileStream pdfFile = (FileStream)rdr.openPDFFile(filename))
                {
                    for (int i = 0; i < numberOfPages; i++)
                    {
                        pdfFile.Position = 0;

                        worker.ReportProgress(0, new Tuple<string, string>("statusLabelText", String.Format("Processing sheet {0} of {1}", i + 1, numberOfPages)));
                        worker.ReportProgress(0, new Tuple<string, int>("progressBarValue", i + 1));

                        Bitmap page = rdr.getImageFromPdfPage(pdfFile, i);
                        filenameOut = String.Format(@"{0}\{1}.jpg", outputFolder, i.ToString());

                        if (page.Height > 350 && page.Width > 1200)
                        {
                            rec.Height = 350;
                            rec.Width = page.Width - 1200;
                            rec.Location = new Point(1200, 0);
                            barcode = rdr.readBarcode(rdr.cropImage(page, rec));
                            //rdr.saveJpg(rdr.cropImage(page, rec), @"c:\scoresheets\cropped.jpg");
                        }
                        else
                        {
                            barcode = rdr.readBarcode(page);
                        }

                        if (barcode == "")
                        {
                            if (!Directory.Exists(String.Format(@"{0}\Errors", outputFolder)))
                            {
                                Directory.CreateDirectory(String.Format(@"{0}\Errors", outputFolder));
                            }
                            filenameOut = String.Format(@"{0}\Errors\{1}.jpg", outputFolder, i.ToString());
                            logger.Trace("Error reading barcode for page {0}", i);
                        }
                        else
                        {
                            if (barcodeLeadingZeros)
                            {
                                filenameOut = String.Format(@"{0}\{1}{2}.jpg", outputFolder, filenamePrefix, barcode);
                            }
                            else
                            {
                                filenameOut = String.Format(@"{0}\{1}{2}.jpg", outputFolder, filenamePrefix, barcode.TrimStart('0'));
                            }
                        }
                        rdr.saveJpg(page, filenameOut);
                        logger.Trace("Saved file to {0}", filenameOut);
                        page.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
                backgroundWorkerError = true;
                //Debug.Print(ex.Message);
            }

        }

        private void openScannedScoresheetButton_Click(object sender, EventArgs e)
        {
            string folderName = "";
            try
            {
                folderName = Path.GetDirectoryName(scannedPdfFileNameTextBox.Text);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
            }

            if (Directory.Exists(folderName))
            {
                inputFileOpenFileDialog.InitialDirectory = folderName;
            }
            inputFileOpenFileDialog.ShowDialog();
            scannedPdfFileNameTextBox.Text = inputFileOpenFileDialog.FileName;
        }

        private void processScoresheetsButton_Click(object sender, EventArgs e)
        {
            switch (runStateValue)
            {
                case runState.Ready:
                    processScoresheetsButton.Text = "Stop";
                    runStateValue = runState.Running;
                    backgroundWorker1.RunWorkerAsync();
                    break;
                case runState.Running:
                    processScoresheetsButton.Enabled = false;
                    processScoresheetsButton.Text = "Stopping";
                    backgroundWorker1.CancelAsync();
                    break;
                default:
                    break;
            }
        }

        private void saveScoresheetFolderButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(folderSaveTextBox.Text))
            {
                scoresheetSplitOutputFolderBrowserDialog.SelectedPath = folderSaveTextBox.Text;
            }
            scoresheetSplitOutputFolderBrowserDialog.ShowDialog();
            folderSaveTextBox.Text = scoresheetSplitOutputFolderBrowserDialog.SelectedPath;
        }


        private void reportDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void customScoresheetButton_Click(object sender, EventArgs e)
        {
            customScoresheetOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult dr = customScoresheetOpenFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                reportPath = customScoresheetOpenFileDialog.FileName;
                customScoresheetLabel.Visible = true;
            }
        }

        private void saveScoresheetLocationButton_Click(object sender, EventArgs e)
        {
            saveGeneratedScoresheetsFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveGeneratedScoresheetsFileDialog.ShowDialog();
            scoresheetFileNameInput.Text = saveGeneratedScoresheetsFileDialog.FileName;
        }

        private void saveScoresheetReport_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Generating scoresheets...";
            Reader rdr = new Reader();

            string scoreType = "";

            if (ssBJCP.Checked) { scoreType = "BJCP"; };
            if (ssAABC.Checked) { scoreType = "AABC"; };

            string imageFileName;
            Uri imageFileNameUri;

            if (File.Exists(customLogoFilenameInput.Text))
            {
                imageFileName = customLogoFilenameInput.Text;
            }
            else
            {
                imageFileName = AppDomain.CurrentDomain.BaseDirectory;
                if (scoreType == "BJCP")
                {
                    imageFileName += @"GenericLogoSquare.png";
                }
                else if (scoreType == "AABC")
                {
                    imageFileName += @"GenericLogoRectangle.png";
                }
            }

            imageFileNameUri = new Uri(imageFileName);

            if (reportPath == "")
            {
                reportPath = AppDomain.CurrentDomain.BaseDirectory;
                reportPath += @"GenericScoresheet.rdlc";
            }
            try
            {
                rdr.savePdfScoresheet((int)numberOfScoresheetsInput.Value, reportPath, imageFileNameUri.AbsoluteUri, scoreType, competitionName.Text, scoresheetFileNameInput.Text);
                toolStripStatusLabel1.Text = string.Format("Scoresheets saved to {0}", scoresheetFileNameInput.Text);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error(ex.InnerException);
                logger.Error(ex.StackTrace);
                toolStripStatusLabel1.Text = "Error occurred...";
            }
        }

        private void customLogoFilenameBrowse_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Path.GetDirectoryName(customLogoFilenameInput.Text)))
            {
                customLogoFilenameOpenFileDialog.InitialDirectory = Path.GetDirectoryName(customLogoFilenameInput.Text);
            }
            else
            {
                customLogoFilenameOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            DialogResult dr = customLogoFilenameOpenFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                customLogoFilenameInput.Text = customLogoFilenameOpenFileDialog.FileName;
            }
        }
    }
}
