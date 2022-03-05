using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestNinja.Fundamentals;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Fundamentals.Math? _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
        }


        [Test]
        public void Add_WhenCalled_ReturnsTheSumOfTheArguments()
        {
            TestNinja.Fundamentals.Math math = new Fundamentals.Math();

            var result = math.Add(1, 2);

            Assert.AreEqual(3, result);
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsTheMaxArgument(int a, int b, int expected)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetOddNumbers_LimitGraterThanZero_ReturnAListOfNumbers()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }
    }
}
