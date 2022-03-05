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
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(500)]
        public void CalculateDemeritPoints_SpeedLessThanZeroAndGreaterThanMaxSpeed_ThrowsArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedLessOrEqualsSpeedLimit_ReturnsZero()
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(50), Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedGreaterThanSpeedLimit_ReturnsDemeritPoints()
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(90), Is.EqualTo(5));
        }

    }
}
