using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportSystem.Core.Entities;

namespace TransportSystem.Data.EntityConfigurations
{
    public class TripEntityTypeConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("trips");

            builder.HasKey(t => t.Id);


            builder.Property(t => t.Date)
                .HasColumnType("dateTime(50)")
                .IsRequired();



            builder.Property(t => t.TakeOff)
                    .HasColumnType("(50)")
                    .IsRequired();


            builder.Property(t => t.Destination)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.DepatureTime)
            .HasColumnType("dateTime(50)");


            builder.Property(t => t.Arrival)
           .HasColumnType("varchar(50)");



            builder.Property(t => t.RowVersion)
                .IsRowVersion();



            builder.HasMany(t => t.Bookings)
              .WithOne(t => t.Trip)
              .HasForeignKey(b => b.TripId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}