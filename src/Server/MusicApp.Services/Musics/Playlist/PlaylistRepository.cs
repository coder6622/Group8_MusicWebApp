using MusicApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Contracts;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;
using MusicApp.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace MusicApp.Services.Musics
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly MusicDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public PlaylistRepository(MusicDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public Task<bool> AddOrUpdatePlaylist(Playlist playlist, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlaylist(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> GetCachedPlaylistByIDAsync(Guid playlistId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> GetCachePlaylistBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IList<PlaylistItem>> GetPlaylistAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> GetPlaylistByIdAsync(Guid playlistId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> GetPlaylistBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Playlist> FilterPlaylist(PlaylistQuery playlistQuery)
        {

            return _context.Set<Playlist>()
                .Include(p => p.Tags)
                .WhereIf(!string.IsNullOrEmpty(playlistQuery.Keyword),
                        p => p.Name == playlistQuery.Keyword);
        }


        public async Task<IPagedList<T>> GetPagedPlaylistsAsync<T>(
             PlaylistQuery playlistQuery,
             IPagingParams pagingParams,
             Func<IQueryable<Playlist>, IQueryable<T>> mapper,
             CancellationToken cancellationToken = default)
        {
            var playlists = FilterPlaylist(playlistQuery);

            return await mapper(playlists).ToPagedListAsync(pagingParams, cancellationToken);


        }
    }
}
