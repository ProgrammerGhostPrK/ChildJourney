namespace ChildJourney.Models
{
    public class Mood
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Grade { get; set; }
        public DateTime Day { get; set; }
    }
}
