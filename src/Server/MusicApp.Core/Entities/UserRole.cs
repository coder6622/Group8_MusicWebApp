using Microsoft.AspNetCore.Identity;
using MusicApp.Core.Contracts;

namespace MusicApp.Core.Entities
{
  public class UserRole : IdentityUserRole<Guid>, IEntity
  {
    public Guid Id { get; set; }
    public Role Role { get; set; }
    public User Account { get; set; }
  }
}
