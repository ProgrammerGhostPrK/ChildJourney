﻿using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool Admin { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Coins { get; set; }
        public int SeasonPoints { get; set; }
        public int Daystreak { get; set; }
        public int lastWeekLogin { get; set; }
        public int lastMonthLogin { get; set; }
        public int DailyStreak { get; set; }
        [Required]
        public ICollection<User_Badge>? UserBadges { get; set;}
        [Required]
        public ICollection<User_Animal>? UserAnimals { get; set;}
        [Required]
        public ICollection<User_Clothing>? UserClothing { get; set;}
        [Required]
        public ICollection<User_Decoration>? UserDeco { get; set; }
        [Required]
        public ICollection<User_Reward>? UserRewards { get; set; }
        [Required]
        public ICollection<User_BodyPart>? UserBosyParts { get; set; }
        [Required]
        public ICollection<User_Island>? UserIslands { get; set; }
        [Required]
        public ICollection<Mood>? Moods { get; set; }
        public int? OutfitId { get; set; }  
        public int? BodyId { get; set; }
        public int? HouseId { get; set; }
        [Required]
        public Outfit? Outfit { get; set; }
        [Required]
        public Body? Body { get; set; }
        [Required]
        public House? House { get; set; }
    }
}
