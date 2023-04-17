using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Core.Contracts;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;

namespace MusicApp.Services.Musics
{
    public interface IPlaylistRepository
    {
        Task<bool> AddOrUpdatePlaylist(
           Playlist playlist,
            CancellationToken cancellationToken = default);

        public Task<bool> DeletePlaylist(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Playlist> GetPlaylistByIdAsync(
          Guid playlistId,
          CancellationToken cancellationToken = default);

        Task<Playlist> GetCachedPlaylistByIDAsync(
          Guid playlistId,
          CancellationToken cancellationToken = default);

        Task<Playlist> GetPlaylistBySlugAsync(
            string slug,
            CancellationToken cancellationToken = default);

        Task<Playlist> GetCachePlaylistBySlugAsync(
            string slug,
            CancellationToken cancellationToken = default);

        Task<IPagedList<T>> GetPagedPlaylistsAsync<T>(
          PlaylistQuery playlistQuery,
          IPagingParams pagingParams,
          Func<IQueryable<Playlist>, IQueryable<T>> mapper,
          CancellationToken cancellationToken = default);

        Task<IList<PlaylistItem>> GetPlaylistAsync(CancellationToken cancellationToken = default);
    }
}
