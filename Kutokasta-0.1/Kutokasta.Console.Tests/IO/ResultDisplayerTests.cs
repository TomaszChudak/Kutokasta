using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Kutokasta.Console.IO;
using Kutokasta.Console.Models;
using Moq;
using Xunit;

namespace Kutokasta.Console.Tests.IO
{
    public class ResultDisplayerTests
    {
        public ResultDisplayerTests()
        {
            _consoleWrapperMock = new Mock<IConsoleWrapper>();
            _sut = new ResultDisplayer(_consoleWrapperMock.Object);
        }

        private readonly Mock<IConsoleWrapper> _consoleWrapperMock;
        private readonly IResultDisplayer _sut;

        [Fact]
        public void DisplayedWageSet_When_WageSetFound()
        {
            var learningSet = new LearningSet {Name = "fun123"};
            var wageSet = new WageSet {InputWage = 4, BiasWage = -2};

            _sut.DisplayResult(learningSet, wageSet);

            _consoleWrapperMock.Verify(x => x.WriteLine(It.Is<string>(s => s.Contains("fun123"))));
            _consoleWrapperMock.Verify(x => x.WriteLine(It.Is<string>(s => s.Contains("4") && s.Contains("-2"))));
        }

        [Fact]
        public void NoWorkingSetDisplayed_When_NoSetWasFound()
        {
            var learningSet = new LearningSet {Name = "fun123"};
            var wageSet = (WageSet) null;

            _sut.DisplayResult(learningSet, wageSet);

            _consoleWrapperMock.Verify(x => x.WriteLine(It.Is<string>(s => s.Contains("fun123"))));
            _consoleWrapperMock.Verify(x => x.WriteLine(It.Is<string>(s => s.ToLowerInvariant().Contains("no"))));
        }
    }
}