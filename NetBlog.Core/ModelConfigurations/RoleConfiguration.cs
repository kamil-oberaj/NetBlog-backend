using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBlog.Core.ConstValues;
using NetBlog.Core.Models;

namespace NetBlog.Core.ModelConfigurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Name, "IX_Role_Name")
            .IsUnique();

        builder.HasIndex(x => x.NormalizedName, "IX_Role_NormalizedName")
            .IsUnique();

        builder.Property(x => x.Name)
            .HasMaxLength(CoreRoleConstants.NameMaxLength)
            .IsRequired();

        builder.HasMany(x => x.UserRoles)
            .WithOne(x => x.Role)
            .HasPrincipalKey(x => x.Id)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
