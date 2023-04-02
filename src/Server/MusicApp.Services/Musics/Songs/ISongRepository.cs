using MusicApp.Core.Contracts;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services.Musics.Songs
{
  public interface ISongRepository
  {
    Task<IPagedList<T>> GetPagedSongsAsync<T>(
      SongQuery query,
      IPagingParams pagingParams,
      Func<IQueryable<Song>, IQueryable<T>> mapper,
      CancellationToken cancellationToken = default);
  }
}
