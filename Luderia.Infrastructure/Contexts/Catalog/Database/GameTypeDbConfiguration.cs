using Luderia.Domain.Contexts.Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Database;

internal class GameTypeDbConfiguration : IEntityTypeConfiguration<GameType>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GameType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value)
              .IsRequired()
              .HasMaxLength(100);

        builder.ToTable("GameTypes");
    }
}