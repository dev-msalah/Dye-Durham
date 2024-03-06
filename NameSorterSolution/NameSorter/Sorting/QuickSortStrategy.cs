using Microsoft.Extensions.Logging;

namespace NameSorter.Sorting
{
    public class QuickSortStrategy : ISortStrategy
    {
        private readonly ILogger<QuickSortStrategy> _logger;

        public QuickSortStrategy(ILogger<QuickSortStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<string> SortNames(List<string> unsortedNames)
        {
            if (unsortedNames == null || !unsortedNames.Any())
            {
                _logger.LogError("Names cannot be null or empty.");
                throw new ArgumentException("Names cannot be null or empty.", nameof(unsortedNames));
            }

            _logger.LogInformation("Starting Quick Sort...");

            if (unsortedNames.Count <= 1)
            {
                _logger.LogInformation("List is already sorted or empty.");
                return unsortedNames;
            }

            _logger.LogInformation($"Sorting {unsortedNames.Count} names.");

            QuickSort(unsortedNames, 0, unsortedNames.Count - 1);

            _logger.LogInformation("Quick Sort completed.");

            return unsortedNames;
        }

        private void QuickSort(List<string> names, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(names, low, high);
                QuickSort(names, low, partitionIndex - 1);
                QuickSort(names, partitionIndex + 1, high);
            }
        }

        private int Partition(List<string> names, int low, int high)
        {
            string pivot = names[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (names[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(names, i, j);
                }
            }

            Swap(names, i + 1, high);
            return i + 1;
        }

        private void Swap(List<string> names, int i, int j)
        {
            string temp = names[i];
            names[i] = names[j];
            names[j] = temp;
        }
    }
}
