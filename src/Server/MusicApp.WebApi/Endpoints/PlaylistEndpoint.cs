using MapsterMapper;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using MusicApp.Core.Collections;
using MusicApp.WebApi.Models;
using MusicApp.Core.DTO;
using Carter;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using MusicApp.Services.Musics;
using MusicApp.Core.Entities;

namespace MusicApp.WebApi.Endpoints
{
    public class PlaylistEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/playlists");

            routeGroupBuilder.MapGet("/", GetPlaylists)
                .WithName("GetPlaylists")
                .Produces<ApiResponse<PaginationResult<PlaylistDto>>>();

            routeGroupBuilder.MapGet("/{id:Guid}", GetPlaylistDetails)
                .WithName("GetPlaylistByID")
                .Produces<ApiResponse<PlaylistItem>>();

            routeGroupBuilder.MapDelete("/{id:Guid}", DeletePlaylist)
                .WithName("DeletPlaylist")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetPlaylistDetails(
            Guid id,
            IPlaylistRepository playlistRepository,
            IMapper mapper)
        {
            var artist = await playlistRepository.GetPlaylistByIdAsync(id);

            return artist == null
          ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy  = {id}"))
          : Results.Ok(ApiResponse.Success(mapper.Map<ArtistItem>(artist)));
        }

        private static async Task<IResult> DeletePlaylist(
          Guid id,
          IPlaylistRepository playlistRepository)
        {
            return await playlistRepository.DeletePlaylist(id)
              ? Results.Ok(ApiResponse.Success("Đã xóa Playlist", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không thể tìm thấy = {id}"));
        }


        private static async Task<IResult> GetPlaylists(
            [AsParameters] PlaylistFilterModel playlistFilterModel,
            IMapper mapper,
            IPlaylistRepository playlistRepository)
        {

            var playlistQuery = mapper.Map<PlaylistQuery>(playlistFilterModel);
            var playlists = await playlistRepository
                .GetPagedPlaylistsAsync<PlaylistDto>(playlistQuery, playlistFilterModel,
                        playlists => playlists.ProjectToType<PlaylistDto>());

            var painationREsult = new PaginationResult<PlaylistDto>(playlists);

            return Results.Ok(ApiResponse.Success(painationREsult));
        }

    }
}
