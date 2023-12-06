namespace ChildJourney.Models
{
    public class User_BodyPart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BodyPartId { get; set; }
        public BodyPart BodyPart { get; set; }
    }
}
