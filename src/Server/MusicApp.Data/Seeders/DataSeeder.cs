using Microsoft.AspNetCore.Identity;
using MusicApp.Core.Constants;
using MusicApp.Core.Entities;
using MusicApp.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.Seeders
{
  public class DataSeeder : IDataSeeder
  {
    private readonly MusicDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public DataSeeder(
      IPasswordHasher<User> passwordHasher,
      MusicDbContext dbContext)
    {
      _passwordHasher = passwordHasher;
      _dbContext = dbContext;
    }

    public void Intitalize()
    {
      _dbContext.Database.EnsureCreated();

      if (_dbContext.Set<Song>().Any())
      {
        return;
      }

      var categories = AddCategories();
      var groupTags = AddGroupTags();

      var tags = AddTags(groupTags);
      var artists = AddArtists();

      var roles = AddRoles();
      var users = AddUsers(roles);

      var songs = AddSongs(categories, artists, tags);
      var userSongs = AddUserSongs(users, songs);
      var playlists = AddPlaylists(users, songs, artists);
    }

    private IList<Category> AddCategories()
    {
      var categories = new List<Category>()
        {
          new (){
            Name= "Nhạc Việt",
            UrlSlug = "nhac-viet",
            Description="Nhạc Việt",
            Enable = true
          },
          new (){
            Name= "Nhạc Hàn",
            UrlSlug = "nhac-han",
            Description="Nhạc Hàn",
            Enable = true
          },
          new (){
            Name= "Piano",
            UrlSlug = "piano",
            Description="piano",
            Enable = true
          },
          new (){
            Name= "Nhạc phim",
            UrlSlug = "nhac-phim",
            Description="Nhạc phim",
            Enable = true
          },
          new (){
            Name= "Indie",
            UrlSlug = "indie",
            Description="indie",
            Enable = true
          },
          new (){
            Name= "Acoustic",
            UrlSlug = "acoustic",
            Description="acoustic",
            Enable = true
          },
        };


      var categoriesToAdd = new List<Category>();

      foreach (var category in categories)
      {
        if (!_dbContext.Categories.Any(c => c.UrlSlug == category.UrlSlug))
        {
          categoriesToAdd.Add(category);
        }
      }

      _dbContext.AddRange(categoriesToAdd);
      _dbContext.SaveChanges();

      return categories;
    }

    private IList<GroupTag> AddGroupTags()
    {
      var groupTags = new List<GroupTag>() {
        new(){ Name="Việt Nam", UrlSlug = "viet-nam", Enable=true},
        new(){ Name="Châu Mỹ", UrlSlug = "chau-my", Enable=true},
        new(){ Name="Tâm trạng", UrlSlug = "tam-trang", Enable= true},
        new(){ Name="Khung cảnh", UrlSlug = "khung-canh", Enable = true},
        new(){ Name="Karaoke", UrlSlug = "karaoke", Enable = true},
      };


      var groupTagsToAdd = new List<GroupTag>();

      foreach (var groupTag in groupTags)
      {
        if (!_dbContext.GroupTags.Any(c => c.UrlSlug.Equals(groupTag.UrlSlug)))
        {
          groupTagsToAdd.Add(groupTag);
        }
      }

      _dbContext.AddRange(groupTagsToAdd);
      _dbContext.SaveChanges();

      return groupTags;
    }


    private IList<Tag> AddTags(IList<GroupTag> groupTags)
    {
      var tags = new List<Tag>()
      {
        new()
        {
          Name = "Hưng phấn",
          UrlSlug = "hung-phan",
          Description = "Hưng phấn",
          Enable = true,
          GroupTag = groupTags[2]
        },
        new()
        {
          Name = "Nhạy cảm",
          UrlSlug = "nhay-cam",
          Description = "Nhạy cảm",
          Enable = true,
          GroupTag = groupTags[2]
        },
        new()
        {
          Name = "Buồn",
          UrlSlug = "buon",
          Description = "Buồn",
          Enable = true,
          GroupTagId = groupTags[2].Id,
        },
        new()
        {
          Name = "Pop",
          UrlSlug = "pop-viet-nam",
          Description = "Nhạc Pop",
          Enable = true,
          GroupTag = groupTags[0]
        },
        new()
        {
          Name = "Trữ tình",
          UrlSlug = "tru-tinh-viet",
          Description = "Trữ tình",
          Enable = true,
          GroupTag = groupTags[0]
        },
        new()
        {
          Name = "Nhạc trẻ",
          UrlSlug = "nhac-tre-viet-nam",
          Description = "Nhạc trẻ",
          Enable = true,
          GroupTag = groupTags[0]
        }

      };

      var tagsToAdd = new List<Tag>();

      foreach (var tag in tags)
      {
        if (!_dbContext.Tags.Any(c => c.UrlSlug == tag.UrlSlug))
        {
          tagsToAdd.Add(tag);
        }
      }

      _dbContext.AddRange(tagsToAdd);
      _dbContext.SaveChanges();

      return tags;
    }


    private IList<Artist> AddArtists()
    {
      var artists = new List<Artist>()
      {
        new()
        {
          FullName="Miley Cyrus",
          UrlSlug="miley-cyrus",
          DayOfBirth= new DateTime(1999,9,30),
          Gender= (int) Gender.Female,
          Nation="United States",
          Information="Đang cập nhật",
          Enable = true,
        },
        new()
        {
          FullName="Ngô Kiến Huy",
          UrlSlug="ngo-kien-huy",
          DayOfBirth= new DateTime(1988,06,29),
          Gender= (int) Gender.Male,
          Nation="Việt Nam",
          Information="Đang cập nhật",
          Enable = true,
        },
        new()
        {
          FullName="Sơn Tùng Mtp",
          UrlSlug="son-tung-mtp",
          DayOfBirth= new DateTime(1994,07,05),
          Gender= (int) Gender.Male,
          Nation="Việt Nam",
          Information="Đang cập nhật",
          Enable = true,
        }
  };

      var artistsToAdd = new List<Artist>();

      foreach (var artist in artists)
      {
        if (!_dbContext.Artists.Any(c => c.UrlSlug == artist.UrlSlug))
        {
          artistsToAdd.Add(artist);
        }
      }

      _dbContext.AddRange(artistsToAdd);
      _dbContext.SaveChanges();

      return artists;
    }

    private IList<Song> AddSongs(
      IList<Category> categories,
      IList<Artist> artists,
      IList<Tag> tags)
    {
      var songs = new List<Song>()
      {
        new()
        {
          Name="Weekend",
          UrlSlug ="week-end",
          Duration= 107,
          Meta="week-end",
          HasLyrics=true,
          LrcUrl="/music/lrc/BlackM-Week-end",
          SongUrl="/music/BlackM-Week-end",
          TotalPlayCount=0,
          TotalLike=0,
          IsPublic= true,
          CreatedDate=DateTime.Now,
          Enable = true,
          Category= categories[0],
          Artists= new List<Artist>(){artists[0]},
          Tags = new List<Tag>(){ tags[0], tags[5] },
        },
        new()
        {
          Name="Life Goes On",
          UrlSlug ="life-goes-on",
          Duration= 107,
          Meta="life goes on",
          HasLyrics=true,
          LrcUrl="/music/lrc/BTS-LifeGoesOn",
          SongUrl="/music/BTS-LifeGoesOn",
          TotalPlayCount=0,
          TotalLike=0,
          IsPublic= true,
          CreatedDate=DateTime.Now,
          Enable = true,
          Category= categories[0],
          Artists= new List<Artist>(){artists[0], artists[1] },
          Tags = new List<Tag>(){ tags[0]}
        },
        new()
        {
          Name="Spring Day",
          UrlSlug ="spring-day",
          Duration= 107,
          Meta="spring-day",
          HasLyrics=true,
          LrcUrl="/music/lrc/BTS-SpringDay",
          SongUrl="/music/BTS-SpringDay",
          TotalPlayCount=0,
          TotalLike=0,
          IsPublic= true,
          CreatedDate=DateTime.Now,
          Enable = true,
          Category= categories[2],
          Artists= new List<Artist>(){artists[0], artists[2] },
          Tags = new List<Tag>(){ tags[1], tags[3] }
        }
      };

      var songsToAdd = new List<Song>();

      foreach (var song in songs)
      {
        if (!_dbContext.Songs.Any(c => c.UrlSlug == song.UrlSlug))
        {
          songsToAdd.Add(song);
        }
      }

      _dbContext.AddRange(songsToAdd);
      _dbContext.SaveChanges();

      return songs;
    }

    private IList<Role> AddRoles()
    {
      var roles = new List<Role>() {
        new (){
          Name = "Administrator",
          NormalizedName= "Administrator".ToUpper(),
          ConcurrencyStamp = Guid.NewGuid().ToString("D")
        },
        new (){
          Name = "User",
          NormalizedName= "User".ToUpper(),
          ConcurrencyStamp = Guid.NewGuid().ToString("D")
        },
        new (){
          Name = "UserGole",
          NormalizedName= "UserGold".ToUpper(),
          ConcurrencyStamp = Guid.NewGuid().ToString("D")
        },
      };

      var rolesToAdd = new List<Role>();

      foreach (var role in roles)
      {
        if (!_dbContext.Roles.Any(r => r.Name == role.Name))
        {
          rolesToAdd.Add(role);
        }
      }

      _dbContext.AddRange(rolesToAdd);
      _dbContext.SaveChanges();


      return roles;
    }


    private IList<User> AddUsers(IList<Role> roles)
    {

      var admin = new User()
      {
        FullName = "admin",
        UserName = "admin",
        Email = "2014469@dlu.edu.vn",
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString("D")
      };


      var admin1 = new User()
      {
        FullName = "admin 1",
        UserName = "admin1",
        Email = "test@gmail.com",
        EmailConfirmed = true,
        SecurityStamp = Guid.NewGuid().ToString("D"),
      };

      var users = new List<User>() { admin, admin1 };

      var usersToAdd = new List<User>();

      foreach (var user in users)
      {
        if (!_dbContext.Users.Any(u => u.UserName == user.UserName))
        {
          user.PasswordHash = _passwordHasher.HashPassword(user, "admin123");
          _dbContext.Users.Add(user);

          _dbContext.UserRoles
            .AddRange(roles.Select(x => new UserRole()
            {
              Account = user,
              Role = x
            }));
        }
      }

      _dbContext.SaveChanges();
      return users;
    }

    private IList<UserSong> AddUserSongs(
      IList<User> users,
      IList<Song> songs)
    {
      var userSongs = new List<UserSong>() {
        new()
        {
          User = users[0],
          Song = songs[0],
          CreatedDate = DateTime.Now,
          IsLike = true,
          PlayCount = 1,
        },
        new()
        {
          User = users[0],
          Song = songs[1],
          CreatedDate = DateTime.Now,
          IsLike = false,
          PlayCount = 10,
        },
        new()
        {
          User = users[1],
          Song = songs[0],
          CreatedDate = DateTime.Now,
          IsLike = false,
          PlayCount = 10,
        },
        new()
        {
          User = users[1],
          Song = songs[0],
          CreatedDate = DateTime.Now,
          IsLike = true,
          PlayCount = 2,
        },
      };

      var userSongsToAdd = new List<UserSong>();

      foreach (var userSong in userSongs)
      {
        if (!_dbContext.UserSongs.Any(us => us.UserId == userSong.UserId && us.SongId == userSong.SongId))
        {
          userSongsToAdd.Add(userSong);
        }
      }

      _dbContext.AddRange(userSongsToAdd);
      _dbContext.SaveChanges();



      return userSongs;
    }

    private IList<Playlist> AddPlaylists(
      IList<User> users,
      IList<Song> songs,
      IList<Artist> artists)
    {
      var playlists = new List<Playlist>()
      {
        new()
        {
          Name="Playlist 1",
          UrlSlug="playlist-1",
          IsPublic = true,
          CreatedDate=DateTime.Now,
          Enable = true,
          User = users[0],
          Artists= new []{artists[0], artists[1] },
          Songs = new [] {songs[0], songs[1] },
          Tags = songs[0].Tags.Concat(songs[1].Tags).ToList()
        },
        new()
        {
          Name="Playlist 2",
          UrlSlug="playlist-2",
          IsPublic = true,
          CreatedDate=DateTime.Now,
          Enable = true,
          User = users[1],
          Artists= new []{artists[0] },
          Songs = new [] {songs[0], songs[2] },
          Tags = songs[0].Tags.Concat(songs[2].Tags).ToList()
        }
      };

      var playlistsToAdd = new List<Playlist>();

      foreach (var playlist in playlists)
      {
        if (!_dbContext.Playlists.Any(p => p.UrlSlug == playlist.UrlSlug))
        {
          playlistsToAdd.Add(playlist);
        }
      }

      _dbContext.AddRange(playlistsToAdd);
      _dbContext.SaveChanges();



      return playlists;
    }
  }
}
