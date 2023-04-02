using MusicApp.Core.Contracts;

namespace MusicApp.Core.Entities
{
  public class Artist : IEntity
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

    public IList<Song> Songs { get; set; }
    public IList<Playlist> Playlists { get; set; }
  }
}
