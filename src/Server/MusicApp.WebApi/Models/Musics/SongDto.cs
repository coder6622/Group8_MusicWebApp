using MusicApp.Core.Entities;

namespace MusicApp.WebApi.Models.Musics
{
  public class SongDto
  {
    public Guid Id { get; set; }

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
    public bool IsPublic { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool Enable { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; }

    public IList<UserSong> UserSongs { get; set; }
    public IList<Tag> Tags { get; set; }
    public IList<Artist> Artists { get; set; }
    public IList<Playlist> Playlists { get; set; }

  }
}
