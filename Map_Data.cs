using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using MySql.Data.MySqlClient; // 라이브러리 전처리 



namespace Moble_Proj01
{
    public class Map_Data 
    {   // 클라이언트 객체 생성
        private static readonly HttpClient httpClient = new HttpClient();

        public Map_Data()
        {
    
            // 폼 생성(실행) 시 즉시 비동기 메소드 실행시키는 문법 
            _ = GetFlightDataAsync();
        }

        // 데이터 받아오는 함수 시작하기 버튼과 연동시키는 걸 추천함.
        // 


        // @ 맨 처음 1번만 받아온 후, 각 받아오는 데이터는 항공기 번호, 위치, 방향이며, @ 
        // @ 해당 Flights 리스트 객체는 메모리에 할당 시킨뒤, 

        // @ 맵에 컨트롤로써 생성하는 함수 , 

        // @ 모든 객체는, 이동함수를 가짐. 이동함수는 방향 * 우리의 공식으로 계산함.
        // @ 만약 받아올 수 있는데이터에 속도도 있는지 알아보고 그거 기반으로 게산하기.


        // @ 만약 진행도중 중간쯤에 ID 기반 실시간 업데이트도 해보기.  


        // 3개 형태로 데이터 받아와서 성능비교.

        // 객체 할당 Didctionary 자료구조로,
        //private double ()
        // 객체 할당 list 자료구조로,

        // 객체할당 MySQL DB로, 

        public async Task GetFlightDataAsync()
        {
            try
            {
                Console.WriteLine("호출중");


                // 공식 REST API 스펙에 따른 Bounding Box 쿼리 파라미터 적용
                string url = "https://opensky-network.org/api/states/all?lamin=33.0&lomin=124.5&lamax=38.5&lomax=131.5";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // [디버그 계층 1] 통신 상태 코드 확인
                Console.WriteLine($"[디버그] HTTP 응답 코드: {(int)response.StatusCode} {response.ReasonPhrase}\r\n");


                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();

                // [디버그 계층 2] 원본 데이터 길이 및 프리뷰(미리보기)
                Console.WriteLine($"[디버그] 수신된 데이터 길이: {jsonString.Length}자\r\n");

                string preview = jsonString.Length > 100 ? jsonString.Substring(0, 100) + "..." : jsonString;
                Console.WriteLine($"[디버그] 원본 데이터 요약: {preview}\r\n\r\n");


                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    JsonElement root = doc.RootElement;
                    if (root.TryGetProperty("states", out JsonElement statesElement))
                    {
                        if (statesElement.ValueKind == JsonValueKind.Array)
                        {
                            int totalFlights = statesElement.GetArrayLength();
                            Console.WriteLine($"현재 상공의 총 항공기 수: {totalFlights}대\r\n\r\n ");
                            List<DTO_flight> flight_List = new List<DTO_flight>();


                            foreach (JsonElement state in statesElement.EnumerateArray())
                            {
                                // 배열 인덱스: [0]icao24, [1]callsign, [5]longitude, [6]latitude, [10]true_track
                                string? icao24 = state[0].GetString();
                                string? callsign = state[1].ValueKind == JsonValueKind.String ? state[1].GetString().Trim() : "N/A";

                                if (state[6].ValueKind == JsonValueKind.Number && state[5].ValueKind == JsonValueKind.Number)
                                {
                                    double latitude = state[6].GetDouble();
                                    double longitude = state[5].GetDouble();
                                    double trueTrack = state[10].ValueKind == JsonValueKind.Number ? state[10].GetDouble() : 0.0;
                                    
                                    // 받아올 api를 클래스화한 DTO_flight를 리스트화 
                                    // 검증 후 새 리스트 객체 할당.
                                    flight_List.Add(new DTO_flight
                                    {
                                        icao24 = icao24,
                                        callsign = callsign,
                                        latitude = latitude,
                                        longitude = longitude,
                                        trueTrack = trueTrack
                                    });
                                }
                            }
                            // 데이터 수 천개 들어오고, 리스트 -> 맵 람다식으로 구현
                            Dictionary<string, DTO_flight> flight_dict = flight_List.ToDictionary(flight => flight.icao24);



                        }
                        else
                        {
                            Console.WriteLine("[디버그] 에러: 'states' 속성이 배열(Array) 형태가 아닙니다.\r\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[디버그] 에러: JSON 데이터에 'states' 키가 없습니다. (요청 횟수 초과 등)\r\n");
                    }
                }
            }
            catch (Exception e)
            {
                // 에러 메시지도 텍스트박스에 띄워서 원인을 바로 볼 수 있게 합니다.
                Console.WriteLine($"\r\n[에러 발생]: {e.Message}\r\n");
            }
        }



        public class DTO_flight
        {
            public string? icao24 { get; set; } // 배열이므로, 연결된 메모리가 없을 때의 상태를 null이라고 함.
            public string? callsign { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public double trueTrack { get; set; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }




    }
}