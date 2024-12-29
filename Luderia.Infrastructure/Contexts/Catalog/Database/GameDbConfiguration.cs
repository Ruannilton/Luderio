using Luderia.Domain.Contexts.Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace Luderia.Infrastructure.Contexts.Catalog.Database;

internal class GameDbConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.BGGId);

        builder.Property(x => x.BGGId)
        .IsRequired();

        builder.Property(x => x.Name)
        .IsRequired()
        .HasMaxLength(64);

        builder.Property(x => x.Description)
        .IsRequired()
        .HasMaxLength(256);

        builder
            .HasMany(x => x.Types)
            .WithMany(x => x.Games);

        builder.ToTable("Games");
    }
}
