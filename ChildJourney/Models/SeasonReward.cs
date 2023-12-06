using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class SeasonReward : Reward
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int MaxPoints { get; set; }
    }
}
