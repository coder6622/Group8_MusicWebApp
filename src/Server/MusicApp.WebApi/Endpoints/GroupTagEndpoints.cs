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

namespace MusicApp.WebApi.Endpoints
{
    public class GroupTagEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/GroupTags");
        }
    }
}
