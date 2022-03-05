using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader _fileReader;
        private readonly IRepository _repository;

        public VideoService(IFileReader fileReader, IRepository repository = null)
        {
            _fileReader = fileReader;
            _repository = repository ?? new Repository();
        }
        public string ReadVideoTitle()
        {
            var video = JsonConvert.DeserializeObject<Video>(_fileReader.Read("Video.txt"));
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _repository.GetUnprocessedList();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
        
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }


}