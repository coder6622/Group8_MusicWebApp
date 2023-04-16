using MapsterMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MusicApp.Services.Musics.Artists;
using MusicApp.WebApi.Models;
using MusicApp.Core.DTO;
using Carter;
using MusicApp.Core.Entities;
using MusicApp.WebApi.Models.Artist;
using MusicApp.WebApi.Filters;

namespace MusicApp.WebApi.Endpoints
{
    public class ArtistEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/artist");

            routeGroupBuilder.MapGet("/{id:Guid}", GetArtistDetails)
                .WithName("GetArtistByID")
                .Produces<ApiResponse<ArtistItem>>();

            

            routeGroupBuilder.MapGet("/", GetAllArtist)
                .WithName("GetAllArtist")
                .Produces<ApiResponse<ArtistItem>>();

            routeGroupBuilder.MapPost("/", addArtist)
               .WithName("Thêm tác giả")
               .AddEndpointFilter<ValidatorFilter<ArtistEditModel>>()
               .Produces<ApiResponse<ArtistItem>>();

            routeGroupBuilder.MapPut("/{id:Guid}", UpdateArtist)
                .WithName("Sửa tác giả")
                .AddEndpointFilter<ValidatorFilter<ArtistEditModel>>()
                .Produces<ApiResponse<string>>();


            routeGroupBuilder.MapDelete("/{id:Guid}", DeleteArtist)
                .WithName("DeleteArtist")
                .Produces<ApiResponse<string>>();

            
        }


        private static async Task<IResult> GetArtistDetails(
            Guid id,
            IArtistsRepository artistsRepository,
            IMapper mapper)
        {
            var artist = await artistsRepository.GetArtistByIdAsync(id, true);

            return artist == null
                     ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy tác giả có mã số {id}"))
                   : Results.Ok(ApiResponse.Success(mapper.Map<ArtistItem>(artist)));
        }

        private static async Task<IResult> UpdateArtist(
            Guid id,
            ArtistEditModel model,
            IArtistsRepository artistsRepository,
            IMapper mapper)
        {
            if (await artistsRepository.IsExistArtistSlugAsync(id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug {model.UrlSlug} đã có"));
            }
            var artist = mapper.Map<Artist>(model);
            artist.Id = id;

            return await artistsRepository.AddOrUpdateArtists(artist) != null
                ? Results.Ok(ApiResponse.Success("Tác giả đã được cập nhật", HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound));
        }

        private static async Task<IResult> addArtist(
        ArtistEditModel model,
        IArtistsRepository artistsRepository,
        IMapper mapper)
        {
            if (await artistsRepository.IsExistArtistSlugAsync(Guid.Empty, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict,
                    $"Slug {model.UrlSlug} đã được sử dụng"));
            }

            var artist = mapper.Map<Artist>(model);

            await artistsRepository.AddOrUpdateArtists(artist);

            return Results.Ok(ApiResponse.Success(
                mapper.Map<ArtistItem>(artist), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteArtist(
          Guid id,
          IArtistsRepository artistsRepository)
        {
            return await artistsRepository.DeleteArtists(id)
              ? Results.Ok(ApiResponse.Success("Đã xóa Artist", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không thể tìm thấy Tác giả/ ca sĩ có ID = {id}"));
        }

        private static async Task<IResult> GetAllArtist(
            IArtistsRepository artistsRepository,
            IMapper mapper)
        {
            var artists = await artistsRepository.GetArtistAsync();
            return Results.Ok(ApiResponse.Success(artists));
        }
    }
}