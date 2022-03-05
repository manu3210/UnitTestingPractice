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
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ReturnsFormattedString()
        {
            var htmlFormatter = new HtmlFormatter();

            var result = htmlFormatter.FormatAsBold("Ema");

            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("Ema"));
        }
    }
}
