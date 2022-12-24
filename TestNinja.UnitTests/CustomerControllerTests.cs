using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnsNotFound()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(0);
            //TypeOf means exact type of the object
            Assert.That(result, Is.TypeOf<NotFound>());
            //InstanceOf means Exact instance of the object or derivatives of the object
            Assert.That(result,Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            
        }
    }
}