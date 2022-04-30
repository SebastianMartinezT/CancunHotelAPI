using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CancunHotel.Models.Context
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<reservationdetail> reservationdetail { get; set; }
        public virtual DbSet<rooms> rooms { get; set; }
        public virtual DbSet<states> states { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<rooms>()
                .HasMany(e => e.reservationdetail)
                .WithOptional(e => e.rooms)
                .HasForeignKey(e => e.RoomId);

            modelBuilder.Entity<states>()
                .HasMany(e => e.reservationdetail)
                .WithOptional(e => e.states)
                .HasForeignKey(e => e.StateReservation);

            modelBuilder.Entity<states>()
                .HasMany(e => e.rooms)
                .WithOptional(e => e.states)
                .HasForeignKey(e => e.State);
        }
    }
}
