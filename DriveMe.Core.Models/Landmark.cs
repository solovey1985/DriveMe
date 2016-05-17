namespace DriveMe.Domain.Models
{
    public class Landmark
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Location Location { get; set; }

        public int Distance { get; set; }

        public int Direction { get; set; }
    }
}