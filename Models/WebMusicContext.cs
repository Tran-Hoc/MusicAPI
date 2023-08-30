using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicAPI.Models;

public partial class WebMusicContext : DbContext
{
    public WebMusicContext()
    {
    }

    public WebMusicContext(DbContextOptions<WebMusicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Composer> Composers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Singer> Singers { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<Songplaylist> Songplaylists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7MRL7G7\\SQLEXPRESS;Initial Catalog=Web_music;Integrated Security=True; TrustServerCertificate=True; User ID=sa;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.IdAlbum).HasName("PK__ALBUM__36B391E2632D3A4A");

            entity.ToTable("ALBUM");

            entity.Property(e => e.IdAlbum).HasColumnName("ID_ALBUM");
            entity.Property(e => e.IdSinger).HasColumnName("ID_SINGER");
            entity.Property(e => e.NameAlbum)
                .HasMaxLength(50)
                .HasColumnName("NAME_ALBUM");
            entity.Property(e => e.PictureAlbum).HasColumnName("PICTURE_ALBUM");

            entity.HasOne(d => d.IdSingerNavigation).WithMany(p => p.Albums)
                .HasForeignKey(d => d.IdSinger)
                .HasConstraintName("FK_ALBUMSINGER");
        });

        modelBuilder.Entity<Composer>(entity =>
        {
            entity.HasKey(e => e.IdComposer).HasName("PK__COMPOSER__9F2F3341BDD8B26E");

            entity.ToTable("COMPOSER");

            entity.Property(e => e.IdComposer).HasColumnName("ID_COMPOSER");
            entity.Property(e => e.NameComposer)
                .HasMaxLength(100)
                .HasColumnName("NAME_COMPOSER");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.IdGenre).HasName("PK__GENRES__6EB426B7F9E1A5AB");

            entity.ToTable("GENRES");

            entity.Property(e => e.IdGenre).HasColumnName("ID_GENRE");
            entity.Property(e => e.NameGenre)
                .HasMaxLength(50)
                .HasColumnName("NAME_GENRE");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.IdPlaylist).HasName("PK__PLAYLIST__3F0FA36C3C88F4D6");

            entity.ToTable("PLAYLIST");

            entity.Property(e => e.IdPlaylist).HasColumnName("ID_PLAYLIST");
            entity.Property(e => e.IdUser).HasColumnName("ID_USER");
            entity.Property(e => e.NamePlaylist)
                .HasMaxLength(200)
                .HasColumnName("NAME_PLAYLIST");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_PLAYLISTUSER");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdSong }).HasName("RATING_PK");

            entity.ToTable("RATING");

            entity.Property(e => e.IdUser).HasColumnName("ID_USER");
            entity.Property(e => e.IdSong).HasColumnName("ID_SONG");
            entity.Property(e => e.DateRate)
                .HasColumnType("date")
                .HasColumnName("DATE_RATE");
            entity.Property(e => e.Rating1).HasColumnName("RATING");
            entity.Property(e => e.Views).HasColumnName("VIEWS");
        });

        modelBuilder.Entity<Singer>(entity =>
        {
            entity.HasKey(e => e.IdSinger).HasName("PK__SINGER__2EBDD45A43B50C98");

            entity.ToTable("SINGER");

            entity.Property(e => e.IdSinger).HasColumnName("ID_SINGER");
            entity.Property(e => e.NameSinger)
                .HasMaxLength(50)
                .HasColumnName("NAME_SINGER");
            entity.Property(e => e.PictureSinger).HasColumnName("PICTURE_SINGER");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.IdSong).HasName("PK__SONG__F56BCAE34542023D");

            entity.ToTable("SONG");

            entity.Property(e => e.IdSong).HasColumnName("ID_SONG");
            entity.Property(e => e.IdAlbum).HasColumnName("ID_ALBUM");
            entity.Property(e => e.IdComposer).HasColumnName("ID_COMPOSER");
            entity.Property(e => e.IdGenre).HasColumnName("ID_GENRE");
            entity.Property(e => e.IdSinger).HasColumnName("ID_SINGER");
            entity.Property(e => e.NameSong)
                .HasMaxLength(50)
                .HasColumnName("NAME_SONG");
            entity.Property(e => e.PathSong).HasColumnName("PATH_SONG");
            entity.Property(e => e.PictureSong).HasColumnName("PICTURE_SONG");

            entity.HasOne(d => d.IdAlbumNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.IdAlbum)
                .HasConstraintName("FK_SONGALBUM");

            entity.HasOne(d => d.IdComposerNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.IdComposer)
                .HasConstraintName("FK_SONGCOMPOSER");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.IdGenre)
                .HasConstraintName("FK_SONGGENRE");

            entity.HasOne(d => d.IdSingerNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.IdSinger)
                .HasConstraintName("FK_SONGSINGER");
        });

        modelBuilder.Entity<Songplaylist>(entity =>
        {
            entity.HasKey(e => new { e.IdPlaylist, e.IdSong }).HasName("PK_KHOCHINH");

            entity.ToTable("SONGPLAYLIST");

            entity.Property(e => e.IdPlaylist).HasColumnName("ID_PLAYLIST");
            entity.Property(e => e.IdSong).HasColumnName("ID_SONG");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__USERS__95F484400F02C6CC");

            entity.ToTable("USERS");

            entity.Property(e => e.IdUser).HasColumnName("ID_USER");
            entity.Property(e => e.Avartar).HasColumnName("AVARTAR");
            entity.Property(e => e.Decentralization).HasColumnName("decentralization");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.NameUser)
                .HasMaxLength(50)
                .HasColumnName("NAME_USER");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
