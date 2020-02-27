using Automation.Framework.ComponentHelper.Interfaces;
using System.Diagnostics;
using System.IO;

namespace Automation.Framework.ComponentHelper
{
    public class Window : IWindowHelper
    {
        /// <summary>
        /// Interacts with windows form to select file from windows explorer
        /// </summary>
        /// <param name="fileLocation"> Location of file to be uploaded</param>
        /// <param name="windowTitle">Title of windows dialog, by default set to "Open" </param>
        public void FileUploader(string fileLocation, string windowTitle = "Open")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = Directory.GetCurrentDirectory() + "\\FileUploadScript.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = windowTitle + " " + fileLocation;

            // Call WaitForExit and then the using statement will close.
            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }
        }
    }
}