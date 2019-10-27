using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Kutokasta.Console.IO;
using Kutokasta.Console.Models;
using Moq;
using Xunit;

namespace Kutokasta.Console.Tests.IO
{
    public class LearningSetReaderTests
    {
        public LearningSetReaderTests()
        {
            _directoryInfoWrapperMock = new Mock<IDirectoryInfoWrapper>(MockBehavior.Strict);
            _fileWrapperMock = new Mock<IFileWrapper>(MockBehavior.Strict);
            _sut = new LearningSetReader(_directoryInfoWrapperMock.Object, _fileWrapperMock.Object);
        }

        private readonly Mock<IDirectoryInfoWrapper> _directoryInfoWrapperMock;
        private readonly Mock<IFileWrapper> _fileWrapperMock;
        private readonly ILearningSetReader _sut;

        [Fact]
        public void EmptySet_When_NoFilesInDirectory()
        {
            _directoryInfoWrapperMock.Setup(x => x.GetFilesFromDirectory(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<FileInfo>().ToArray());

            var result = _sut.GetLearningSets();

            Assert.Empty(result);
        }

        [Fact]
        public void RightLearningSet_When_OnlyOneFileInDirectory()
        {
            _directoryInfoWrapperMock.Setup(x => x.GetFilesFromDirectory(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<FileInfo> {new FileInfo("aaa")}.ToArray());
            _fileWrapperMock.Setup(x => x.ReadAllText(It.IsAny<string>()))
                .Returns("{\"name\": \"fun1\",\"examples\": [{\"input\": [1, 2, 3], \"output\": 4}]}");
            var result = _sut.GetLearningSets();

            var expectedResult = new LearningSet
            {
                Name = "fun1",
                Examples = new List<Example>
                {
                    new Example
                    {
                        Input = new List<int> {1, 2, 3},
                        Output = 4
                    }
                }
            };

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}