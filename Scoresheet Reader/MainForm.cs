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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Scoresheet_Reader
{
    public partial class MainForm : Form
    {

        enum runState { Running, Ready }
        runState runStateValue = new runState();
        string reportPath = "";

        public MainForm()
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            runStateValue = runState.Ready;

            ///TODO External file for report data sources/parameters
            scoresheetReportsBindingSource.Add(new scoresheetReports("Merri Mashers Scoreshet", "MM", 1));
            scoresheetReportsBindingSource.Add(new scoresheetReports("Generic Scoreshet", "GEN", 1));
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
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
            int i = 1;
            string filenameOut;
            //string filenameOutCropped;
            string barcode;
            Rectangle rec = new Rectangle(0, 0, 1000, 200);

            worker.ReportProgress(0, new Tuple<string, int>("progressBarValue", 0));
            worker.ReportProgress(0, new Tuple<string, string>("statusLabelText", "Extracting images from input file. Please Wait..."));

            List<string> imgPaths = rdr.getImagesFromPDF(rdr.openPDFFile(filename));

            worker.ReportProgress(0, new Tuple<string, int>("progressBarMaximum", imgPaths.Count));

            foreach (string imgPath in imgPaths)
            {
                if (!worker.CancellationPending)
                {
                    worker.ReportProgress(0, new Tuple<string, string>("statusLabelText", String.Format("Processing sheet {0} of {1}", i.ToString(), imgPaths.Count.ToString())));
                    worker.ReportProgress(0, new Tuple<string, int>("progressBarValue", i));
                    Bitmap img = new Bitmap(imgPath);
                    filenameOut = String.Format(@"{0}\{1}.jpg", outputFolder, i.ToString());
                    //filenameOutCropped = String.Format(@"{0}\{0}-Cropped.jpg", outputFolder, i.ToString());
                    try
                    {
                        rec.Height = 300;
                        rec.Width = img.Width;
                        barcode = rdr.readBarcode(rdr.cropImage(img, rec));
                        //Debug.Print(barcode);
                        if (barcode == "")
                        {
                            filenameOut = String.Format(@"{0}\Errors\{1}.jpg", outputFolder, i.ToString());
                        }
                        else
                        {
                            filenameOut = String.Format(@"{0}\{1}.jpg", outputFolder, barcode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    rdr.saveJpg(img, filenameOut);
                    //rdr.saveJpg(rdr.cropImage(img, rec), filenameOutCropped);
                    i++;
                }
                else
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void openScannedScoresheetButton_Click(object sender, EventArgs e)
        {
            string folderName = "";
            try
            {
                folderName = Path.GetDirectoryName(scannedPdfFileNameTextBox.Text);
            }
            catch { }

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

        public ArrayList barcodeDataset(int numberOfBarcodes)
        {
            ArrayList barcodes = new ArrayList(); 

            ///TODO Customer start and end ranges for barcodes
            for (int i = 1; i <= numberOfBarcodes; i++)
            {
                ///TODO Custom formatting for barcodes
                reportData rd = new reportData();
                rd.barcode = String.Format("{0:00000}", i);
                barcodes.Add(rd);
            }

            return barcodes;
        }

        private ParameterField newParameterField(string name, string value)
        {
            ParameterField crParameterField = new ParameterField();
            ParameterDiscreteValue crParameterDescreteValue = new ParameterDiscreteValue();
            crParameterDescreteValue.Value = value;
            crParameterField.Name = name;
            crParameterField.CurrentValues.Add(crParameterDescreteValue);

            return crParameterField;
        }

        private ParameterDiscreteValue newParameterDescreteValue(string value)
        {
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = value;
            return pdv;
        }

        private ParameterDiscreteValue newParameterDescreteValue(Int32 value)
        {
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = value;
            return pdv;
        }

        private ParameterValues newParameterValues(ParameterValue value)
        {
            ParameterValues pv = new ParameterValues();
            pv.Add(value);
            return pv;
        }

        private void saveScoresheetsButton_Click(object sender, EventArgs e)
        {
            ReportDocument scoresheetReport;
            string scoresheetSaveFileName = @"";
            string scoresheetReportFile = @"";
            int numberOfScoresheets = 0;
            string scoreType = "";

            if (ssBJCP.Checked) { scoreType = "BJCP"; };
            if (ssAABC.Checked) { scoreType = "AABC"; };

            if(reportPath == "")
            {
                reportPath = AppDomain.CurrentDomain.BaseDirectory;
                reportPath += @"\GenericScoresheet.rpt";
            }

            scoresheetReportFile = reportPath;
            scoresheetSaveFileName = scoresheetFileNameInput.Text;

            Debug.Print(scoresheetReportFile);

            if (Directory.Exists(Path.GetDirectoryName(scoresheetSaveFileName)) && File.Exists(scoresheetReportFile))
            {
                try
                {
                    toolStripStatusLabel1.Text = "Generating scoresheets...";

                    numberOfScoresheets = (int)numberOfScoresheetsInput.Value;

                    scoresheetReport = new ReportDocument();
                    scoresheetReport.Load(scoresheetReportFile);
                    scoresheetReport.SetDataSource(barcodeDataset(numberOfScoresheets));

                    DiskFileDestinationOptions crDiskFileOptions = new DiskFileDestinationOptions();
                    crDiskFileOptions.DiskFileName = scoresheetSaveFileName;

                    ExportOptions crExportOptions = new ExportOptions();
                    crExportOptions.ExportDestinationOptions = crDiskFileOptions;
                    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                    scoresheetReport.DataDefinition.ParameterFields["competitonName"].ApplyCurrentValues(newParameterValues(newParameterDescreteValue(competitionName.Text)));
                    scoresheetReport.DataDefinition.ParameterFields["ScoreType"].ApplyCurrentValues(newParameterValues(newParameterDescreteValue(scoreType)));
                    scoresheetReport.DataDefinition.ParameterFields["logoType"].ApplyCurrentValues(newParameterValues(newParameterDescreteValue(scoresheetComboBox.SelectedValue.ToString())));

                    scoresheetReport.Export(crExportOptions);

                    toolStripStatusLabel1.Text = string.Format("Scoresheets saved to {0}", scoresheetSaveFileName);
                }
                catch (Exception ex)
                {
                    ///TODO Error logging and exception output
                    toolStripStatusLabel1.Text = "Error occurred...";
                }

            }
            else
            {
                if (!Directory.Exists(Path.GetDirectoryName(scoresheetSaveFileName)))
                {
                    toolStripStatusLabel1.Text = "Error with save location";
                }
                else
                {
                    toolStripStatusLabel1.Text = "Error reading report...";
                }

            }
        }

        private void reportDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void customScoresheetButton_Click(object sender, EventArgs e)
        {
            customScoresheetOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            customScoresheetOpenFileDialog.ShowDialog();
            reportPath = customScoresheetOpenFileDialog.FileName;
        }

        private void saveScoresheetLocationButton_Click(object sender, EventArgs e)
        {
            saveGeneratedScoresheetsFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveGeneratedScoresheetsFileDialog.ShowDialog();
            scoresheetFileNameInput.Text = saveGeneratedScoresheetsFileDialog.FileName;
        }
    }
}
