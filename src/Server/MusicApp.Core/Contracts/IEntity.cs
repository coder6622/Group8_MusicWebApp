﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Core.Contracts
{
  public interface IEntity
  {
    Guid Id { get; set; }
  }
}
