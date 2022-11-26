/*
    Value Object Pattern adapted from https://www.youtube.com/watch?v=DG8Qe7TJiIE
    Author: Julie Lerman
    Date: 23/11/2022
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace AssetManagement.Domain.System.ValueObjects
{
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

        public override int GetHashCode() => new { Name, Version, Manufacturer }.GetHashCode();

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