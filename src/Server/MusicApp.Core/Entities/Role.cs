using Microsoft.AspNetCore.Identity;
using MusicApp.Core.Contracts;

namespace MusicApp.Core.Entities
{
  public class Role : IdentityRole<Guid>, IEntity
  {
  }
}
