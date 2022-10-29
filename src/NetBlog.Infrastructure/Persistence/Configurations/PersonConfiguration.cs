using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBlog.Domain.Entities;

namespace NetBlog.Infrastructure.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.FirstName)
            .HasMaxLength(64);

        builder.Property(x => x.LastName)
            .HasMaxLength(64);

        builder.Property(x => x.UserName)
            .HasMaxLength(50);
    }
}