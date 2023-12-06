namespace ChildJourney.Models
{
    public class Clothing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public ICollection<User_Clothing> UserClothing { get; set; }
    }
}
