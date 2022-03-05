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
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_NumberDivisibleByThreeAndFive_ReturnsFizzBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(15), Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleByThree_ReturnsFizz()
        {
            Assert.That(FizzBuzz.GetOutput(9), Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleByFive_ReturnsBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(10), Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_NumberNotDivisibleByThreeAndFive_ReturnsStringNumber()
        {
            Assert.That(FizzBuzz.GetOutput(7), Is.EqualTo(Convert.ToString(7)));
        }

    }
}
