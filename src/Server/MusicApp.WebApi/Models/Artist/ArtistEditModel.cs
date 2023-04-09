namespace MusicApp.WebApi.Models.Artist
{
    public class ArtistEditModel
    {
        public string FullName { get; set; }
        public string UrlSlug { get; set; }
        public DateTime DayOfBirth { get; set; }
        public int Gender { get; set; }
        public string Nation { get; set; }
        public string Information { get; set; }
    }
}
