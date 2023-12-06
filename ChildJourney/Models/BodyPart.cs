namespace ChildJourney.Models
{
    public class BodyPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public ICollection<User_BodyPart> UserBodyParts { get; set; }
    }
}
