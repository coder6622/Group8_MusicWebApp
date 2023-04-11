using MapsterMapper;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using MusicApp.Core.Collections;
using MusicApp.Services.Musics.Artists;
using MusicApp.WebApi.Models;
using MusicApp.WebApi.Models.Artist;
using MusicApp.Core.DTO;
using Carter;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using MusicApp.Core.Entities;
using MusicApp.WebApi.Models.Tags;
using MusicApp.Services.Musics.Tags;
using MusicApp.WebApi.Filters;

namespace MusicApp.WebApi.Endpoints
{
    public class TagEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/tags");

            routeGroupBuilder.MapPost("/", AddTag)
            .WithName("AddTags")
            .AddEndpointFilter<ValidatorFilter<TagEditModel>>()
            .Produces(401)
            .Produces<ApiResponse<TagsItem>>();


            
            routeGroupBuilder.MapPut("/{id:Guid}", UpdateTag)
            .WithName("UpdateTag")
            .AddEndpointFilter<ValidatorFilter<TagEditModel>>()
            .Produces(401)
            .Produces<ApiResponse<string>>();

            

            routeGroupBuilder.MapDelete("/{id:Guid}", DeleteTag)
                .WithName("DeleteTags")
                .Produces(401)
                .Produces<ApiResponse<string>>();

            
        }
        private static async Task<IResult> AddTag(
        TagEditModel model,
        ITagsRepository TagsRepository,
        IMapper mapper)
        {
            if (await TagsRepository.IsTagSlugExistedAsync(Guid.Empty, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict,
                    $"Slug {model.UrlSlug} đã được sử dụng"));
            }

            var tag = mapper.Map<Tag>(model);

            await TagsRepository.AddOrUpdateTag(tag);

            return Results.Ok(ApiResponse.Success(
                mapper.Map<TagsItem>(tag), HttpStatusCode.Created));
        }
        private static async Task<IResult> UpdateTag(
        Guid id,
        TagEditModel model,
        ITagsRepository TagsRepository,
        IMapper mapper)
        {
            if (await TagsRepository.IsTagSlugExistedAsync(id, model.UrlSlug))
            {
                return Results.Ok(ApiResponse.Fail(
                    HttpStatusCode.Conflict,
                    $"Slug {model.UrlSlug} đã được sử dụng"));
            }

            var tag = mapper.Map<Tag>(model);
            tag.Id = id;

            return await TagsRepository.AddOrUpdateTag(tag) != null
                ? Results.Ok(ApiResponse.Success(HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, "Không tìm thấy Tag"));
        }
        private static async Task<IResult> DeleteTag(
        Guid id,
        ITagsRepository TagsRepository)
        {
            return await TagsRepository.DeleteTagById(id)
                ? Results.Ok(ApiResponse.Success("Đã xóa Tag", HttpStatusCode.NoContent))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy Tag với id: `{id}`"));
        }
    }
}
