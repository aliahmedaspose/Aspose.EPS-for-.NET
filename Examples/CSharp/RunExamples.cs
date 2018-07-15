using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CSharp.GettingStarted;
using CSharp.WorkingWithConverters;

namespace CSharp
{
    class RunExamples
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");
            // Uncomment the one you want to try out

            // =====================================================
            // =====================================================
            // Getting Started
            // =====================================================
            // =====================================================
            LoadLicenseFromFile.Run();
            // LoadLicenseFromStreamObject.Run();
            // SetLicenseUsingEmbeddedResource.Run();
            // SecureLicense.Run();

            // =====================================================
            // =====================================================
            // WorkingWithConverters
            // =====================================================
            // =====================================================
            PostScriptToPdf.Run();

            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }

        public static String GetDataDir_GettingStarted()
        {
            return Path.GetFullPath(GetDataDir_Data() + "GettingStarted/");
        }

        public static String GetDataDir_WorkingWithConverters()
        {
            return Path.GetFullPath(GetDataDir_Data() + "WorkingWithConverters/");
        }

        public static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return Path.Combine(startDirectory, "Data\\");
        }
    }
}
