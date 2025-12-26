using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibrary.DataAccess.Entities;

namespace MovieLibrary.DataAccess.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Movie)
            .IsRequired();
        builder.Property(r => r.User)
            .IsRequired();
        builder.Property(r => r.Comment)
            .IsRequired();
        builder.Property(r => r.Rating)
            .IsRequired();
        builder.Property(r => r.ReviewDate)
            .IsRequired();
        builder
            .HasOne(r => r.User)
            .WithMany(r => r.Reviews);
        builder
            .HasOne(r => r.Movie)
            .WithMany(r => r.Reviews);
    }
}