using MusicApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace MusicApp.Services.Musics.Artists
{
    public class ArtistsRepository : IArtistsRepository
    {
        private readonly MusicDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public ArtistsRepository(MusicDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        #region Them,Xoa,Sua Artists
        public async Task<Artist> AddOrUpdateArtists(
            Artist artist,
            CancellationToken cancellationToken = default)
        {
            if (_context.Set<Artist>().Any(s => s.Id == artist.Id))
            {
                _context.Entry(artist).State = EntityState.Modified;
            }
            else
            {
                artist.Id = Guid.NewGuid();
                _context.Artists.Add(artist);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return artist;
        }

        public async Task<bool> DeleteArtists(Guid id, CancellationToken cancellationToken = default)
        {
            var artist = await _context.Set<Artist>().FindAsync(id);
            if (artist is null)
                return false;

            _context.Set<Artist>().Remove(artist);
            var rowsCount = await _context.SaveChangesAsync(cancellationToken);

            return rowsCount > 0;
        }

        public async Task<bool> IsExistArtistSlugAsync(Guid id, string slug, CancellationToken cancellation = default)
        {
            return await _context.Set<Artist>().AnyAsync(s => s.Id != id && s.UrlSlug.Equals(slug), cancellation);
        }

        #endregion

        #region Lay danh sach tac gia
        public async Task<Artist> GetArtistByIdAsync(
          Guid artistId,
          bool includeDetail = false,
          CancellationToken cancellationToken = default)
        {
            if (!includeDetail)
            {
                return await _context.Set<Artist>()
                  .FindAsync(artistId, cancellationToken);
            }

            return await _context.Set<Artist>()
                    .Include(s => s.Songs)
                    .Where(s => s.Id == artistId)
                    .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Artist> GetCachedArtistByIDAsync(
          Guid artistId,
          CancellationToken cancellationToken = default)
        {
            return await _memoryCache.GetOrCreateAsync(
                $"artist.by-id.{artistId}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return await GetArtistByIdAsync(artistId, cancellationToken);
                });
        }

        public async Task<Artist> GetArtistBySlugAsync(
            string slug,
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<Artist>()
                      .Include(s => s.Songs)
                .FirstOrDefaultAsync(a => a.UrlSlug == slug, cancellationToken);
        }

        public async Task<Artist> GetCacheArtistBySlugAsync(
            String slug, CancellationToken cancellationToken = default)
        {
            return await _memoryCache.GetOrCreateAsync(
                $"artist.by-slug.{slug}",
                async (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return await GetArtistBySlugAsync(slug, cancellationToken);
                });
        }

        public async Task<IList<ArtistItem>> GetArtistAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Artist>()
                .Select(a => new ArtistItem()
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    UrlSlug = a.UrlSlug,
                    ImageUrl = a.ImageUrl,
                    DayOfBirth = a.DayOfBirth,
                    Gender = a.Gender,
                    Nation = a.Nation,
                    Information = a.Information,
                    SongsCount = a.Songs.Count()
                })
                .ToListAsync(cancellationToken);
        }

        public Task<Artist> GetArtistByIdAsync(Guid artistId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetCachedArtistByIDAsync(Guid artistId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
