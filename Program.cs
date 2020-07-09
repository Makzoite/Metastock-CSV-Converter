using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleAppCSVConvert
{
    class Program
    {
        public static void Main()

        {
            string root = @"C:\cygwin64\atem\MyFiles";

            string[] directories = Directory.GetDirectories(root);
            foreach (string directory in directories)
            {
                string command = "C:/cygwin64/atem/atem64.exe \"C:/cygwin64/atem/MyFiles/" + Path.GetFileName(directory) + "\" -F \",\" -o \"C:/cygwin64/atem/MyFiles/" + Path.GetFileName(directory) + "/" + Path.GetFileName(directory) + ".csv\"";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                // wrap IDisposable into using (in order to release hProcess) 
                using (Process process = new Process())
                {
                    process.StartInfo = procStartInfo;
                    process.Start();

                    // Add this: wait until process does its work
                    process.WaitForExit();
                }
            }
        }
    }
}
