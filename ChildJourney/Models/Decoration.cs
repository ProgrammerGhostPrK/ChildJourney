using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Decoration
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        [Required]
        public ICollection<User_Decoration>? UserDecoration { get; set; }
        [Required]
        public ICollection<House>? House { get; set; }
    }
}
