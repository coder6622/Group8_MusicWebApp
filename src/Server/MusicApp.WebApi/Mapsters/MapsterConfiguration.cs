using Mapster;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;

namespace MusicApp.WebApi.Mapsters
{
  public class MapsterConfiguration : IRegister
  {
    public void Register(TypeAdapterConfig config)
    {
            config.NewConfig<Artist, ArtistItem>()
                .Map(desc => desc.SongsCount, src => src.Songs == null ? 0 : src.Songs.Count);
    }
  }
}
