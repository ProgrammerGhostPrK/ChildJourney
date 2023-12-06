namespace ChildJourney.Models
{
    public class User_Clothing
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClothingId { get; set; }
        public Clothing Clothing { get; set;}
    }
}
