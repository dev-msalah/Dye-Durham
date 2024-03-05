using System.Collections.Generic;
using Xunit;
using NameSorter.Tests.Mocks;

namespace NameSorter.Tests
{
    public class FileReaderTests
    {
        [Fact]
        public void ReadNamesFromFile_ShouldReturnListOfNames_WhenFileExists()
        {
            var fileReaderMock = new FileReaderMock();
            var expectedNames = new List<string> { "Malinda van Haren", "Kennith Knight", "Lenard Todd Emilio" };
            fileReaderMock.SetupReadNamesFromFile("existing.txt", expectedNames);

            var fileReader = fileReaderMock.Object;

            var result = fileReader.ReadNamesFromFile("existing.txt");

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Contains("Malinda van Haren", result);
            Assert.Contains("Kennith Knight", result);
            Assert.Contains("Lenard Todd Emilio", result);
        }

        [Fact]
        public void ReadNamesFromFile_ShouldReturnEmptyList_WhenFileIsEmpty()
        {
            var fileReaderMock = new FileReaderMock();
            fileReaderMock.SetupReadNamesFromFile("empty.txt", new List<string>());

            var fileReader = fileReaderMock.Object;

            var result = fileReader.ReadNamesFromFile("empty.txt");

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ReadNamesFromFile_ShouldThrowException_WhenFileDoesNotExist()
        {
            var fileReaderMock = new FileReaderMock();
            fileReaderMock.SetupReadNamesFromFile("nonexistent.txt", null);

            var fileReader = fileReaderMock.Object;
            
            Assert.Throws<FileNotFoundException>(() => fileReader.ReadNamesFromFile("nonexistent.txt"));
        }
    }
}
