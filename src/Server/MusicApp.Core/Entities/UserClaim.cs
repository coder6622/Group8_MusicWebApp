using Microsoft.AspNetCore.Identity;
using MusicApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Core.Entities
{
  public class UserClaim : IdentityUserClaim<Guid>
  {
  }
}
