using Automation.Framework.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Example.BackEnd
{
    public class DBConnectionStrings
    {

        public static string DBConnectionStr = "";

        internal static void SetDBConnectionString(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("AppConfig.json")
                   .Build();

                if (testEnvironment == Envirnoment.SysTest) DBConnectionStr = config["SysTestDB"];
                else if (testEnvironment == Envirnoment.Dev) DBConnectionStr = config["DevDB"];
                else if (testEnvironment == Envirnoment.UAT) DBConnectionStr = config["UATDB"];
                else if (testEnvironment == Envirnoment.Staging) DBConnectionStr = config["StagingDB"];
        }
    }
}

