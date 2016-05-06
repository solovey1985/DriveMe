using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public class Location:ValueObjectBase<Location>
    {
        
        public string Title { get; private set; }

        public string Address { get; private set; }

        public Position Position { get; private  set; }

        #region Constructors
        public Location()
        {
            Title = string.Empty;
            Address = string.Empty;
            Position = new Position(0,0);
        }

        public Location(string address) : this()
        {
            Address = address;
        }

        public Location(double latitude, double longitude):this()
        {
            Position = new Position(latitude,longitude);
        }

        public Location(string address, double latitude, double longitude) : this(latitude, longitude)
        {
            Address = address;
        }

        public Location(string address, Position position, string title)
        {
            Title = title;
            Address = address;
            Position = position;
        }
        #endregion

        public Location WithAddress(string address)
        {
            return new Location(address) {Position = this.Position, Title = this.Title};
        }
        public Location WithPosition(Position position)
        {
            return new Location(position.Latitude, position.Longitude) {Title = this.Title, Address = this.Address};
        }
        public Location WithTitle(string title)
        {
            return new Location() {Title = title, Position = Position, Address = Address};
        }
        
        #region Equals
        public override bool Equals(Location other)
        {
            return Equals(objA: Position, objB: other.Position);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Location)) return false;
            return this.Equals((Location)obj);
        }

        public override int GetHashCode()
        {
            return Position.Latitude.GetHashCode() + Position.Longitude.GetHashCode();
            
        }

        #endregion
    }
}