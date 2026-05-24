using System.Windows;
using FundamentalLib.Core;
using Fundamental.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Fundamental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Регистрируем PlayerState как Singleton — один экземпляр на всё приложение
            containerRegistry.RegisterSingleton<PlayerState>();
        }
    }

}
