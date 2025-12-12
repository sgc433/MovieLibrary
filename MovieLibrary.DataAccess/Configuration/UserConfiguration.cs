using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibrary.DataAccess.Entities;

namespace MovieLibrary.DataAccess.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property( u=> u.Email)
            .IsRequired();
        builder.Property(u => u.Username)
            .IsRequired();
        builder.Property(u => u.PasswordHash)
            .IsRequired();
    }
}