using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Clothing
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        [Required]
        public ICollection<User_Clothing>? UserClothing { get; set; }
    }
}
