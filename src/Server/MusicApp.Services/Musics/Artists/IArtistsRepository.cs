using MusicApp.Core.Entities;
using MusicApp.Core.DTO;

namespace MusicApp.Services.Musics.Artists
{
  public interface IArtistsRepository
  {
    Task<bool> AddOrUpdateArtists(
        Artist artist,
        CancellationToken cancellationToken = default);

    public Task<bool> DeleteArtists(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Artist> GetArtistByIdAsync(
      Guid artistId,
      CancellationToken cancellationToken = default);

    Task<Artist> GetCachedArtistByIDAsync(
      Guid artistId,
      CancellationToken cancellationToken = default);

    Task<Artist> GetArtistBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<Artist> GetCacheArtistBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

    Task<IList<ArtistItem>> GetArtistAsync(CancellationToken cancellationToken = default);
  }
}
