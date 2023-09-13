using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBlog.Core.Models;

namespace NetBlog.Core.ModelConfigurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Email, "IX_Users_Email")
            .IsUnique();

        builder.HasIndex(x => x.NormalizedEmail, "IX_Users_NormalizedEmail")
            .IsUnique();

        builder.HasMany(x => x.OwnedPosts)
            .WithOne(x => x.PostOwner)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.EditedPosts)
            .WithOne(x => x.Editor)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.EditorId);

        builder.HasMany(x => x.UserRoles)
            .WithOne(x => x.User)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
