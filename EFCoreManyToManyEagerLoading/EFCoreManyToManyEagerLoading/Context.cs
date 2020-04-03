using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreManyToManyEagerLoading
{
    class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserName);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.HasKey(t => t.TournamentId);
                entity.Property(t => t.TournamentName);
            });

            modelBuilder.Entity<UTRelation>(entity =>
            {
                entity.HasKey(ut => new { ut.UserId, ut.TournamentId });
                entity.HasOne(ut => ut.User)
                    .WithMany(u => u.UTRelations)
                    .HasForeignKey(ut => ut.UserId);
                entity.HasOne(ut => ut.Tournament)
                    .WithMany(t => t.UTRelations)
                    .HasForeignKey(ut => ut.TournamentId);
            });
        }
    }
}
