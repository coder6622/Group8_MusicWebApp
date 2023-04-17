using Mapster;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;
using MusicApp.WebApi.Models;
using MusicApp.WebApi.Models.Artist;
using MusicApp.WebApi.Models.Musics;

namespace MusicApp.WebApi.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Playlist, PlaylistDto>();

            config.NewConfig<Artist, ArtistDto>();

            config.NewConfig<Song, SongDto>();

            config.NewConfig<Song, SongPlayer>()
                .Map(dest => dest.ArtistNames, src => string.Join("\r, ", src.Artists.Select(a => a.FullName)));

            config.NewConfig<Artist, ArtistItem>()
                    .Map(desc => desc.SongsCount, src => src.Songs == null ? 0 : src.Songs.Count);
        }
    }
}
