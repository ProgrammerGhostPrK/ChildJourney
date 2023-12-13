﻿using Microsoft.EntityFrameworkCore;
using ChildJourney.Models;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;

namespace ChildJourney.Data
{
    public class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<Decoration> Decoration { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<SeasonReward> SeasonRewards { get; set; }
        public DbSet<WeekRewards> WeekRewards { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Outfit> Outfits { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<User_Badge> UsersBadges { get; set; }
        public DbSet<User_Animal> UsersAnimals { get; set; }
        public DbSet<User_Clothing> UsersClothing { get; set; }
        public DbSet<User_Decoration> UsersDecorations { get; set; }
        public DbSet<User_Reward> UsersRewards { get; set; }
        public DbSet<User_BodyPart> UsersBodyParts { get; set; }
        public DbSet<Body_Bodypartcs> BodyBodyParts { get; set; }
        public DbSet<Outfit_Clothing> OutfitClothing { get; set; }

        public Database(DbContextOptions<Database> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ConnectionstringPC: "Server=DESKTOP-RP2I2GQ;Database=ChildJourney;Uid=root;Pwd=Axel17042004;"
            // ConnectionstringLaptop: "Server=LAPTOP-LM37OQ9D;Database=ChildJourney;Uid=root;Pwd=Axel17042004;"
            optionsBuilder.UseMySQL("Server=LAPTOP-LM37OQ9D;Database=ChildJourney;Uid=root;Pwd=Axel17042004;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasOne(a => a.Outfit)
            .WithOne(a => a.User)
            .HasForeignKey<Outfit>(c => c.UserId);

            modelBuilder.Entity<User>()
            .HasOne(a => a.Body)
            .WithOne(a => a.User)
            .HasForeignKey<Body>(c => c.UserId);
        }
    }
}
