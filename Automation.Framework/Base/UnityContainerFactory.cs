using Unity;

namespace Automation.Framework.Base
{
    public static class UnityContainerFactory
    {
        private static IUnityContainer _unityContainer;

        static UnityContainerFactory()
        {
            _unityContainer = new UnityContainer();
        }

        /// <summary>
        /// Retrieves existing unity container 
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer GetContainer()
        {
            return _unityContainer;
        }
    }
}