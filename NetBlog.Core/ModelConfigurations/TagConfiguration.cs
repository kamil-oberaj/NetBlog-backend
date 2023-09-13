using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBlog.Core.ConstValues;
using NetBlog.Core.Models;

namespace NetBlog.Core.ModelConfigurations;

public sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.FullName)
            .HasMaxLength(CoreTagConstants.TagFullNameMaxLength);

        builder.Property(x => x.ShortName)
            .HasMaxLength(CoreTagConstants.TagShortNameMaxLength);

        builder.HasMany(x => x.PostTags)
            .WithOne(x => x.Tag)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
