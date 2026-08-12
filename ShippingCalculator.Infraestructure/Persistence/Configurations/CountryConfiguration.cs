using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client.NativeInterop;
using ShippingCalculator.Core.Entities;

namespace ShippingCalculator.Data.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //Nombre de la tabla
            builder.ToTable("Country");

            //Clave Primaria
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            //Mapeo y restricciones para Codigo de Pais
            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            //Mapeo y restricciones para nombre de pais
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            //Mapeo para la tarifa (Moneda / Decimal)
            builder.Property(c => c.RatePerKg)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasData(
                 new Country { Id = 1, Code = "IN", Name = "India", RatePerKg = 5.0m },
                 new Country { Id = 2, Code = "US", Name = "Estados Unidos", RatePerKg = 8.0m },
                 new Country { Id = 3, Code = "UK", Name = "Reino Unido", RatePerKg = 10.0m }
             );

        }
    }
    
}
