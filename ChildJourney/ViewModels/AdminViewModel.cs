using ChildJourney.Models;
namespace ChildJourney.ViewModels
{
    public class AdminViewModel
    {
        public List<User> Users { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Badge> Badges { get; set; }
        public List<BodyPart> bodyParts { get; set; }
        public List<Clothing> clothing { get; set; }
        public List<Decoration> decorations { get; set; }
        public List<Reward> rewards { get; set; }
        public List<Outfit_Clothing> Outfit_Clothings { get; set; }
        public List<BodyBodyParts> Body_BodyParts { get; set; }
        public List<HouseDeco> House_Decos { get; set; }
        public List<User_Clothing> UserClothing { get; set; }
        public List<User_BodyPart> UserBodyPart { get; set; }
        public List<User_Decoration> UserDecoration { get; set; }
        public List<User_Island> User_Island { get; set; }
        public List<User_Animal> UserAnimals { get; set; }
        public List<User_Badge> UserBadges { get; set; }
        public List<User_Reward> UserRewards { get; set; }
        public List<Island> Islands { get; set; }
        public User? User { get; set; }
        public Island? CurrentIsland { get; set; }
    }
}
