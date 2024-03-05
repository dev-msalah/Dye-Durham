
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NameSorter.Interfaces;
using NameSorter.Services;
using NameSorter.Sorting;
using NameSorter.Tests.Mocks;

namespace NameSorter.Tests
{
    public class NameSorterServiceTests
    {
        [Fact]
        public void SortNamesFromFile_InputFileDoesNotExist_ReturnsNull()
        {
            var inputFile = "nonExistentFile.txt";
            var outputFile = "outputFile.txt";

            var loggerMock = new Mock<ILogger<NameSorterService>>();
            var fileReaderMock = new FileReaderMock();
            fileReaderMock.SetupReadNamesFromFile(inputFile, null);

            var fileWriterMock = new FileWriterMock();
            var sortStrategyMock = new SortStrategyMock();

            var nameSorterService = new NameSorterService(loggerMock.Object, fileReaderMock.Object, fileWriterMock.Object, sortStrategyMock.Object);

            var result = nameSorterService.SortNamesFromFile(inputFile, outputFile);

            Assert.Null(result);
        }

        [Fact]
        public void SortNamesFromFile_ShouldReturnNull_WhenNoNamesFoundInInputFile()
        {
            var inputFile = "input.txt";
            var outputFile = "output.txt";

            var loggerMock = new Mock<ILogger<NameSorterService>>();

            var fileReaderMock = new FileReaderMock();
            fileReaderMock.SetupReadNamesFromFile(inputFile, new List<string>());

            var fileWriterMock = new FileWriterMock();
            var sortStrategyMock = new SortStrategyMock();

            var nameSorterService = new NameSorterService(loggerMock.Object, fileReaderMock.Object, fileWriterMock.Object, sortStrategyMock.Object);
            var result = nameSorterService.SortNamesFromFile(inputFile, outputFile);

            Assert.Null(result);
        }

        [Fact]
        public void SortNamesFromFile_ShouldReturnNull_WhenInvalidInputFile()
        {
            
            var inputFile = "nonexistent.txt";
            var outputFile = "output.txt";

            var loggerMock = new Mock<ILogger<NameSorterService>>();

            var fileReaderMock = new FileReaderMock();
            fileReaderMock.SetupReadNamesFromFile(inputFile, null);

            var fileWriterMock = new FileWriterMock();
            var sortStrategyMock = new SortStrategyMock();

            var nameSorterService = new NameSorterService(loggerMock.Object, fileReaderMock.Object, fileWriterMock.Object, sortStrategyMock.Object);
                        
            var result = nameSorterService.SortNamesFromFile(inputFile, outputFile);

            Assert.Null(result);
        }

        [Fact]
        public void SortNamesFromFile_ShouldReturnSortedNames_WhenValidInput()
        {
            var inputFile = "input.txt";
            var outputFile = "output.txt";
            var unsortedName = new List<string> { "Waldo Baerents Tegan", "Dolores Jongejans", "Carson Case", "Phyliss Sol Noreen" };
            var expectedNames = new List<string> { "Carson Case", "Dolores Jongejans", "Phyliss Sol Noreen", "Waldo Baerents Tegan" };

            var fileReaderMock = new FileReaderMock();
            fileReaderMock.SetupReadNamesFromFile(inputFile,unsortedName);

            var fileWriterMock = new FileWriterMock();
            fileWriterMock.SetupFileExistsCheck(inputFile, true);

            var sortStrategyMock = new SortStrategyMock();
            sortStrategyMock.SetupSortNames(unsortedName, expectedNames);

            var nameSorterService = new NameSorterService(NullLogger<NameSorterService>.Instance, fileReaderMock.Object, fileWriterMock.Object, sortStrategyMock.Object);

            var result = nameSorterService.SortNamesFromFile(inputFile, outputFile);

            Assert.NotNull(result);
            Assert.Equal(expectedNames, result);
        }
    }
}
