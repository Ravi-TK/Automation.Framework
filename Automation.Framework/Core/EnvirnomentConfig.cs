namespace Automation.Framework.Core
{
    public class EnvirnomentConfig
    {
        private static Envirnoment _testEnvirnoment;

        /// <summary>
        /// Set Envirnoment 
        /// </summary>
        /// <param name="testEnviro">Envirnoment to test in</param>
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
        }
    }

    /// <summary>
    /// Envirnoment Type
    /// </summary>
    public enum Envirnoment
    {
        Dev,
        SysTest,
        UAT,
        Staging,
        Live
    }
}