﻿using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Contracts;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;
using MusicApp.Data.Contexts;
using MusicApp.Services.Extensions;

namespace MusicApp.Services.Musics.Songs
{
    public class SongRespository : ISongRepository
    {
        private readonly MusicDbContext _context;

        public SongRespository(MusicDbContext context)
        {
            _context = context;
        }

        private IQueryable<Song> FilterSong(SongQuery condition)
        {
            return _context.Set<Song>()
              .Include(s => s.Artists)
              .Include(s => s.Category)
              .Include(s => s.Playlists)
              .WhereIf(!string.IsNullOrEmpty(condition.Keyword),
                 s => s.Name.Contains(condition.Keyword)
                 || s.Artists.Any(a => a.FullName.Contains(condition.Keyword))
                 || s.Category.Name.Contains(condition.Keyword)
                 || s.Playlists.Any(p => p.Name.Contains(condition.Keyword)));
        }

        public async Task<IPagedList<T>> GetPagedSongsAsync<T>(
          SongQuery query,
          IPagingParams pagingParams,
          Func<IQueryable<Song>, IQueryable<T>> mapper,
          CancellationToken cancellationToken = default)
        {

            var songs = FilterSong(query);
            return await mapper(songs)
              .ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<Song> GetSongAsync(
            Guid id,
            bool includeDetail = false,
            CancellationToken cancellationToken = default)
        {
            if (includeDetail)
            {
                return await _context.Set<Song>()
                                    .Include(s => s.Artists)
                                    .Include(s => s.Playlists)
                                    .Include(s => s.Category)
                                    .Include(s => s.Tags)
                                    .Where(s => s.Id == id)
                                    .FirstOrDefaultAsync(cancellationToken);
            }

            return await _context.Set<Song>()
                .FindAsync(id, cancellationToken);
        }
    }
}
