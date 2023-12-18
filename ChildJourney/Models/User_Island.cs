namespace ChildJourney.Models
{
    public class User_Island
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int IslandId { get; set; }
        public Island Island { get; set;}
    }
}
