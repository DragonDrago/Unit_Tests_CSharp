using System.Linq;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //DONT FORGET!!!!!!!! IF your test case always passes even you change the production (return value) , it means your test case is wrong
    // So dont forget to change the production code to check your test case 
    [TestFixture]
    public class MathTest
    {
        // it is required in test creating new instance but we can make it simpler with setup method
        private Math math;
        //SetUp
        [SetUp]
        public void SetUp()
        {
            math = new Math();
        } 
        //TearDown ==> it for Integration tests
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            //var math = new Math();
            //Act
            var result = math.Add(1, 2);
            //Assert 
            Assert.That(result==3);
        }
        
        [Test]
        public void Max_First_ArgumentIsGreater_ReturnTheFirstArgument()
        {
            //var math = new Math();

            var result = math.Max(4, 3);
            
            Assert.That(result==4);
        }
        
        
        
        [Test]
        [Ignore("Because to check the 'Ignore' I wanted to do it")]
        public void Max_Second_ArgumentIsGreater_ReturnTheSecondArgument()
        {
            //var math = new Math();

            var result = math.Max(1, 3);
            
            Assert.That(result==3);
        }
        
        
        
        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            //var math = new Math();

            var result = math.Max(3, 3);
            
            Assert.That(result==3);
        }
        
        
        
        // if it is conditional and repetive by giving value we can use from this way of testing
        [Test]
        [TestCase(1,2,2)]
        [TestCase(5,2,5)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = math.Max(a, b);
            Assert.That(result==expectedResult);
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = math.GetOddNumbers(5);
            Assert.That(result,Is.Not.Empty);
            Assert.That(result.Count(),Is.EqualTo(3));
            Assert.That(result,Does.Contain(1));
            Assert.That(result,Does.Contain(3));
            Assert.That(result,Does.Contain(5));
            //We can test the code as much as we can, for example we can expect whole array list
            Assert.That(result, Is.EquivalentTo(new [] {1,3,5}));
            //If numbers are ordered
            Assert.That(result,Is.Ordered);
           // Assert.That(result,Is.Unique);

        }
        
    }
}