using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.GettingStarted
{
    public class LoadLicenseFromStreamObject
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_GettingStarted();
            // Initialize license object
            Aspose.EPS.License license = new Aspose.EPS.License();
            // Load license in FileStream
            FileStream myStream = new FileStream("Aspose.EPS.lic", FileMode.Open);
            // Set license
            license.SetLicense(myStream);
            Console.WriteLine("License set successfully.");
            // ExEnd:1
        }
    }
}
