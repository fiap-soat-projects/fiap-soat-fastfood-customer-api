using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Sql.Configurations;

[ExcludeFromCodeCoverage]
internal class CustomerSqlEntityConfiguration : IEntityTypeConfiguration<CustomerSql>
{
    public void Configure(EntityTypeBuilder<CustomerSql> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id).HasColumnName("id");
        builder.Property(customer => customer.CreatedAt).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(customer => customer.UpdatedAt).IsRequired(false).HasColumnName("updated_at");
        builder.Property(customer => customer.Name).IsRequired(true).HasMaxLength(200).HasColumnName("name");
        builder.Property(customer => customer.Cpf).IsRequired(true).HasMaxLength(30).HasColumnName("cpf");
        builder.Property(customer => customer.Email).IsRequired(false).HasMaxLength(200).HasColumnName("email");

        builder.HasIndex(customer => customer.Cpf).IsUnique();
    }
}
