using MusicApp.Core.Contracts;

namespace MusicApp.Core.Entities
{
  public class Tag : IEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UrlSlug { get; set; }
    public string Description { get; set; }
    public bool Enable { get; set; }

    public Guid GroupTagId { get; set; }

    public GroupTag GroupTag { get; set; }
    public IList<Song> Songs { get; set; }
    public IList<Playlist> Playlists { get; set; }
  }
}
