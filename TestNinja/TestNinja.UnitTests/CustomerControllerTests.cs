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
    public class CustomerControllerTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(0)]
        public void GetCustomer_WhenCalled_ReturnsATypeOfActionResult(int id)
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(id);

            Assert.That(result, Is.InstanceOf<ActionResult>());
        }
        [Test]
        public void GetCustomer_CustomerIdZero_ReturnsNotFound()
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
        }
        [Test]
        public void GetCustomer_CustomerIdOne_ReturnsOk()
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
