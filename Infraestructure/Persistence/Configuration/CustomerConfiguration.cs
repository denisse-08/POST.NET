
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Customers;
using Domain.ValueObjects;


namespace Infraestructure.Persistence.Configuration;
public class CustomerConfiguration : IEntityTypeConfiguration<Customers>
{
    public void Configure(EntityTypeBuilder<Customers> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
           customersId => customersId.value,
           value => new CustomersId(value));
        builder.Property(c => c.Name).HasMaxLength(50);
        builder.Property(c => c.LastName).HasMaxLength(50);
        builder.Property(c => c.FullName).HasMaxLength(50);
        builder.Property(c => c.Email).HasMaxLength(50);
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.PhoneNumber).HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!)
            .HasMaxLength(12);
        builder.OwnsOne(c => c.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country).HasMaxLength(30);
            addressBuilder.Property(a => a.Line1).HasMaxLength(20);
            addressBuilder.Property(a => a.Line2).HasMaxLength(30).IsRequired(false);
            addressBuilder.Property(a => a.City).HasMaxLength(30);
            addressBuilder.Property(a => a.State).HasMaxLength(30);
            addressBuilder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired(false);
        });

        builder.Property(c => c.Active).IsRequired(true);
    }
}