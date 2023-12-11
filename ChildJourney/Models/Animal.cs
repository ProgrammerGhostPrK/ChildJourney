using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Animal
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Decoration? OwnedHouse { get; set; }
        [Required]
        public ICollection<User_Animal>? UserAnimals { get; set; }
    }
}
