using System.Drawing;

namespace ChildJourney.Models
{
    public class Island
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Color primaryThemeColour { get; set; }
        public Color secondaryThemeColour { get; set; }
        public ICollection<User_Island> User_Islands { get; set; }

    }
}
