﻿using Carter;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Entities;
using MusicApp.Data.Contexts;
using MusicApp.Data.Seeders;
using MusicApp.Services.Musics;
using MusicApp.Services.Musics.Artists;
using MusicApp.Services.Musics.GroupTags;
using MusicApp.Services.Musics.Songs;
using MusicApp.Services.Musics.Tags;
using MusicApp.WebApi.Filters;

namespace MusicApp.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {

        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddCarter();
            builder.Services.AddMemoryCache();
            builder.Services.AddDbContext<MusicDbContext>(options =>
              options.UseSqlServer(
                builder.Configuration
                  .GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            builder.Services.AddScoped<IDataSeeder, DataSeeder>();
            builder.Services.AddScoped<ISongRepository, SongRespository>();

            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();

            builder.Services.AddScoped<IArtistsRepository, ArtistsRepository>();

            builder.Services.AddScoped<ITagsRepository, TagsRepository>();

            builder.Services.AddScoped<IGroupTagsRepository, GroupTagsRepository>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureCors(
         this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MusicApp", policyBuilder =>
                    policyBuilder
                      .AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod());
            });
            return builder;
        }

        public static WebApplicationBuilder ConfigureSwaggerOpenApi(
          this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.ParameterFilter<GuidParamaterFilter>();
            });

            return builder;
        }

        public static WebApplication SetupRequestPipeline(
          this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseCors("MusicApp");

            return app;
        }

        public static IApplicationBuilder UseDataSeeder(
          this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            try
            {
                scope.ServiceProvider
                  .GetRequiredService<IDataSeeder>()
                  .Intitalize();
            }
            catch (Exception ex)
            {
                scope.ServiceProvider
                    .GetRequiredService<ILogger<Program>>()
                    .LogError(ex, "Could not insert data into database");
            }
            return app;
        }
    }
}