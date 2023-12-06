using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class User_Reward
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int RewardId { get; set; }
        [Required]
        public Reward Reward { get; set; }
    }
}
