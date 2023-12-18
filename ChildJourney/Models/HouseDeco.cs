namespace ChildJourney.Models
{
    public class HouseDeco
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
        public int DecorationId { get; set; }
        public Decoration Decoration { get; set; }
    }
}
