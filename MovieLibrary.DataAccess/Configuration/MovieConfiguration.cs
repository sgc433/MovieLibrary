using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibrary.Core.Models;
using MovieLibrary.DataAccess.Entities;

namespace MovieLibrary.DataAccess.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
{
    public void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.HasKey(m => m.Id);
        builder
            .HasMany(m => m.Reviews)
            .WithOne(m => m.Movie);
        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(Movie.MAX_TITLE_LENGTH);
        builder.Property(m => m.Description)
            .IsRequired();
        builder.Property(m => m.ReleaseDate)
            .IsRequired();
        builder.Property(m => m.Author)
            .IsRequired();
        builder.Property(m => m.Genre)
            .IsRequired();
        builder.Property(m => m.Duration)
            .IsRequired();
        builder.Property(m => m.Rating)
            .HasMaxLength(Movie.MAX_RATING_VALUE)
            .IsRequired();
    }
}