using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User_Island
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int IslandId { get; set; }
        [Required]
        public Island Island { get; set;}
    }
}
