using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggedTests
    {
        private ErrorLogger _errorLogged;

        [SetUp]
        public void SetUp()
        {
            _errorLogged = new ErrorLogger();
        }


        [Test]
        public void Log_WhenCalled_SetsLastErrorProperty()
        {
            _errorLogged.Log("Hola");

            Assert.That(_errorLogged.LastError, Is.EqualTo("Hola"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_FailedString_ThrowsArgumentNullException(string str)
        {
            Assert.That(() => _errorLogged.Log(str), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var id = Guid.Empty;
            _errorLogged.ErrorLogged += (sender, e) => { id = e; };

            _errorLogged.Log("ema");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
