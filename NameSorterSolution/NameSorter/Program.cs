using Microsoft.Extensions.DependencyInjection;
using NameSorter.DependencyInjection;
using NameSorter.Interfaces;
using NameSorter.Services;
using NameSorter.Sorting;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyContainer.Configure();

            if (args.Length != 1)
            {
                Console.WriteLine("Usage: NameSorter <input-file>");
                return;
            }

            string inputFile = args[0];
            string outputFile = "sorted-names-list.txt";

            var service = serviceProvider.GetService<INameSorterService>();
            var sortedNames = service.SortNamesFromFile(inputFile, outputFile);

            if (sortedNames != null && sortedNames.Any())
            {
                Console.WriteLine("Sorted Names:\n");
                foreach (var name in sortedNames)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
