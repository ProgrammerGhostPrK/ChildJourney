﻿namespace ChildJourney.Models
{
    public class Body
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<BodyPart> BodyParts { get; set; }
    }
}
