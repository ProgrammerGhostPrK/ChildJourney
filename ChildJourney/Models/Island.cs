using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ChildJourney.Models
{
    public class Island
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set;}
        [Required]
        public ICollection<User_Island> User_Islands { get; set; }

    }
}
