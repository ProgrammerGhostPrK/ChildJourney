﻿// <auto-generated />
using System;
using ChildJourney.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChildJourney.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20231220112226_StorePrep")]
    partial class StorePrep
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BodyBodyPart", b =>
                {
                    b.Property<int>("BodiesId")
                        .HasColumnType("int");

                    b.Property<int>("BodyPartsId")
                        .HasColumnType("int");

                    b.HasKey("BodiesId", "BodyPartsId");

                    b.HasIndex("BodyPartsId");

                    b.ToTable("BodyBodyPart", (string)null);
                });

            modelBuilder.Entity("ChildJourney.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("OwnedHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnedHouseId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ChildJourney.Models.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("ChildJourney.Models.Body", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Bodies");
                });

            modelBuilder.Entity("ChildJourney.Models.BodyBodyParts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BodyId")
                        .HasColumnType("int");

                    b.Property<int>("BodyPartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("BodyPartId");

                    b.ToTable("BodyBodyParts");
                });

            modelBuilder.Entity("ChildJourney.Models.BodyPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BodyParts");
                });

            modelBuilder.Entity("ChildJourney.Models.Clothing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clothing");
                });

            modelBuilder.Entity("ChildJourney.Models.Decoration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Decoration");
                });

            modelBuilder.Entity("ChildJourney.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("ChildJourney.Models.HouseDeco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DecorationId")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DecorationId");

                    b.HasIndex("HouseId");

                    b.ToTable("HouseDecoration");
                });

            modelBuilder.Entity("ChildJourney.Models.Island", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("PrimaryColor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecondaryColor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Islands");
                });

            modelBuilder.Entity("ChildJourney.Models.Mood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Moods");
                });

            modelBuilder.Entity("ChildJourney.Models.Outfit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Outfits");
                });

            modelBuilder.Entity("ChildJourney.Models.Outfit_Clothing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClothingId")
                        .HasColumnType("int");

                    b.Property<int>("OutfitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClothingId");

                    b.HasIndex("OutfitId");

                    b.ToTable("OutfitClothing");
                });

            modelBuilder.Entity("ChildJourney.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("WeekRewardsId")
                        .HasColumnType("int");

                    b.Property<int>("Worth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeekRewardsId");

                    b.ToTable("Rewards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Reward");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ChildJourney.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Admin")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("BodyId")
                        .HasColumnType("int");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int>("DailyStreak")
                        .HasColumnType("int");

                    b.Property<int>("Daystreak")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("OutfitId")
                        .HasColumnType("int");

                    b.Property<int>("UnlockedIslands")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersAnimals");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BadgeId")
                        .HasColumnType("int");

                    b.Property<int>("BadgeLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BadgeId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersBadges");
                });

            modelBuilder.Entity("ChildJourney.Models.User_BodyPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BodyPartId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodyPartId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersBodyParts");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Clothing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClothingId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClothingId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersClothing");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Decoration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DecorationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DecorationId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersDecorations");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Island", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IslandId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IslandId");

                    b.HasIndex("UserId");

                    b.ToTable("UserIslands");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RewardId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRewards");
                });

            modelBuilder.Entity("ClothingOutfit", b =>
                {
                    b.Property<int>("ClothingId")
                        .HasColumnType("int");

                    b.Property<int>("OutfitsId")
                        .HasColumnType("int");

                    b.HasKey("ClothingId", "OutfitsId");

                    b.HasIndex("OutfitsId");

                    b.ToTable("OutfitClothings", (string)null);
                });

            modelBuilder.Entity("ChildJourney.Models.SeasonReward", b =>
                {
                    b.HasBaseType("ChildJourney.Models.Reward");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MaxPoints")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasDiscriminator().HasValue("SeasonReward");
                });

            modelBuilder.Entity("ChildJourney.Models.WeekRewards", b =>
                {
                    b.HasBaseType("ChildJourney.Models.Reward");

                    b.HasDiscriminator().HasValue("WeekRewards");
                });

            modelBuilder.Entity("BodyBodyPart", b =>
                {
                    b.HasOne("ChildJourney.Models.Body", null)
                        .WithMany()
                        .HasForeignKey("BodiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.BodyPart", null)
                        .WithMany()
                        .HasForeignKey("BodyPartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChildJourney.Models.Animal", b =>
                {
                    b.HasOne("ChildJourney.Models.Decoration", "OwnedHouse")
                        .WithMany()
                        .HasForeignKey("OwnedHouseId");

                    b.Navigation("OwnedHouse");
                });

            modelBuilder.Entity("ChildJourney.Models.Body", b =>
                {
                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithOne("Body")
                        .HasForeignKey("ChildJourney.Models.Body", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.BodyBodyParts", b =>
                {
                    b.HasOne("ChildJourney.Models.Body", "Body")
                        .WithMany()
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.BodyPart", "BodyPart")
                        .WithMany()
                        .HasForeignKey("BodyPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("BodyPart");
                });

            modelBuilder.Entity("ChildJourney.Models.Decoration", b =>
                {
                    b.HasOne("ChildJourney.Models.House", null)
                        .WithMany("HouseParts")
                        .HasForeignKey("HouseId");
                });

            modelBuilder.Entity("ChildJourney.Models.House", b =>
                {
                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithOne("House")
                        .HasForeignKey("ChildJourney.Models.House", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.HouseDeco", b =>
                {
                    b.HasOne("ChildJourney.Models.Decoration", "Decoration")
                        .WithMany()
                        .HasForeignKey("DecorationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Decoration");

                    b.Navigation("House");
                });

            modelBuilder.Entity("ChildJourney.Models.Mood", b =>
                {
                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany("Moods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.Outfit", b =>
                {
                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithOne("Outfit")
                        .HasForeignKey("ChildJourney.Models.Outfit", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.Outfit_Clothing", b =>
                {
                    b.HasOne("ChildJourney.Models.Clothing", "Clothing")
                        .WithMany()
                        .HasForeignKey("ClothingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.Outfit", "Outfit")
                        .WithMany()
                        .HasForeignKey("OutfitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clothing");

                    b.Navigation("Outfit");
                });

            modelBuilder.Entity("ChildJourney.Models.Reward", b =>
                {
                    b.HasOne("ChildJourney.Models.WeekRewards", null)
                        .WithMany("weekRewards")
                        .HasForeignKey("WeekRewardsId");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Animal", b =>
                {
                    b.HasOne("ChildJourney.Models.Animal", "Animal")
                        .WithMany("UserAnimals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany("UserAnimals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Badge", b =>
                {
                    b.HasOne("ChildJourney.Models.Badge", "Badge")
                        .WithMany("UserBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany("UserBadges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Badge");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.User_BodyPart", b =>
                {
                    b.HasOne("ChildJourney.Models.BodyPart", "BodyPart")
                        .WithMany("UserBodyParts")
                        .HasForeignKey("BodyPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany("UserBosyParts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyPart");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Clothing", b =>
                {
                    b.HasOne("ChildJourney.Models.Clothing", "Clothing")
                        .WithMany("UserClothing")
                        .HasForeignKey("ClothingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany("UserClothing")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clothing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Decoration", b =>
                {
                    b.HasOne("ChildJourney.Models.Decoration", "Decoration")
                        .WithMany("UserDecoration")
                        .HasForeignKey("DecorationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany("UserDeco")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Decoration");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Island", b =>
                {
                    b.HasOne("ChildJourney.Models.Island", "Island")
                        .WithMany("User_Islands")
                        .HasForeignKey("IslandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Island");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChildJourney.Models.User_Reward", b =>
                {
                    b.HasOne("ChildJourney.Models.Reward", "Reward")
                        .WithMany("UserRewards")
                        .HasForeignKey("RewardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.User", "User")
                        .WithMany("UserRewards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reward");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClothingOutfit", b =>
                {
                    b.HasOne("ChildJourney.Models.Clothing", null)
                        .WithMany()
                        .HasForeignKey("ClothingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChildJourney.Models.Outfit", null)
                        .WithMany()
                        .HasForeignKey("OutfitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChildJourney.Models.Animal", b =>
                {
                    b.Navigation("UserAnimals");
                });

            modelBuilder.Entity("ChildJourney.Models.Badge", b =>
                {
                    b.Navigation("UserBadges");
                });

            modelBuilder.Entity("ChildJourney.Models.BodyPart", b =>
                {
                    b.Navigation("UserBodyParts");
                });

            modelBuilder.Entity("ChildJourney.Models.Clothing", b =>
                {
                    b.Navigation("UserClothing");
                });

            modelBuilder.Entity("ChildJourney.Models.Decoration", b =>
                {
                    b.Navigation("UserDecoration");
                });

            modelBuilder.Entity("ChildJourney.Models.House", b =>
                {
                    b.Navigation("HouseParts");
                });

            modelBuilder.Entity("ChildJourney.Models.Island", b =>
                {
                    b.Navigation("User_Islands");
                });

            modelBuilder.Entity("ChildJourney.Models.Reward", b =>
                {
                    b.Navigation("UserRewards");
                });

            modelBuilder.Entity("ChildJourney.Models.User", b =>
                {
                    b.Navigation("Body")
                        .IsRequired();

                    b.Navigation("House")
                        .IsRequired();

                    b.Navigation("Moods");

                    b.Navigation("Outfit")
                        .IsRequired();

                    b.Navigation("UserAnimals");

                    b.Navigation("UserBadges");

                    b.Navigation("UserBosyParts");

                    b.Navigation("UserClothing");

                    b.Navigation("UserDeco");

                    b.Navigation("UserRewards");
                });

            modelBuilder.Entity("ChildJourney.Models.WeekRewards", b =>
                {
                    b.Navigation("weekRewards");
                });
#pragma warning restore 612, 618
        }
    }
}
