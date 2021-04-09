using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportSystem.Core.Entities;

namespace TransportSystem.Data.EntityConfigurations
{
    public class BusEntityTypeConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.ToTable("buses");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.BusNumber)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.HasIndex(b => b.BusNumber)
                   .IsUnique();


            builder.Property(b => b.Capacity)
                    .HasColumnType("(50)")
                    .IsRequired();


            builder.Property(b => b.Model)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(b => b.Speed)
            .HasColumnType("varchar(50)");


            builder.Property(b => b.RowVersion)
                .IsRowVersion();



            builder.HasMany(t => t.Trips)
              .WithOne(b => b.Bus)
              .HasForeignKey(b => b.BusId).OnDelete(DeleteBehavior.Restrict);



        }
    }
}
