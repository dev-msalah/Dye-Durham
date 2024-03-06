using Microsoft.Extensions.Logging;
using Moq;
using NameSorter.Services;
using NameSorter.Sorting;
using NameSorter.Tests.Mocks;

namespace NameSorter.Tests
{
    public class MergeSortStrategyTests
    {
        [Fact]
        public void SortNames_ListIsAlreadySorted_ReturnsSameList()
        {
             var loggerMock = LoggerFactoryMock.Create<MergeSortStrategy>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);
            var sortedNames = new List<string> { "Carson Case", "Dolores Jongejans", "Phyliss Sol Noreen", "Waldo Baerents Tegan" };

            var result = mergeSortStrategy.SortNames(sortedNames);

            Assert.Equal(sortedNames, result);
        }

        [Fact]
        public void SortNames_ListIsEmpty_ReturnsEmptyList()
        {
             var loggerMock = LoggerFactoryMock.Create<MergeSortStrategy>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);
            var emptyList = new List<string>();

            Assert.Throws<ArgumentException>(() => mergeSortStrategy.SortNames(emptyList));
        }

        [Fact]
        public void SortNames_ListIsUnsorted_ReturnsSortedNames()
        {
             var loggerMock = LoggerFactoryMock.Create<MergeSortStrategy>();
           
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);
            var unsortedNames = new List<string> { "Waldo Baerents Tegan", "Dolores Jongejans", "Carson Case", "Phyliss Sol Noreen" };
            var expectedSortedNames = new List<string> { "Carson Case", "Dolores Jongejans", "Phyliss Sol Noreen", "Waldo Baerents Tegan" };

            var result = mergeSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, result);
        }

        [Fact]
        public void MergeSort_ListWithSingleElement_ReturnsSameList()
        {
             var loggerMock = LoggerFactoryMock.Create<MergeSortStrategy>();
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
             var loggerMock = LoggerFactoryMock.Create<MergeSortStrategy>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);

            var sortedNames = mergeSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, sortedNames);
        }

        [Fact]
        public void SortNames_ListWithSpecialCharacters_ReturnsSortedNamesWithSpecialCharacters()
        {
            var unsortedNames = new List<string> { "John", "Alice", "Bob", "Carol", "@#$%^" };
            var expectedSortedNames = new List<string> { "@#$%^","Alice", "Bob", "Carol", "John" };
             var loggerMock = LoggerFactoryMock.Create<MergeSortStrategy>();
            var mergeSortStrategy = new MergeSortStrategy(loggerMock.Object);

            var sortedNames = mergeSortStrategy.SortNames(unsortedNames);

            Assert.Equal(expectedSortedNames, sortedNames);
        }
    }
}
