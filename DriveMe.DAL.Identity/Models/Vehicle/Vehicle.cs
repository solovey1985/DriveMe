namespace DriveMe.DAL.Identity.Models
{
    public class Vehicle : DrivemeIdentity
    {
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public Colors Color { get; set; }
        public User Driver { get; set; }
        public int DriverId { get; set; }
    }
}