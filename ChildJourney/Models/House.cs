namespace ChildJourney.Models
{
    public class House
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Decoration> HouseParts { get; set; }
    }
}
