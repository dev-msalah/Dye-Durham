using Moq;
using NameSorter.Interfaces;

namespace NameSorter.Tests.Mocks
{
    public class FileWriterMock
    {
        private readonly Mock<IFileWriter> _fileWriterMock;

        public FileWriterMock()
        {
            _fileWriterMock = new Mock<IFileWriter>();
        }

        public void SetupWriteNamesToFile(string filePath, List<string> names)
        {
            if (names == null || string.IsNullOrWhiteSpace(filePath))
            {
                _fileWriterMock.Setup(w => w.WriteNamesToFile(It.IsAny<List<string>>(), filePath))
                               .Throws(new ArgumentNullException(nameof(names)));
            }
            else
            {
                _fileWriterMock.Setup(w => w.WriteNamesToFile(names, filePath));
            }
        }

        public void VerifyWriteNamesToFile(string filePath, List<string> expectedNames)
        {
            _fileWriterMock.Verify(w => w.WriteNamesToFile(expectedNames, filePath), Times.Once);
        }

        public void SetupFileExistsCheck(string filePath, bool exists)
        {
            _fileWriterMock.Setup(w => w.FileExists(filePath)).Returns(exists);
        }

        public IFileWriter Object => _fileWriterMock.Object;
    }
}
