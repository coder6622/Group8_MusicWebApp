using Microsoft.AspNetCore.Identity;
using MusicApp.Core.Contracts;

namespace MusicApp.Core.Entities
{
  public class User : IdentityUser<Guid>, IEntity
  {
    public string FullName { get; set; }
    public string ImageUrl { get; set; }
    public DateTime PwdChangedDate { get; set; }
    public bool Enable { get; set; }

    public IList<Playlist> Playlists { get; set; }
    public IList<UserSong> UserSongs { get; set; }

  }
}
