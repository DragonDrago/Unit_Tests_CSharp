using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(9,"Fizz")]
        [TestCase(10,"Buzz")]
        [TestCase(30,"FizzBuzz")]
        [TestCase(4,"4")]
        public void FizzBuzz_GiveValue_ReturnFizz_Buzz_FizBuzz_Or_Number(int number, string expectedResult)
        {

            var result = FizzBuzz.GetOutput(number);
            Assert.That(result,Is.EqualTo(expectedResult).IgnoreCase);
        }
    }
}