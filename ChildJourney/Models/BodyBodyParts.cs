using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class BodyBodyParts
    {
        public int Id { get; set; }
        public int BodyId { get; set; }
        [Required]
        public Body Body { get; set; }
        public int BodyPartId { get; set; }
        [Required]
        public BodyPart BodyPart { get; set; }
    }
}
