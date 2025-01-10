using Luderia.Domain.Contexts.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luderia.Infrastructure.Contexts.Orders.Database;
internal class OrderDbConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasIndex(b => b.Id);

        builder.Property(b => b.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(b => b.CustomerId)
            .IsRequired();

        builder.Property(b => b.Status)
            .IsRequired()
            .HasConversion(x => Enum.GetName(x), x => Enum.Parse<OrderStatus>(x!));

        builder.Property(b => b.GameItemId)
            .IsRequired()
            .HasColumnType("jsonb");

        builder.Property(b => b.ReturnDate)
            .IsRequired();
    }
}
