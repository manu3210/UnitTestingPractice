using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IDownload> _download;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _download = new Mock<IDownload>();
            _installerHelper = new InstallerHelper(_download.Object);
        }

        [Test]
        public void DownloadInstaller_InvalidDownload_ReturnsFalse()
        {
            _download.Setup(d => d.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("a", "b");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_ValidDownload_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("a", "b");

            Assert.That(result, Is.EqualTo(true));
        }
    }
}
