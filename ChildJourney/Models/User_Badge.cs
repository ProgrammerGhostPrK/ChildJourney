using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User_Badge
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int BadgeId { get; set; }
        [Required]
        public Badge Badge { get; set; }
        public int BadgeLevel { get; set; }
    }
}
