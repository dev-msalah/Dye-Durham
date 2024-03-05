using Moq;
using NameSorter.Interfaces;

namespace NameSorter.Tests.Mocks
{
    public class NameSorterServiceMock
    {
        private readonly Mock<INameSorterService> _nameSorterServiceMock;

        public NameSorterServiceMock()
        {
            _nameSorterServiceMock = new Mock<INameSorterService>();
        }

        public void SetupSortNamesFromFile(string inputFile, string outputFile, List<string> sortedNames)
        {
            _nameSorterServiceMock.Setup(s => s.SortNamesFromFile(inputFile, outputFile)).Returns(sortedNames);
        }

        public void SetupFileExistsCheck(string filePath, bool exists)
        {
            _nameSorterServiceMock.Setup(s => s.ValidateInput(filePath, It.IsAny<string>())).Returns(exists);
        }

        public INameSorterService Object => _nameSorterServiceMock.Object;
    }
}
