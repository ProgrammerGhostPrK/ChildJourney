namespace ChildJourney.Models
{
    public class User_Decoration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DecorationId { get; set; }
        public Decoration Decoration { get; set; }

    }
}
