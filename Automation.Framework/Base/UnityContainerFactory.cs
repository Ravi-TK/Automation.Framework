using System;
using System.Collections.Generic;
using System.Text;
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

        public static IUnityContainer GetContainer()
        {
            return _unityContainer;
        }
    }
}
