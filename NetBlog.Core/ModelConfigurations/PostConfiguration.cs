using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBlog.Core.ConstValues;
using NetBlog.Core.Models;

namespace NetBlog.Core.ModelConfigurations;

public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(CorePostConstants.AllowedNameLength);
        builder.HasIndex(x => x.Name, "IX_Posts_Name")
            .IsUnique();

        builder.Property(x => x.Content)
            .HasMaxLength(CorePostConstants.AllowedContentLength);

        builder.HasOne(x => x.PostOwner)
            .WithMany(x => x.OwnedPosts)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.CreatedBy);

        builder.HasMany(x => x.PostEditors)
            .WithOne(x => x.Post)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.PostId);

        builder.HasMany(x => x.PostTags)
            .WithOne(x => x.Post)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
