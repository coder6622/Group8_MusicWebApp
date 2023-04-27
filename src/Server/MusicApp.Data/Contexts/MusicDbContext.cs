using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Entities;
using MusicApp.Data.Mappings;

namespace MusicApp.Data.Contexts
{
  public class MusicDbContext : DbContext
  {
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<GroupTag> GroupTags { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserSong> UserSongs { get; set; }


    public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=MusicWeb;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupTagMap).Assembly);
    }
  }
}
