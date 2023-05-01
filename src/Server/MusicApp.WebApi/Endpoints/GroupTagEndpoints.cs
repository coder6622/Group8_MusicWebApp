using MapsterMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MusicApp.Services.Musics.GroupTags;
using MusicApp.WebApi.Models;
using MusicApp.Core.DTO;
using Carter;
using MusicApp.Core.Entities;
using MusicApp.WebApi.Models.GroupTag;
using MusicApp.WebApi.Filters;
using System.Xml.Serialization;
using MusicApp.Services.Musics.GroupTags;
using System.Text.RegularExpressions;
using MusicApp.WebApi.Models.Tags;

namespace MusicApp.WebApi.Endpoints
{
    public class GroupTagEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/GroupTags");

            routeGroupBuilder.MapPost("/", AddGrTag)
                .WithName("addGrTag")
                .AddEndpointFilter<ValidatorFilter<GroupTagEditModel>>()
                .Produces(401)
                .Produces<ApiResponse<GrTagsItem>>();

            routeGroupBuilder.MapPut("/{id:Guid}", UpdateGrTag)
                .WithName("UpdateGrTag")
                .AddEndpointFilter<ValidatorFilter<GroupTagEditModel>>()
                .Produces(401)
                .Produces<ApiResponse<string>>();

            routeGroupBuilder.MapDelete("/{id:Guid}", DeleteGrTag)
                .WithName("DeleteGrTags")
                .Produces(401)
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> AddGrTag(
            GroupTagEditModel model,
            IGroupTagsRepository GrTagsRepository,
            IMapper mapper)
        {
            if (await GrTagsRepository.IsGrTagSlugExistedAsync(Guid.Empty, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict,
                    $"Slug {model.UrlSlug} đã được sử dụng"));
            }

            var grtag = mapper.Map<GroupTag>(model);

            await GrTagsRepository.AddOrUpdateGrTag(grtag);

            return Results.Ok(ApiResponse.Success(
                mapper.Map<GrTagsItem>(grtag), HttpStatusCode.Created));
        }

        private static async Task<IResult> UpdateGrTag(
            Guid id,
            GroupTagEditModel model,
            IGroupTagsRepository groupTagsRepository,
            IMapper mapper)
        {
            if (await groupTagsRepository.IsGrTagSlugExistedAsync(id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict,
                    $"Slug {model.UrlSlug} đã được sử dụng"));
            }

            var grtag = mapper.Map<GroupTag>(model);
            grtag.Id = id;

            return await groupTagsRepository.AddOrUpdateGrTag(grtag) != null
                ? Results.Ok(ApiResponse.Success(HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy GrTag"));
        }

        private static async Task<IResult> DeleteGrTag(
            Guid id,
            IGroupTagsRepository groupTagsRepository)
        {
            return await groupTagsRepository.DeleteGrTagById(id)
                ? Results.Ok(ApiResponse.Success("Đã xóa GrTag", HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy GrTag với id: `{id}`"));
        }
    }
}
