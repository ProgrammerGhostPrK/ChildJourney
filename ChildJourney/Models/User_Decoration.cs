using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User_Decoration
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int DecorationId { get; set; }
        [Required]
        public Decoration Decoration { get; set; }

    }
}
