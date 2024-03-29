﻿using System.Threading.Tasks;
using Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TestContext : DbContext, ITestContext
    {
        public DbSet<Test> Tests { get; set; }
        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        //Note I would never hard code a connection string in production, only doing this for demo purposes
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Checkr;Username=postgres;Password=passw0rd");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test", "public");
                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasDefaultValueSql("nextval('account.item_id_seq'::regclass)");
                entity.Property(e => e.Data).HasColumnName("Data");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name");
                entity.Property(e => e.PhoneNumber)
                    .IsRequired(false)
                    .HasColumnName("PhoneNumber");
                entity.Property(e => e.State)
                    .IsRequired(false)
                    .HasColumnName("State");
            });
            modelBuilder.HasSequence("test_id_seq", "public");
        }
    }
}

