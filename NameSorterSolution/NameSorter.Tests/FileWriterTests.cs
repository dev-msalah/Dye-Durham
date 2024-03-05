using NameSorter.Tests.Mocks;

namespace NameSorter.Tests
{
    public class FileWriterTests
    {
        [Fact]
        public void WriteNamesToFile_ShouldWriteNamesToFile_WhenNamesExist()
        {
            var fileWriterMock = new FileWriterMock();
            var expectedNames = new List<string> { "Malinda van Haren", "Kennith Knight", "Lenard Todd Emilio" };
            var outputFile = "output.txt";
            fileWriterMock.SetupWriteNamesToFile(outputFile, expectedNames);

            var fileWriter = fileWriterMock.Object;

            fileWriter.WriteNamesToFile(expectedNames, outputFile);

            fileWriterMock.VerifyWriteNamesToFile(outputFile, expectedNames);

            fileWriterMock.SetupFileExistsCheck(outputFile, true);
            Assert.True(fileWriterMock.Object.FileExists(outputFile));
        }

        [Fact]
        public void WriteNamesToFile_ShouldThrowException_WhenNamesNull()
        {
            var fileWriterMock = new FileWriterMock();
            var outputFile = "output.txt";
            fileWriterMock.SetupWriteNamesToFile(outputFile, null);

            var fileWriter = fileWriterMock.Object;

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteNamesToFile(null, outputFile));
        }

        [Fact]
        public void WriteNamesToFile_ShouldThrowException_WhenFilePathNull()
        {
            var fileWriterMock = new FileWriterMock();
            var expectedNames = new List<string> { "Malinda van Haren", "Kennith Knight", "Lenard Todd Emilio" };
            fileWriterMock.SetupWriteNamesToFile(null, expectedNames);

            var fileWriter = fileWriterMock.Object;

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteNamesToFile(expectedNames, null));
        }

        [Fact]
        public void WriteNamesToFile_ShouldThrowException_WhenFilePathEmpty()
        {
            var fileWriterMock = new FileWriterMock();
            var expectedNames = new List<string> { "Malinda van Haren", "Kennith Knight", "Lenard Todd Emilio" };
            fileWriterMock.SetupWriteNamesToFile(string.Empty, expectedNames);

            var fileWriter = fileWriterMock.Object;

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteNamesToFile(expectedNames, string.Empty));
        }
    }
}
