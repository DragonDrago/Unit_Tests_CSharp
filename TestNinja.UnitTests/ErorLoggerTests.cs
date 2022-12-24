using System;
using System.Xml;
using Castle.Components.DictionaryAdapter.Xml;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //!!!!!!!!!!! Do not forget do not Test Private class !!!!!!!!!!!!!!!!!!! because later It makes problems in your code.
    [TestFixture]
    public class ErorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var errorLogger = new ErrorLogger();
                // it is a void method so it does not return a value
            errorLogger.Log("new error by me");
            
            //In the assert we discover or show what to do
            Assert.That(errorLogger.LastError, Is.EqualTo("new error by me"));
            //Moreover to check the test is good, instead of using TDD, we can just change the logic in the code or comment out some calculations
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var errorLogger = new ErrorLogger();
           // errorLogger.Log(error); //in this case we do action in Assert
           Assert.That(()=>errorLogger.Log(error),Throws.ArgumentNullException);
          // Assert.That(()=>errorLogger.Log(error),Throws.Exception.TypeOf<DividedByZero>()); // it is for some specific cases
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();
            //GUID is global unique id
            var id = Guid.Empty;
            //ErrorLogged is delegate, when error logged created Id for it and with event raised
            logger.ErrorLogged += (sender, args) => { id = args;};
            logger.Log("a");
            Assert.That(id,Is.Not.EqualTo(Guid.Empty));
        }
    }
}