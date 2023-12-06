namespace ChildJourney.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Day { get; set; }
        public ICollection<User_Animal> UserAnimals { get; set; }
        public Decoration OwnedHouse { get; set; }
    }
}
