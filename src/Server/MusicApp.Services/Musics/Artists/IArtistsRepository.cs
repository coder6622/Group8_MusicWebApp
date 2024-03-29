﻿using MusicApp.Core.Entities;
using MusicApp.Core.DTO;

namespace MusicApp.Services.Musics.Artists
{
    public interface IArtistsRepository
    {
        Task<Artist> AddOrUpdateArtists(
            Artist artist,
            CancellationToken cancellationToken = default);

        Task<bool> IsExistArtistSlugAsync(Guid id, string slug, CancellationToken cancellation = default);

        public Task<bool> DeleteArtists(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<Artist> GetArtistByIdAsync(
          Guid artistId,
          bool includeDetail = false,
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