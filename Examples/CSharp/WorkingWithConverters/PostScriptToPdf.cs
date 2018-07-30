using Aspose.EPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithConverters
{
    public class PostScriptToPdf
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithConverters();
            // Initialize PDF output stream
            System.IO.FileStream pdfStream = new System.IO.FileStream(dataDir + "outputPDF_out.pdf", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            // Initialize PostScript input stream
            System.IO.FileStream psStream = new System.IO.FileStream(dataDir + "input.ps", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            // If you want to convert Postscript file despite of minor errors set this flag
            bool suppressErrors = true;
            Ps2PdfConverterOptions options = new Ps2PdfConverterOptions(psStream, pdfStream, suppressErrors);
            // Set page size
            options.PageSize = new System.Drawing.Size(595, 842);
            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            options.FontsFolders = new string[] { @"{FONT_FOLDER}" };
            try
            {
                Ps2PdfConverter converter = new Ps2PdfConverter();
                converter.ConvertToPdf(options);
            }
            finally
            {
                psStream.Close();
                pdfStream.Close();
            }
            // Review errors
            if (suppressErrors)
            {
                foreach (Ps2PdfConverterException ex in options.Exceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // ExEnd:1
        }
    }
}
