using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User_Animal
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int AnimalId { get; set; }
        [Required]
        public Animal Animal { get; set; }
    }
}
