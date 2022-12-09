/*
    Value Object Pattern adapted from https://www.youtube.com/watch?v=DG8Qe7TJiIE
    Author: Julie Lerman
    Date: 23/11/2022
*/

using System;

namespace AssetManagement.Domain.System.ValueObjects
{
    /*
    * Software ValueObject implemented as an immutable object whos identity
    * is determined by its values.
    */

    public class Software
    {
        public string Name { get; private set; }
        public string Version { get; private set; }
        public string Manufacturer { get; private set; }

        public static Software Create (string _Name, string _Version, string _Manufacturer)
        {
            return new Software(_Name, _Version, _Manufacturer);
        }

        public static Software Empty ()
        {
            return new Software();
        }

        private Software()
        {
        }

        private Software(string _Name, string _Version, string _Manufacturer)
        {
            Name = _Name;
            Version = _Version;
            Manufacturer = _Manufacturer;
        }

        /* Overrides the GetHashCode method, necessary for certain comparison operations */
        public override int GetHashCode() => new { Name, Version, Manufacturer }.GetHashCode();

        /* Overrides the Equals operator to provide a comparison based on the value of the fields */
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            var other = (Software)obj;
            return other.Name == Name
                && other.Version == Version
                && other.Manufacturer == Manufacturer;
        }
    }
}