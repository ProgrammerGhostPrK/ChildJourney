using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ChildJourney.Models
{
    public class Island
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Color primaryThemeColour { get; set; }
        public Color secondaryThemeColour { get; set; }
        [Required]
        public ICollection<User_Island> User_Islands { get; set; }

    }
}
