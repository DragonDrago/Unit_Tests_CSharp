using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(0,0)]
        [TestCase(5,0)]
        [TestCase(65,0)]
        [TestCase(67,0)]
        [TestCase(69,0)]
        [TestCase(70,1)]
        [TestCase(73,1)]
        public void GetInput_IfLessEqual65AndHigherZero_ElseAdd1DeremitForEach5(int speed, int expectedResult)
        {
            var demeritClass = new DemeritPointsCalculator();
            var result = demeritClass.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(-4)]
        [TestCase(-13)]
        public void GetInput_IfLessZero_ThrowOutOfRangeException(int speed)
        {
            var demeritClass = new DemeritPointsCalculator();
            Assert.That(()=>demeritClass.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}