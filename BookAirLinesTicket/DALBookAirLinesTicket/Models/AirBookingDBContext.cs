using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DALBookAirLinesTicket.Models
{
    public partial class AirBookingDBContext : DbContext
    {
        public AirBookingDBContext()
        {
        }
        public AirBookingDBContext(DbContextOptions<AirBookingDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BookFlight> BookFlights { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=AirBookingDB;Integrated Security=true");
//            }
//        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("AirBookingDB");
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookFlight>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("pk_DoctorID");

                entity.ToTable("BookFlight");

                entity.Property(e => e.BookingId).HasColumnName("bookingID");

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("flightNo");

                entity.Property(e => e.NoOfTicket).HasColumnName("noOfTicket");

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
