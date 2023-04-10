﻿using MapsterMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MusicApp.Services.Musics.Artists;
using MusicApp.WebApi.Models;
using MusicApp.Core.DTO;

namespace MusicApp.WebApi.Endpoints
{
  public static class ArtistEndpoints
    {
        public static WebApplication MapArtistEndpoints(
            this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/artist");
            
            routeGroupBuilder.MapGet("/{id:Guid}", GetArtistDetails)
                .WithName("GetArtistByID")
                .Produces<ApiResponse<ArtistItem>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteArtist)
                .WithName("DeleteArtist")
                .Produces<ApiResponse<Guid>>();

            return app;
        }

        //private static async Task<IResult> GetArtist(
        //    [AsParameters] ArtistFilterModel model,
        //    IArtistsRepository artistsRepositor)
        //{
        //    var artists = await PaginationResult<>
        //}

        private static async Task<IResult> GetArtistDetails(
            Guid id,
            [FromBody] IArtistsRepository artistsRepository,
            IMapper mapper)
        {
            var artist = await artistsRepository.GetCachedArtistByIDAsync(id);

            return artist == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy tác giả nào có ID = {id}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<ArtistItem>(artist)));
        }

        private static async Task<IResult> DeleteArtist(
          Guid id,
          [FromBody] IArtistsRepository artistsRepository)
        {
            return await artistsRepository.DeleteArtists(id)
              ? Results.Ok(ApiResponse.Success("Đã xóa Artist", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không thể tìm thấy Tác giả/ ca sĩ có ID = {id}"));
        }

        //private static async Task<IResult> GetAllArtist(
        //    IArtistsRepository artistsRepository)
        //{
        //    return
        //}
    }
}
