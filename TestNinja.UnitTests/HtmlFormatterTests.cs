using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abs");
            //Specific way
            Assert.That(result=="<strong>abs</strong>");
            
            //A bit more general way
            Assert.That(result,Does.StartWith("<strong>"));
            Assert.That(result,Does.EndWith("</strong>"));
            Assert.That(result,Does.Contain("ABS").IgnoreCase); // as you see the IgnoreCase mehtod ignore weather it is upper or lower case
        }
    }
}