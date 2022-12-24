using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            var user = new User();
            user.IsAdmin = true;
            //Act
            var result = reservation.CanBeCancelledBy(user);
            //Assert
            Assert.That(result==true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            //Arrange
            var reservation = new Reservation();
            var user = new User();
            // lets say the user who made the reservation
            reservation.MadeBy = user;
            //Act
            var result = reservation.CanBeCancelledBy(user);
            //Assert
            Assert.That(result==true);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            //Arrange
            var reservation = new Reservation();
            //lets say any user
            var user = new User();
            //Act
            var result = reservation.CanBeCancelledBy(user);
            //Assert
            Assert.That(result==false);
        }

    }
}
