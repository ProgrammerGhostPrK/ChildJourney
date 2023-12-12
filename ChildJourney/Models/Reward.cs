using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Reward
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Image { get; set; }

        public int Worth { get; set; }
        [Required]
        public ICollection<User_Reward>? UserRewards { get; set; }

    }
}
