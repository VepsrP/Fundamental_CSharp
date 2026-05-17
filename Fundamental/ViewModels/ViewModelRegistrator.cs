using Microsoft.Extensions.DependencyInjection;

namespace Fundamental.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViews(this IServiceCollection Services) => Services
           .AddSingleton<MainWindowViewModel>()
        ;
    }
}
