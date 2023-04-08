using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Core.DTO
{
    public class ArtistItem
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DayOfBirth { get; set; }
        public int Gender { get; set; }
        public string Nation { get; set; }
        public string Information { get; set; }
        public bool Enable { get; set; }

        public int SongsCount { get; set; } 
    }
}
