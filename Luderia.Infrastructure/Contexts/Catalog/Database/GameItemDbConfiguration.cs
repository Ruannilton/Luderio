using Luderia.Domain.Contexts.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Luderia.Infrastructure.Contexts.Catalog.Database;

internal class GameItemDbConfiguration : IEntityTypeConfiguration<GameItem>
{
    public void Configure(EntityTypeBuilder<GameItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.GameId)
            .IsRequired();

        builder.Property(x => x.Available)
            .IsRequired();


        builder.Property(x => x.Damages).HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
                v => JsonSerializer.Deserialize<List<Damage>>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }))
            .HasColumnType("jsonb");

        builder.HasOne<Game>()
            .WithMany()
            .HasForeignKey(x => x.GameId);

        builder.ToTable("GameItems");
    }
}
