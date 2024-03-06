using Microsoft.Extensions.Logging;

namespace NameSorter.Sorting
{
    public class MergeSortStrategy : ISortStrategy
    {
        private readonly ILogger<MergeSortStrategy> _logger;

        public MergeSortStrategy(ILogger<MergeSortStrategy> logger)
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

            _logger.LogInformation("Starting Merge Sort...");

            if (unsortedNames.Count <= 1)
            {
                _logger.LogInformation("List is already sorted or empty.");
                return unsortedNames;
            }

            _logger.LogInformation($"Sorting {unsortedNames.Count} names.");

            List<string> sortedNames = MergeSort(unsortedNames);

            _logger.LogInformation("Merge Sort completed.");

            return sortedNames;
        }

        private List<string> MergeSort(List<string> names)
        {
            if (names.Count <= 1)
                return names;

            int middle = names.Count / 2;
            List<string> left = new List<string>();
            List<string> right = new List<string>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(names[i]);
            }

            for (int i = middle; i < names.Count; i++)
            {
                right.Add(names[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private List<string> Merge(List<string> left, List<string> right)
        {
            List<string> result = new List<string>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (string.Compare(left[leftIndex], right[rightIndex], StringComparison.OrdinalIgnoreCase) <= 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }
    }
}
