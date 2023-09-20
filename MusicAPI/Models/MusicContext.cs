using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace MusicAPI.Models
{
    public class MusicContext : IdentityDbContext<User>
    {
        public MusicContext(DbContextOptions<MusicContext> option) : base(option)
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Song> Songs { get; set; }
        //public DbSet<SongGenres> SongGenres { get; set; }
        public DbSet<User> Users { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        //  {

        //base.OnModelCreating(builder);
        //// Bỏ tiền tố AspNet của các bảng: mặc định
        //foreach (var entityType in builder.Model.GetEntityTypes())
        //{
        //    var tableName = entityType.GetTableName();
        //    if (tableName.StartsWith("AspNet"))
        //    {
        //        entityType.SetTableName(tableName.Substring(6));
        //    }
        //}

        //builder.Entity<Song>()
        //    .HasRequired(s => s.Songer)
        //    .WithMany()
        //    .WillCascadeOnDelete(false);
        // }
    }
}
