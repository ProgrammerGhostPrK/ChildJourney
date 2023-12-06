namespace ChildJourney.Models
{
    public class Decoration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public ICollection<User_Decoration> UserDecoration { get; set; }
    }
}
