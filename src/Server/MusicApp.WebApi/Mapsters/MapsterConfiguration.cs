using Mapster;
using MusicApp.Core.Entities;
using MusicApp.WebApi.Models;

namespace MusicApp.WebApi.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Playlist, PlaylistDto>();
        }
    }
}
