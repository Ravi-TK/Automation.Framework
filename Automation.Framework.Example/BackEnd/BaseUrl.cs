using Automation.Framework.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Example.BackEnd
{
    public class BaseUrl
    {
        public static string Url = "";

        internal static void SetBaseUrl(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            var config = new ConfigurationBuilder()
                             .AddJsonFile("AppConfig.json")
                             .Build();

            if (testEnvironment == Envirnoment.SysTest)
            {
                Url = config["SysTest"];
            }
            else if (testEnvironment == Envirnoment.Dev)
            {
                Url = config["Dev"];
            }
            else if (testEnvironment == Envirnoment.UAT)
            {
                Url = config["UAT"];
            }
            else if (testEnvironment == Envirnoment.Staging)
            {
                Url = config["Staging"];
            }
        }
    }
}
