using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Moble_Proj01.Data
{
    public class DTO_flight
    {
        public string icao24 { get; set; } = string.Empty;
        public string Callsign { get; set; } = string.Empty;
        public double Latitude { get; set; } 
        public double Longitude { get; set; }
        public double TrueTrack { get; set; } 
    }
}















