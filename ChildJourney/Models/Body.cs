using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Body
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public ICollection<BodyPart>? BodyParts { get; set; }
    }
}
