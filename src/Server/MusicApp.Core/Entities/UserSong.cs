using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.Core.Entities
{
  public class UserSong
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SongId { get; set; }

    public bool IsLike { get; set; }
    public int PlayCount { get; set; }

    public DateTime CreatedDate { get; set; }

    public User User { get; set; }
    public Song Song { get; set; }
  }
}
