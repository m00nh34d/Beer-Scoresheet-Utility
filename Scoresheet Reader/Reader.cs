using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Barcode;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using ImageMagick;
using System.Diagnostics;


namespace Scoresheet_Reader
{
    class Reader
    {
        public void extractImages(string filename)
        {

            int i = 1;
            string filenameOut;
            string filenameOutCropped;
            string barcode;
            Rectangle rec = new Rectangle(0, 0, 1000, 200);
            foreach(string imgPath in getImagesFromPDF(openPDFFile(filename)))
            {
                Bitmap img = new Bitmap(imgPath);
                filenameOut = String.Format(@"C:\Temp\{0}.jpg", i.ToString());
                filenameOutCropped = String.Format(@"C:\Temp\{0}-Cropped.jpg", i.ToString());
                try
                {
                    rec.Height = 300;
                    rec.Width = img.Width;
                    barcode = readBarcode(cropImage(img, rec));
                    Debug.Print(barcode);
                    if(barcode == "")
                    {
                        filenameOut = String.Format(@"C:\Scoresheets\Errors\{0}.jpg", i.ToString());
                    }
                    else
                    {
                        filenameOut = String.Format(@"C:\Scoresheets\{0}.jpg", barcode);
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }
                saveJpg(img, filenameOut);
                saveJpg(cropImage(img, rec), filenameOutCropped);
                i++;
            }
        }

        public Stream openPDFFile(string fileName)
        {
            Stream str = File.OpenRead(fileName);
            return str;
        }

        public string readBarcode(Bitmap img)
        {
            
            string[] rawBarcode = BarcodeScanner.Scan(img);
            string barcode = String.Join("", rawBarcode);
            return barcode;
        }

        public Bitmap cropImage(Image img, Rectangle rec)
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
            ///TODO file paths need to be fixed
            ///TODO Read TIFs as well as PDFs
            ///

            List<string> outputImagePaths = new List<string>();
            string filenameTemp;

            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(300, 300);

            using (MagickImageCollection images = new MagickImageCollection())
            {
                images.Read(pdfStream, settings);

                int page = 1;
                foreach (MagickImage image in images)
                {
                    image.Format = MagickFormat.Ptif;
                    filenameTemp = String.Format(@"C:\Scoresheets\Temp\{0}.bmp", page.ToString());
                    image.ToBitmap().Save(filenameTemp);
                    outputImagePaths.Add(filenameTemp);
                    page++;
                }

            }
            return outputImagePaths;
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
