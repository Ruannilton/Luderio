using Luderia.Domain.Contexts.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Luderia.Infrastructure.Contexts.Customers.Database;
internal class CustomerDbConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(x => x.Cpf)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(x => x.Active)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.OwnsOne(x => x.Address, addressBuilder =>
        {
            addressBuilder.Property(x => x.Street)
                .HasMaxLength(64)
                .IsRequired();

            addressBuilder.Property(x => x.Number)
                .HasMaxLength(4)
                .IsRequired();

            addressBuilder.Property(x => x.Complement)
                .HasMaxLength(64);

            addressBuilder.Property(x => x.Neighborhood)
                .HasMaxLength(64)
                .IsRequired();

            addressBuilder.Property(x => x.City)
                .HasMaxLength(64)
                .IsRequired();

            addressBuilder.Property(x => x.State)
                .HasConversion(x => x.ToString(), x => Enum.Parse<States>(x))
                .HasMaxLength(2)
                .IsRequired();

            addressBuilder.Property(x => x.Country)
                .HasMaxLength(64)
                .IsRequired();
        });
    }
}
