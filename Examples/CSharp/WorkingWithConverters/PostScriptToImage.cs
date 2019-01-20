using Aspose.EPS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithConverters
{
    class PostScriptToImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithConverters();
            // Initialize PDF output stream
            System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Png;
            // Initialize PostScript input stream
            System.IO.FileStream psStream = new System.IO.FileStream(dataDir + "inputForImage.ps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            // If you want to convert Postscript file despite of minor errors set this flag
            bool suppressErrors = true;
            // Initialize options object with necessary parameters. Default image format is PNG and it is not required to set it in Ps2ApsConverterOptions.
            Ps2ApsConverterOptions options = new Ps2ApsConverterOptions(psStream, suppressErrors);
            // If you want to obtain images in another format, uncomment following lines
            //imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            //options = new Ps2ApsConverterOptions(psStream, suppressErrors, imageFormat);
            // Set page size. This size will be also the size of resulting images.
            options.PageSize = new System.Drawing.Size(595, 842);
            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            //options.FontsFolders = new string[] { @"{FONT_FOLDER}" };
            Ps2ApsConverter converter = new Ps2ApsConverter();
            try
            {
                // Because PS file can contain several pages for every page an image bytes array will be obtained. //The number of bytes arrays equals to the numberof pages in input PS file.
                byte[][] imagesBytes = converter.ConvertToImages(options);
                int i = 0;
                foreach (byte[] imageBytes in imagesBytes)
                {
                    string imagePath = Path.GetFullPath("image" + i.ToString() + "_out." + imageFormat.ToString().ToLower());
                    using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(imageBytes, 0, imageBytes.Length);
                    }
                    i++;
                }
            }
            finally
            {
                psStream.Close();
            }
            // Review errors
            if (suppressErrors)
            {
                foreach (PsConverterException ex in options.Exceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // ExEnd:1
        }
    }
}
