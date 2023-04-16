using Carter;
using Mapster;
using MapsterMapper;
using MusicApp.Core.Collections;
using MusicApp.Core.DTO;
using MusicApp.Core.Entities;
using MusicApp.Services.Musics.Songs;
using MusicApp.WebApi.Models;
using MusicApp.WebApi.Models.Musics;
using System.Net;

namespace MusicApp.WebApi.Endpoints
{
    public class SongEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/songs");

            routeGroupBuilder.MapGet("/", GetSongs)
            .WithName("GetSongs")
            .Produces<ApiResponse<PaginationResult<SongDto>>>();

            routeGroupBuilder.MapGet("/{id:Guid}", GetSongPlayer)
            .WithName("GetSongPlayer")
            .Produces<ApiResponse<SongPlayer>>();


        }


        private static async Task<IResult> GetSongs(
          [AsParameters] MusicFilterModel model,
          ISongRepository songRepository,
          IMapper mapper)
        {
            var songQuery = mapper.Map<SongQuery>(model);

            var songs = await songRepository
              .GetPagedSongsAsync<SongDto>(
                  songQuery, model,
                  songs => songs.ProjectToType<SongDto>());

            var paginationResult = new PaginationResult<SongDto>(songs);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> GetSongPlayer(
            Guid id,
            ISongRepository songRepository,
            IMapper mapper)
        {
            var song = await songRepository.GetSongAsync(id, true);

            return song == null
                ? Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.NotFound,
                    $"Không tìm thấy id = {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<SongPlayer>(song)));

        }

    }
}
