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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using ImageMagick;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using Microsoft.Reporting.WinForms;

namespace Scoresheet_Reader
{
    class Reader
    {

        public Stream openPDFFile(string fileName)
        {
            Stream str = File.OpenRead(fileName);
            return str;
        }

        public string readBarcode(Bitmap img)
        {
            List<BarcodeFormat> possibleFormats = new List<BarcodeFormat>();
            possibleFormats.Add(BarcodeFormat.CODE_39);
            IBarcodeReader reader = new BarcodeReader();
            reader.Options.PossibleFormats = possibleFormats;
            Result result = reader.Decode(img);
            //string[] rawBarcode = BarcodeScanner.Scan(img);
            //string barcode = String.Join("", rawBarcode);
            string barcode;
            if (result != null)
            {
                barcode = result.Text;
            }
            else
            {
                reader.Options.TryHarder = true;
                Result result2 = reader.Decode(img);
                barcode = result2.Text;
            }
            return barcode;
        }

        public Bitmap cropImage(System.Drawing.Image img, System.Drawing.Rectangle rec)
        {
            Bitmap bmpImg = new Bitmap(img);
            return bmpImg.Clone(rec, bmpImg.PixelFormat);
        }

        public Bitmap resizeImage(Bitmap img, int height, int width)
        {
            Bitmap bmpImg = new Bitmap(img);
            return bmpImg;
        }

        public void saveJpg(Bitmap img, string filename)
        {
            using (MagickImage mImg = new MagickImage())
            {
                mImg.Read(img);
                mImg.Format = MagickFormat.Jpg;
                mImg.Quality = 8;
                mImg.Write(filename);
            }
        }

        public List<string> getImagesFromPDF(Stream pdfStream)
        {
            ///TODO Read TIFs as well as PDFs
            ///

            List<string> outputImagePaths = new List<string>();
            string filenameTemp;

            MagickNET.SetGhostscriptDirectory(AppDomain.CurrentDomain.BaseDirectory);
            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(300, 300);

            using (MagickImageCollection images = new MagickImageCollection())
            {
                images.Read(pdfStream, settings);

                int page = 1;
                foreach (MagickImage image in images)
                {
                    image.Format = MagickFormat.Ptif;
                    //filenameTemp = String.Format(@"C:\Scoresheets\Temp\{0}.bmp", page.ToString());
                    filenameTemp = Path.GetTempFileName();
                    image.ToBitmap().Save(filenameTemp);
                    outputImagePaths.Add(filenameTemp);
                    page++;
                }

            }
            return outputImagePaths;
        }

        public Bitmap getImageFromPdfPage(Stream pdfStream, int pageNumber)
        {
            Bitmap returnBmp = new Bitmap(1,1);

            using (MagickImageCollection images = new MagickImageCollection())
            {
                MagickReadSettings settings = new MagickReadSettings();
                settings.Density = new Density(300, 300);
                settings.FrameCount = 1;
                settings.FrameIndex = pageNumber;
                images.Read(pdfStream, settings);
                foreach(MagickImage image in images)
                {
                    returnBmp = image.ToBitmap();
                }
            }

            return returnBmp;
        }

        public int numberOfPagesInPdf(string pdfFile)
        {
            int pages = 0;
            PdfReader reader = new PdfReader(pdfFile);
            pages = reader.NumberOfPages;
            reader.Close();
            reader.Dispose();
            return pages;
        }

        public int numberOfPagesInPdf(Stream pdfStream)
        {
            int pages = 0;
            PdfReader reader = new PdfReader(pdfStream);
            pages = reader.NumberOfPages;
            reader.Close();
            reader.Dispose();
            return pages;
        }

        public ArrayList barcodeDataset(int numberOfBarcodes)
        {
            ArrayList barcodes = new ArrayList();

            ///TODO Customer start and end ranges for barcodes
            for (int i = 1; i <= numberOfBarcodes; i++)
            {
                ///TODO Custom formatting for barcodes
                reportData rd = new reportData();
                rd.barcode = String.Format("*{0:00000}*", i);
                barcodes.Add(rd);
            }

            return barcodes;
        }

        public void savePdfScoresheet(int numberOfSheets, string reportPath, string logoType, string scoreType, string competitionTitle, string saveFileName)
        {

            if (!Directory.Exists(Path.GetDirectoryName(saveFileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(saveFileName));
            }

            if (File.Exists(saveFileName))
            {
                File.Delete(saveFileName);
            }

            LocalReport lr = new LocalReport();
            Warning[] warnings;
            string[] streamids;
            string mimeType = String.Empty;
            string encoding = String.Empty;
            string filenameExtension = String.Empty;

            lr.ReportPath = reportPath;
            lr.EnableExternalImages = true;
            lr.DataSources.Add(new ReportDataSource("Barcodes", barcodeDataset(numberOfSheets)));
            lr.SetParameters(new ReportParameter("LogoType", logoType));
            lr.SetParameters(new ReportParameter("ScoreType", scoreType));
            lr.SetParameters(new ReportParameter("CompetitionTitle", competitionTitle));

            byte[] bytes = lr.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            using (FileStream fs = new FileStream(saveFileName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

    }

    class reportData
    {
        public string barcode { get; set; }
    }

    class scoresheetReports
    {
        public string name { get; set; }
        public string filePath { get; set; }
        public int id { get; set; }

        public scoresheetReports ()
        {
            name = "";
            filePath = "";
            id = 0;
        }

        public scoresheetReports (string name, string filePath, int id)
        {
            this.name = name;
            this.filePath = filePath;
            this.id = id;
        }
    }
}
