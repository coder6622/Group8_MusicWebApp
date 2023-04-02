using MusicApp.Core.Contracts;

namespace MusicApp.Core.Entities
{
  public class Playlist : IEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UrlSlug { get; set; }
    public string IsPublic { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool Enable { get; set; }

    public Guid UserId { get; set; }


    public User User { get; set; }
    public IList<Artist> Artists { get; set; }
    public IList<Song> Songs { get; set; }
    public IList<Tag> Tags { get; set; }
  }
}
