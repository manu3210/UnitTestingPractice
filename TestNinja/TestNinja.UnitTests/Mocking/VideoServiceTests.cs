using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("Video.txt")).Returns("");

            var repository = new Mock<IRepository>();
            repository.Setup(r => r.GetUnprocessedList()).Returns(new List<Video> { new Video { Id = 1, IsProcessed = false, Title = "hello" },
                                                                                    new Video { Id = 2, IsProcessed = false, Title = "world" } });

            _videoService = new VideoService(fileReader.Object, repository.Object);
        }

        [Test]
        public void ReadVideoTitle_VideoIsNull_ReturnError()
        {
            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCalled_ReturnsAnStringWithVideoIds()
        {
            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Does.StartWith("1"));
            Assert.That(result, Does.Contain(","));
            Assert.That(result, Does.EndWith("2"));

        }
    }
}
