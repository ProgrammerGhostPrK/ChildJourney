using ChildJourney.Models;
namespace ChildJourney.ViewModels
{
    public class AdminViewModel
    {
        public List<User> Users { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Badge> Badges { get; set; }
        public List<BodyPart> bodyParts { get; set; }
        public List<Clothing> clothing { get; set; }
        public List<Decoration> decorations { get; set; }
        public List<Reward> rewards { get; set; }
    }
}
