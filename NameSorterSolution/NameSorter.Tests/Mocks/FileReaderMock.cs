using Moq;
using NameSorter.Interfaces;

namespace NameSorter.Tests.Mocks
{
    public class FileReaderMock
    {
        private readonly Mock<IFileReader> _fileReaderMock;

        public FileReaderMock()
        {
            _fileReaderMock = new Mock<IFileReader>();
        }

        public void SetupReadNamesFromFile(string filePath, List<string> names)
        {
            if (names == null)
            {
                _fileReaderMock.Setup(r => r.ReadNamesFromFile(filePath)).Throws(new FileNotFoundException());
            }
            else
            {
                _fileReaderMock.Setup(r => r.ReadNamesFromFile(filePath)).Returns(names);
            }
        }

        public void VerifyReadNamesFromFile(string filePath)
        {
            _fileReaderMock.Verify(r => r.ReadNamesFromFile(filePath), Times.Once);
        }

        public IFileReader Object => _fileReaderMock.Object;
    }
}
