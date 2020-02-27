using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.ComponentHelper.Interfaces
{
    interface IWindowHelper
    {
        void FileUploader(string fileLocation, string windowTitle = "Open");
    }
}
