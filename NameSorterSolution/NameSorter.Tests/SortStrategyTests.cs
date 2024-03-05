using Microsoft.Extensions.Logging;
using Moq;

namespace NameSorter.Sorting.Tests
{
    public class MergeSortStrategyTests
    {
        [Fact]
        public void SortNames_ListIsAlreadySorted_ReturnsSameList()
        {
            var loggerMock = new Mock<ILogger<MergeSortStrategy>>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);
            var sortedNames = new List<string> { "Carson Case", "Dolores Jongejans", "Phyliss Sol Noreen", "Waldo Baerents Tegan" };

            var result = mergeSortStrategy.SortNames(sortedNames);

            Assert.Equal(sortedNames, result);
        }

        [Fact]
        public void SortNames_ListIsEmpty_ReturnsEmptyList()
        {
            var loggerMock = new Mock<ILogger<MergeSortStrategy>>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);
            var emptyList = new List<string>();

            var result = mergeSortStrategy.SortNames(emptyList);

            Assert.Empty(result);
        }

        [Fact]
        public void SortNames_ListIsUnsorted_ReturnsSortedNames()
        {
            var loggerMock = new Mock<ILogger<MergeSortStrategy>>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);
            var unsortedNames = new List<string> { "Waldo Baerents Tegan", "Dolores Jongejans", "Carson Case", "Phyliss Sol Noreen" };
            var expectedSortedNames = new List<string> { "Carson Case", "Dolores Jongejans", "Phyliss Sol Noreen", "Waldo Baerents Tegan" };

            var result = mergeSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, result);
        }

        [Fact]
        public void MergeSort_ListWithSingleElement_ReturnsSameList()
        {
            var loggerMock = new Mock<ILogger<MergeSortStrategy>>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);
            var singleElementList = new List<string> { "Dolores" };

            var result = mergeSortStrategy.SortNames(singleElementList);

            Assert.Single(result);
            Assert.Equal("Dolores", result[0]);
        }

        [Fact]
        public void SortNames_ListWithDuplicateNames_ReturnsSortedNamesWithDuplicates()
        {
            var unsortedNames = new List<string> { "John", "Alice", "Bob", "Carol", "John", "Bob" };
            var expectedSortedNames = new List<string> { "Alice", "Bob", "Bob", "Carol", "John", "John" };
            var loggerMock = new Mock<ILogger<MergeSortStrategy>>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);

            var sortedNames = mergeSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, sortedNames);
        }

        [Fact]
        public void SortNames_ListWithSpecialCharacters_ReturnsSortedNamesWithSpecialCharacters()
        {
            var unsortedNames = new List<string> { "John", "Alice", "Bob", "Carol", "@#$%^" };
            var expectedSortedNames = new List<string> { "@#$%^","Alice", "Bob", "Carol", "John" };
            var loggerMock = new Mock<ILogger<MergeSortStrategy>>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);

            var sortedNames = mergeSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, sortedNames);
        }
    }
}
