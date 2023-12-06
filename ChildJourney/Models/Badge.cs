namespace ChildJourney.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Day { get; set; }
        public int Level { get; set; }
        public ICollection<User_Badges> UserBadges { get; set; }
    }
}
