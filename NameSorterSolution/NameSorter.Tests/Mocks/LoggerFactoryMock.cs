using Microsoft.Extensions.Logging;
using Moq;

namespace NameSorter.Tests.Mocks
{
    public static class LoggerFactoryMock
    {
        public static Mock<ILogger<T>> Create<T>() where T : class
        {
            return new Mock<ILogger<T>>();
        }
    }
}
