namespace ChildJourney.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Worth { get; set; }
        public ICollection<User_Reward> UserRewards { get; set; }

    }
}
