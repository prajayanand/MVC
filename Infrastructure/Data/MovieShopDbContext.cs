using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class MovieShopDbContext : DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
    {
        
    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(ConfigureMovie);
        modelBuilder.Entity<Trailer>(ConfigureTrailer);
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
        modelBuilder.Entity<Cast>(ConfigureCast);
        modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
    }

    private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> modelBuilder)
    {
        modelBuilder.ToTable("MovieCasts");
        modelBuilder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character });
        modelBuilder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.MovieId);
        modelBuilder.HasOne(mc => mc.Cast).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.CastId);
        
    }
    private void ConfigureCast(EntityTypeBuilder<Cast> modelBuilder)
    {
        modelBuilder.Property(c => c.Name).HasMaxLength(128);
        modelBuilder.Property(c => c.Gender).HasMaxLength(16);
        modelBuilder.Property(c => c.ProfilePath).HasMaxLength(2084);
        modelBuilder.Property(c => c.TmdbUrl).HasMaxLength(2084);
    }

    private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> modelBuilder)
    {
        modelBuilder.ToTable("MovieGenre");
        modelBuilder.HasKey(mg => new { mg.MovieId, mg.GenreId });
        modelBuilder.HasOne(m => m.Movie).WithMany(m => m.Genres).HasForeignKey(m => m.MovieId);
        modelBuilder.HasOne(m => m.Genre).WithMany(m => m.Movies).HasForeignKey(m => m.GenreId);
    }
    private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
    {
        builder.ToTable("Trailer");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TrailerUrl).HasMaxLength(2048);
        builder.Property(t => t.Name).HasMaxLength(256);

    }

    private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
        //fluent API way
        builder.ToTable("Movie");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasMaxLength(256);
        builder.Property(m => m.Overview).HasMaxLength(4096);
        builder.Property(m => m.Tagline).HasMaxLength(512);
        builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
        builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
        builder.Property(m => m.PosterUrl).HasMaxLength(2084);
        builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
        builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
        builder.Property(m => m.UpdatedBy).HasMaxLength(512);
        builder.Property(m => m.CreatedBy).HasMaxLength(512);

        builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
        builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
        builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);

        builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");

        builder.Ignore(m => m.Rating);
        
    }
}
 