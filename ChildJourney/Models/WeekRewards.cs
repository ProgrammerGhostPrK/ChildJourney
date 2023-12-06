namespace ChildJourney.Models
{
    public class WeekRewards : Reward
    {
        public int Id { get; set; }
        public ICollection<Reward> weekRewards { get; set; }
    }
}
