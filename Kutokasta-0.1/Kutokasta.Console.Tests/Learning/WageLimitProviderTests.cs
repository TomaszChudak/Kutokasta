using System.Linq;
using FluentAssertions;
using Kutokasta.Console.Learning;
using Kutokasta.Console.Models;
using Xunit;

namespace Kutokasta.Console.Tests.Learning
{
    public class WageLimitProviderTests
    {
        public WageLimitProviderTests()
        {
            _sut = new WageLimitProvider();
        }

        private readonly IWageLimitProvider _sut;

        [Fact]
        public void CallingIncreasingWageLimitMethod_Should_IncreaseWageLimit()
        {
            var result = _sut.GetReasonableWageSets().ToList();
            
            result.Should().NotBeEmpty();
            var a = result.Distinct();
            result.Should().HaveSameCount(result.Distinct());
        }
    }
}