using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChildJourney.Models
{
    public class Outfit
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public ICollection<Clothing>? Clothing { get; set; }
    }
}
