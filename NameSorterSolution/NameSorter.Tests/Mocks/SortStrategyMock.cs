using Moq;
using NameSorter.Sorting;

namespace NameSorter.Tests.Mocks
{
    public class SortStrategyMock
    {
        private readonly Mock<ISortStrategy> _sortStrategyMock;

        public SortStrategyMock()
        {
            _sortStrategyMock = new Mock<ISortStrategy>();
        }

        public void SetupSortNames(List<string> unsortedNames, List<string> sortedNames)
        {
            _sortStrategyMock.Setup(s => s.SortNames(unsortedNames)).Returns(sortedNames);
        }

        public ISortStrategy Object => _sortStrategyMock.Object;
    }
}
