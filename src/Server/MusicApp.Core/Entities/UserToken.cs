using Microsoft.AspNetCore.Identity;
using MusicApp.Core.Contracts;

namespace MusicApp.Core.Entities
{
  public class UserToken : IdentityUserToken<Guid>, IEntity
  {
    public Guid Id { get; set; }
  }
}
