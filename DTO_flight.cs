using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Moble_Proj01
{
    public class DTO_flight
    {
        public string icao24 { get; set; }
        public string Callsign { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double TrueTrack { get; set; }
    

        public void main(string args) {
            List<DTO_flight> flightList = new List<DTO_flight>();
            Map_Data data = new Map_Data();

            data.GetFlightDataAsync();

            // 2. foreach 반복문 내부에서 데이터를 클래스에 담아 리스트에 추가


            string icao24 = state[0].GetString();
            string callsign = state[1].ValueKind == JsonValueKind.String ? state[1].GetString().Trim() : "N/A";

            if (state[6].ValueKind == JsonValueKind.Number && state[5].ValueKind == JsonValueKind.Number)
            {
                double latitude = state[6].GetDouble();
                double longitude = state[5].GetDouble();
                double trueTrack = state[10].ValueKind == JsonValueKind.Number ? state[10].GetDouble() : 0.0;

                // 객체를 생성하여 데이터 대입
                FlightData flight = new FlightData
                {
                    Icao24 = icao24,
                    Callsign = callsign,
                    Latitude = latitude,
                    Longitude = longitude,
                    TrueTrack = trueTrack
                };

                // 리스트에 추가
                flightList.Add(flight);
            }
        }

    }
}















