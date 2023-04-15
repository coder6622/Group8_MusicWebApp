using Mapster;
using MusicApp.Core.Entities;
using MusicApp.WebApi.Models.Artist;
using MusicApp.WebApi.Models.Musics;

namespace MusicApp.WebApi.Mapsters
{
  public class MapsterConfiguration : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {

      config.NewConfig<Artist, ArtistDto>();

      config.NewConfig<Song, SongDto>();
    }
  }
}
