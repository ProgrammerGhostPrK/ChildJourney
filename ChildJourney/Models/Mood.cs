﻿using System.ComponentModel.DataAnnotations;

namespace ChildJourney.Models
{
    public class Mood
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int Grade { get; set; }
        public DateTime Day { get; set; }
    }
}
