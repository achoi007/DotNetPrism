using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Utils
{
    public static class ServiceUtils
    {
        /// <summary>
        /// Convenience function to convert an IServiceLocator to an IUnityContainer.  Return null
        /// if conversion cannot be done.
        /// </summary>
        /// <param name="sl"></param>
        /// <returns></returns>
        public static IUnityContainer GetUnity(this IServiceLocator sl)
        {
            if (sl is MyUnityServiceLocatorAdapter)
            {
                return ((MyUnityServiceLocatorAdapter)sl).Container;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Add support for IServiceLocator.RegisterType.  Throw exception if operation cannot be done.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="sl"></param>
        public static void RegisterType<T1, T2>(this IServiceLocator sl) where T2: T1
        {
            var uc = sl.GetUnity();
            if (uc == null)
            {
                UnknownServiceLocatorError();
            }
            uc.RegisterType<T1, T2>();
        }

        /// <summary>
        /// Add support for IServiceLocator.RegisterInstance.  Throw exception if operation cannot be done.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="sl"></param>
        /// <param name="name"></param>
        /// <param name="inst"></param>
        public static void RegisterInstance<T1, T2>(this IServiceLocator sl, string name, T2 inst) where T2: T1
        {
            var uc = sl.GetUnity();
            if (uc == null)
            {
                UnknownServiceLocatorError();
            }
            uc.RegisterInstance<T1>(name, inst);
        }

        private static void UnknownServiceLocatorError()
        {
            throw new ArgumentException("ServiceLocator.RegisterXXX cannot be done because of unknown service locator type.");
        }
    }
}
