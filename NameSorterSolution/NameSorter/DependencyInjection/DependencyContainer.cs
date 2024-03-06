using Microsoft.Extensions.DependencyInjection;
using NameSorter.Interfaces;
using NameSorter.Services;
using NameSorter.Sorting;
using Microsoft.Extensions.Logging;

namespace NameSorter.DependencyInjection
{
    public static class DependencyContainer
    {
        public static ServiceProvider Configure()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure =>
                {
                    configure.SetMinimumLevel(LogLevel.Debug); 
                    configure.AddConsole();
                })
                .AddSingleton<IFileReader, FileReader>()
                .AddSingleton<IFileWriter, FileWriter>()
                //.AddSingleton<ISortStrategy, MergeSortStrategy>()
                .AddSingleton<ISortStrategy, QuickSortStrategy>()
                .AddSingleton<INameSorterService, NameSorterService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
