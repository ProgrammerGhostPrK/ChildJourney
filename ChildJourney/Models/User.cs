namespace ChildJourney.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Coins { get; set; }
        public int Daystreak { get; set; }
        public int DailyStreak { get; set; }
        public ICollection<User_Badge> UserBadges { get; set;}
        public ICollection<User_Animal> UserAnimals { get; set;}
        public ICollection<User_Clothing> UserClothing { get; set;}
        public ICollection<User_Decoration> UserDeco { get; set; }
        public ICollection<User_Reward> UserRewards { get; set; }
        public ICollection<User_BodyPart> UserBosyParts { get; set; }
        public ICollection<Mood> Moods { get; set; }
        public int UnlockedIslands { get; set; }
        public Outfit Outfit { get; set; }
        public Body Body { get; set; }
        public House House { get; set; }
    }
}
