using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class WeekRewards : Reward
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public ICollection<Reward> weekRewards { get; set; }
    }
}
