namespace ChildJourney.Models
{
    public class Outfit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Clothing> Clothing { get; set; }
    }
}
