﻿using global2.NET.Database.Mapping;
using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace global2.NET.Database
{
    public class FIAPDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OptimizationAlert> OptimalAlerts { get; set; }
        public DbSet<IncentiveScore> IncentiveScores { get; set; }
        public DbSet<EnergyLecture> EnergyLectures { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ContactNumber> ContactNumbers { get; set; }
        public DbSet<Address> Address { get; set; }

        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new OptimizationAlertMapping());
            modelBuilder.ApplyConfiguration(new IncentiveScoreMapping());
            modelBuilder.ApplyConfiguration(new EnergyLectureMapping());
            modelBuilder.ApplyConfiguration(new DeviceMapping());
            modelBuilder.ApplyConfiguration(new ContactNumberMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
    public static class DbContextOptionsExtensions
    {
        public static DbContextOptionsBuilder UseConfiguredOracle(
            this DbContextOptionsBuilder options, string connectionString)
        {
            return options.UseOracle(connectionString, b => b.MigrationsAssembly("global2.net"));
        }
    }
}