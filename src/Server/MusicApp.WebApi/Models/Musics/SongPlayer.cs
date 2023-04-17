using MusicApp.Core.Entities;
using MusicApp.WebApi.Models.Artist;

namespace MusicApp.WebApi.Models.Musics
{
    public class SongPlayer
    {
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public int Duration { get; set; }

        public string Lyrics { get; set; }

        public string Meta { get; set; }

        public bool HasLyrics { get; set; }

        public string LrcUrl { get; set; }

        public string SongUrl { get; set; }

        public string ImageUrl { get; set; }

        public int TotalPlayCount { get; set; }

        public int TotalLike { get; set; }

        public string ArtistNames { get; set; }

        public IList<ArtistDto> Artists { get; set; }
    }
}
