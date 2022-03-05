using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IEmployeeRepository> _employeeRepository;

        [SetUp]
        public void SetUp()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _controller = new EmployeeController(_employeeRepository.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteItemFromDB()
        {
            int id = 1;
            _controller.DeleteEmployee(id);
            _employeeRepository.Verify(er => er.Delete(id));
        }


    }
}
