using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MeetingTestApi.Entities
{
    public partial class AppointmentsContext : DbContext
    {
        public AppointmentsContext()
        {
        }

        public AppointmentsContext(DbContextOptions<AppointmentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDays> TblDays { get; set; }
        public virtual DbSet<TblMeetings> TblMeetings { get; set; }
        public virtual DbSet<TblTimeslots> TblTimeslots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Appointments;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<TblDays>(entity =>
            {
                entity.HasKey(e => e.IdDay)
                    .HasName("PK__tblDays__0E65962A5F5CDDD8");

                entity.ToTable("tblDays");

                entity.Property(e => e.Day).HasColumnType("date");
            });

            modelBuilder.Entity<TblMeetings>(entity =>
            {
                entity.HasKey(e => e.IdMeeting)
                    .HasName("PK__tblMeeti__392A178AC8943D74");

                entity.ToTable("tblMeetings");

                entity.HasOne(d => d.IdDayNavigation)
                    .WithMany(p => p.TblMeetings)
                    .HasForeignKey(d => d.IdDay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Day");

                entity.HasOne(d => d.IdTimeslotNavigation)
                    .WithMany(p => p.TblMeetings)
                    .HasForeignKey(d => d.IdTimeslot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TimeSlots");
            });

            modelBuilder.Entity<TblTimeslots>(entity =>
            {
                entity.HasKey(e => e.IdTimeslot)
                    .HasName("PK__tblTimes__7713A40014C4300D");

                entity.ToTable("tblTimeslots");

                entity.Property(e => e.EndTime).HasColumnName("End_time");

                entity.Property(e => e.StartTime).HasColumnName("Start_time");
            });
        }
    }
}
