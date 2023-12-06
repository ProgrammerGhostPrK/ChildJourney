using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Badge
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public ICollection<User_Badge>? UserBadges { get; set; }
    }
}
