using Xunit;

namespace SimpleRPG.Game.Tests
{
    public class TestClassTests
    {
        [Fact]
        public void DoSomething_Test()
        {
            // arrange
            var cut = new TestClass();

            // act
            var result = cut.DoSomething("TestABC");

            // assert
            Assert.True(result);
            Assert.Equal("TestABC", cut.Name);
        }
    }
}
