using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Outfit_Clothing
    {
        public int Id { get; set; }
        public int OutfitId { get; set; }
        [Required]
        public Outfit Outfit { get; set; }
        public int ClothingId { get; set; }
        [Required]
        public Clothing Clothing { get; set;}
    }
}
