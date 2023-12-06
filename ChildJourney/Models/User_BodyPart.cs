using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User_BodyPart
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int BodyPartId { get; set; }
        [Required]
        public BodyPart BodyPart { get; set; }
    }
}
