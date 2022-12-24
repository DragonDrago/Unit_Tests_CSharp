using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            //Arranges
             
            //Mock only used for external dependencies
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            
            //Now we will give actual object of IFileReader, that is prepared or initialized with mock to VideoService
            _videoService = new VideoService(_fileReader.Object,_repository.Object);
           
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            // Now e make sample case for tasting by ourselves, that returns empty string or null
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosACsv_AllVideosAreProcessed_RreturnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result,Is.EqualTo(""));
        }
        
        [Test]
        public void GetUnprocessedVideosACsv_AfewUnprocessedVideos_RreturnStringWithId()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video{Id = 1},
                new Video{Id = 2},
                new Video{Id = 3},
            });
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result,Is.EqualTo("1,2,3"));
        }
    }
}