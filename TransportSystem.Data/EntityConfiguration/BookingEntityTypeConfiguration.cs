using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportSystem.Core.Entities;

namespace TransportSystem.Data.EntityConfigurations
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");

            builder.HasKey(b => b.Id);


            builder.Property(b => b.BookingNumber)
                .HasColumnType("varchar(50)")
                .IsRequired();



            builder.Property(b => b.Price)
                    .HasColumnType("double(50)")
                    .IsRequired();


            builder.Property(b => b.RowVersion)
                .IsRowVersion();



        }
    }
}