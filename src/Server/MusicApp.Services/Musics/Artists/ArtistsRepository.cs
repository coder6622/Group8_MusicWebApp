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
    public async Task<bool> AddOrUpdateArtists(
        Artist artist,
        CancellationToken cancellationToken = default)
    {
      if (artist.Id != null)
      {
        _context.Set<Artist>().Update(artist);
      }
      else
      {
        _context.Set<Artist>().Add(artist);
      }
      return await _context.SaveChangesAsync(cancellationToken) > 0;
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
    #endregion

    #region Lay danh sach tac gia
    public async Task<Artist> GetArtistByIdAsync(
      Guid artistId,
      CancellationToken cancellationToken = default)
    {
      return await _context.Set<Artist>()
        .FindAsync(artistId, cancellationToken);
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
          .OrderBy(a => a.FullName)
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

    public Task<Artist> GetArtistByIdAsync(Guid artistId)
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
