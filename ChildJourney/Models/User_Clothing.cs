using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User_Clothing
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int ClothingId { get; set; }
        [Required]
        public Clothing Clothing { get; set;}
    }
}
