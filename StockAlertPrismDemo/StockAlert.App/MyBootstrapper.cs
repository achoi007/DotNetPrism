using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using StockAlert.Infra.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockAlert.App
{
    class MyBootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return new ShellWindow();
        }

        protected override Microsoft.Practices.Prism.Logging.ILoggerFacade CreateLogger()
        {
            var tw = new StreamWriter(File.OpenWrite("./app.log"));
            return new TextLogger(tw);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // register unity container as IServiceLocator
            UnityContainer uc = (UnityContainer)Container;
            uc.RegisterInstance<IServiceLocator>(new MyUnityServiceLocatorAdapter(uc));
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
