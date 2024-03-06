using Microsoft.Extensions.Logging;
using Moq;
using NameSorter.Sorting;
using NameSorter.Tests.Mocks;

namespace NameSorter.Tests
{
    public class QuickSortStrategyTests
    {
        [Fact]
        public void SortNames_ListIsAlreadySorted_ReturnsSameList()
        {
            var loggerMock = LoggerFactoryMock.Create<QuickSortStrategy>();
            var quickSortStrategy = new QuickSortStrategy(loggerMock.Object);
            var sortedNames = new List<string> { "Carson Case", "Dolores Jongejans", "Phyliss Sol Noreen", "Waldo Baerents Tegan" };

            var result = quickSortStrategy.SortNames(sortedNames);

            Assert.Equal(sortedNames, result);
        }

        [Fact]
        public void SortNames_ListIsEmpty_ReturnsEmptyList()
        {
            var loggerMock = LoggerFactoryMock.Create<QuickSortStrategy>();
            var quickSortStrategy = new QuickSortStrategy(loggerMock.Object);
            var emptyList = new List<string>();

            Assert.Throws<ArgumentException>(() => quickSortStrategy.SortNames(emptyList));
        }

        [Fact]
        public void SortNames_ListIsUnsorted_ReturnsSortedNames()
        {
            var loggerMock = LoggerFactoryMock.Create<QuickSortStrategy>();

            var quickSortStrategy = new QuickSortStrategy(loggerMock.Object);
            var unsortedNames = new List<string> { "Waldo Baerents Tegan", "Dolores Jongejans", "Carson Case", "Phyliss Sol Noreen" };
            var expectedSortedNames = new List<string> { "Carson Case", "Dolores Jongejans", "Phyliss Sol Noreen", "Waldo Baerents Tegan" };

            var result = quickSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, result);
        }

        [Fact]
        public void MergeSort_ListWithSingleElement_ReturnsSameList()
        {
            var loggerMock = LoggerFactoryMock.Create<QuickSortStrategy>();
            var quickSortStrategy = new QuickSortStrategy(loggerMock.Object);
            var singleElementList = new List<string> { "Dolores" };

            var result = quickSortStrategy.SortNames(singleElementList);

            Assert.Single(result);
            Assert.Equal("Dolores", result[0]);
        }

        [Fact]
        public void SortNames_ListWithDuplicateNames_ReturnsSortedNamesWithDuplicates()
        {
            var unsortedNames = new List<string> { "John", "Alice", "Bob", "Carol", "John", "Bob" };
            var expectedSortedNames = new List<string> { "Alice", "Bob", "Bob", "Carol", "John", "John" };
            var loggerMock = LoggerFactoryMock.Create<QuickSortStrategy>();
            var quickSortStrategy = new QuickSortStrategy(loggerMock.Object);

            var sortedNames = quickSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, sortedNames);
        }

        [Fact]
        public void SortNames_ListWithSpecialCharacters_ReturnsSortedNamesWithSpecialCharacters()
        {
            var unsortedNames = new List<string> { "John", "Alice", "Bob", "Carol", "@#$%^" };
            var expectedSortedNames = new List<string> { "@#$%^", "Alice", "Bob", "Carol", "John" };
            var loggerMock = LoggerFactoryMock.Create<QuickSortStrategy>();
            var quickSortStrategy = new QuickSortStrategy(loggerMock.Object);

            var sortedNames = quickSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, sortedNames);
        }
    }
}
