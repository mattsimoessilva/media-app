using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace
{
    [Route("/lista-videos")]
    public partial class ListaVideos : ComponentBase
    {
        private readonly ApplicationDbContext _context; // Assuming you're using Entity Framework Core

        public ListaVideos(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Titulo { get; set; }
        public Video RandomVideo { get; set; } // Assuming you have a Video class
        public List<Video> Videos { get; set; }
        public List<(string TagName, List<Video> Content)> ContentByTags { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            // Your C# code goes here...
            // Retrieve all tags from the database
            var allTags = _context.Tags.ToList(); // Assuming you have a Tags DbSet

            // Get a random sample of tags (up to the number of available tags)
            var randomTags = allTags.OrderBy(x => Guid.NewGuid()).Take(Math.Min(5, allTags.Count)).ToList();

            // Initialize an empty list to store videos and shows for each tag
            ContentByTags = new List<(string TagName, List<Video> Content)>();

            foreach (var tag in randomTags)
            {
                // Retrieve all videos and shows for the current tag
                var tagVideos = _context.Videos.Where(v => v.Tags.Contains(tag)).ToList(); // Assuming you have a Videos DbSet and a Tags property in your Video class

                if (tagVideos.Any())
                {
                    // Get a random sample of videos and shows (up to the number of available videos and shows for this tag)
                    var tagContentSample = tagVideos.OrderBy(x => Guid.NewGuid()).Take(Math.Min(9, tagVideos.Count)).ToList();

                    ContentByTags.Add((tag.Name, tagContentSample)); // Assuming your Tag class has a Name property
                }
            }

            // Retrieve all videos and shows from the database
            var allVideos = _context.Videos.ToList();

            // Get a random sample of videos and shows (up to the number of available videos and shows)
            Videos = allVideos.OrderBy(x => Guid.NewGuid()).Take(Math.Min(9, allVideos.Count)).ToList();

            // Select a random video or show from the list
            RandomVideo = allVideos.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            Titulo = "Em Destaque";
        }
    }
}
