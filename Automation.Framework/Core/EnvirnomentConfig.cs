using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Framework.Core
{
    public class EnvirnomentConfig
    {
        private static Envirnoment _testEnvirnoment;

        public static void setTestEnvirnoment(Envirnoment testEnviro)
        {
            _testEnvirnoment = testEnviro;
        }

        public static Envirnoment TestEnvirnoment
        {
            get
            {
                return _testEnvirnoment;
            }
            //set
            //{
            //    _testEnvirnoment = value;
            //}
        }

    }

    public enum Envirnoment
    {
        Dev,
        SysTest,
        UAT,
        Staging,
        Live
    }
}
