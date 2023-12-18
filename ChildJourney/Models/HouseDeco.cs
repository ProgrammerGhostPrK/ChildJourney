using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class HouseDeco
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int HouseId { get; set; }
        [Required]
        public House House { get; set; }
        public int DecorationId { get; set; }
        [Required]
        public Decoration Decoration { get; set; }
    }
}
