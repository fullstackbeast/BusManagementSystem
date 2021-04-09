using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportSystem.Core.Entities;

namespace TransportSystem.Data.EntityConfigurations
{
    public class PassengerEntityTypeConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("passenger");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .HasColumnType("varchar(50)")
                .IsRequired();



            builder.Property(p => p.LastName)
                    .HasColumnType("varchar(50)")
                    .IsRequired();


            builder.Property(p => p.PhoneNumber)
                .HasColumnType("varchar(50)");


            builder.Property(p => p.Email)
            .HasColumnType("varchar(50)")
            .IsRequired();
            builder.HasIndex(p => p.Email)
                  .IsUnique();


            builder.Property(p => p.Address)
           .HasColumnType("varchar(255)");

            builder.Property(p => p.NextOfKin)
           .HasColumnType("varchar(50)");


            builder.Property(p => p.PasswordHash)
                .HasColumnType("varchar(750)")
                .IsRequired();

            builder.Property(p => p.HashSalt)
                .HasColumnType("varchar(700)")
                .IsRequired();


            builder.Property(p => p.RowVersion)
                .IsRowVersion();




            //builder.HasIndex(b => b.BusNumber)
            //      .IsUnique();



            //builder.HasMany(t => t.Trips)
            //  .WithOne(b => b.Bus)
            //  .HasForeignKey(b => b.BusId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}