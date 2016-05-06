using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public class Position:ValueObjectBase<Position>
    {
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(Position other)
        {
            return ComparePositionWithPrecision(other, PlacePrecision.House);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Position)) return false;
            return this.Equals((Position)obj);
        }
        public override int GetHashCode()
        {
            return Latitude.GetHashCode() + Longitude.GetHashCode();
        }
        public bool IsTheSameCity(Position other)
        {
            return ComparePositionWithPrecision(other, PlacePrecision.City);
        }
        public bool IsTheSameDistrict(Position other)
        {
            return ComparePositionWithPrecision(other, PlacePrecision.DistrictOrVillage);
        }
        public bool IsTheSameStreet(Position other)
        {
            return ComparePositionWithPrecision(other, PlacePrecision.Street);
        }
        public bool IsTheSameAddress(Position other)
        {

            return ComparePositionWithPrecision(other, PlacePrecision.House);
        }
        private bool ComparePositionWithPrecision(Position other, PlacePrecision precision)
        {
            var lat = Math.Round((decimal)Latitude, (int)precision);
            var lng = Math.Round((decimal)Longitude, (int)precision);
            var anotherLat = Math.Round((decimal)other.Latitude, (int)precision);
            var anotherLng = Math.Round((decimal)other.Longitude, (int)precision);
            return (lat == anotherLat && lng == anotherLng);
        }


    }
}

public enum PlacePrecision
{
    Country = 0,
    City = 1, 
    Town = 2,
    DistrictOrVillage = 3,
    Street = 4, 
    House = 5,
    Human = 6
}

/*
Precise
Таблица приведения точностей координат
decimal  places decimal     degrees             объекты                                     at equator  23°         45°         67°
0	            1.0	        1° 00′ 0″	        country or large region	                    111.32 km	102.47 km	78.71 km	43.496 km
1	            0.1	        0° 06′ 0″	        large city or district	                    11.132 km	10.247 km	7.871 km	4.3496 km
2	            0.01	    0° 00′ 36″	        town or village	                            1.1132 km	1.0247 km	787.1 m	    434.96 m
3	            0.001	    0° 00′ 3.6″	        neighborhood, street	                    111.32 m	102.47 m	78.71 m	    43.496 m
4	            0.0001	    0° 00′ 0.36″	    individual street, land parcel	            11.132 m	10.247 m	7.871 m	    4.3496 m
5	            0.00001	    0° 00′ 0.036″	    individual trees	                        1.1132 m	1.0247 m	787.1 mm	434.96 mm
6	            0.000001	0° 00′ 0.0036″	    individual kittens	                        111.32 mm	102.47 mm	78.71 mm	43.496 mm
7	            0.0000001	0° 00′ 0.00036″	    practical limit of comm.surveying	        11.132 mm	10.247 mm	7.871 mm	4.3496 mm
8	            0.00000001	0° 00′ 0.000036″	spec.surveying (tectonic plate mapping)	    1.1132 mm	1.0247 mm	787.1 µm	434.96 µm
Добавить перечисление точности для объектов
*/
