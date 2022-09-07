using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC.Codeflix.Catalog.Infra.Data.EF;

internal class CategoryRepositoryConfiguration : IEntityTypeConfiguration<CategoryModelEF>
{
    public void Configure(EntityTypeBuilder<CategoryModelEF> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(category => category.Name).HasMaxLength(255);
        builder.Property(category => category.Description).HasMaxLength(10_000);
    }
}