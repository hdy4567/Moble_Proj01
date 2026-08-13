using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;
using Xunit.Sdk;

namespace Moble_Proj01.Data
{
    public class Map_Data
    {   // 클라이언트 객체 생성
        private static readonly HttpClient httpClient = new HttpClient();

        // 항공기 데이터 업데이트 이벤트 선언
        //public static event Action<List<DTO_flight>> OnFlightDataUpdated;
        public static event Action<Dictionary<string, DTO_flight>> OnFlightDataUpdated;






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




        // 비동기 ㅁ ㅁ 함수 선언 ㅁ = async, ㅁ = Task;
        public async Task GetFlightDataAsync()
        {
            bool flag = true;

            // 게임 동안에 10초마다 업데이트
            while (true)
            {
                try
                {
                    Console.WriteLine("호출중");


                    // 공식 REST API 스펙에 따른 Bounding Box 쿼리 파라미터 적용
                    string url = "https://opensky-network.org/api/states/all?lamin=33.0&lomin=124.5&lamax=38.5&lomax=131.5";
                    HttpResponseMessage response = await httpClient.GetAsync(url);



                    if (flag)
                    {
                        MessageBox.Show($" 업데이트 ! : {(int)response.StatusCode} {response.ReasonPhrase}\r\n", "디버그 정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flag = false;
                    }


                    response.EnsureSuccessStatusCode();

                    string jsonString = await response.Content.ReadAsStringAsync();

                    // [디버그 계층] 원본 데이터 길이 및 프리뷰(미리보기)
                    //Console.WriteLine($"[디버그] 수신된 데이터 길이: {jsonString.Length}자\r\n");

                    //string preview = jsonString.Length > 100 ? jsonString.Substring(0, 100) + "..." : jsonString;
                    //Console.WriteLine($"[디버그] 원본 데이터 요약: {preview}\r\n\r\n");

                    // async 수행 후 메모리 꺼주기 
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        // 타입을 모르는 JSON 데이터를 안전하게 처리하기 위해, JsonDocument를 사용하여 JSON 구조를 탐색
                        // 즉 var + 리스트 + foreach 문법으로, JSON 배열을 순회하면서 각 항공기 데이터를 DTO_flight 객체로 변환
                        // 역직렬화로, 내 프로그램이 이해할 수 있는 형태로 변환. 
                        JsonElement root = doc.RootElement;
                        if (root.TryGetProperty("states", out JsonElement statesElement))

                        {
                            if (statesElement.ValueKind == JsonValueKind.Array)
                            {
                                int totalFlights = statesElement.GetArrayLength();
                                Console.WriteLine($"현재 상공의 총 항공기 수: {totalFlights}대\r\n\r\n ");


                                // api 디버깅용 자료구조
                                StringBuilder sb = new StringBuilder();

                                // 제어용 중간 산출물 자료구조 선언, 키 값을 받지 못했으므로, 
                                // 키 값 받고나서, 제어용 딕셔너리 자료구조로 변환 및 선언 
                                List<DTO_flight> flight_list = new List<DTO_flight>();

                                foreach (JsonElement state in statesElement.EnumerateArray())
                                {
                                    // 배열 인덱스: [0]icao24, [1]callsign, [5]longitude, [6]latitude, [10]true_track
                                    string icao24 = state[0].GetString();
                                    string callsign = state[1].ValueKind == JsonValueKind.String ? state[1].GetString().Trim() : "N/A";

                                    // if 보단 스위치식 상태머신 패턴을 쓰고 싶은데, 
                                    // 스위치 상태머신에 인자로 넣어주려면, 하나로 묶어 주어야 하고,
                                    // 변수를 C언어식으로 하나로 묶어주고 싶으면서, 간단하게 짜고 싶다면 구조체가 아닌, 
                                    // var 타입 + 튜플 문법을 쓰면, 구현 가능함. 


                                    // 튜플 객체 생성으로, 성능은 if 대비 약간 구려져도, 
                    // 두 개의 상태 데이터 맥락을 하나로 묶어주고, 스위치 문법에 인자로 넣어줄 수 있게 됌.
                                    // if ( xy_state == (JsonValueKind.Number, JsonValueKind.Number))
                                    //if (state[6].ValueKind == JsonValueKind.Number && state[5].ValueKind == JsonValueKind.Number)
                                    //if (xy_state.Item1 == JsonValueKind.Number && xy_state.Item2 == JsonValueKind.Number)
                                    var xy_state = (state[5].ValueKind, state[6].ValueKind);
                                    switch (xy_state)
                                    {
                                        case (JsonValueKind.Number, JsonValueKind.Number):
                                            double latitude = state[6].GetDouble();
                                            double longitude = state[5].GetDouble();
                                            double trueTrack = state[10].ValueKind == JsonValueKind.Number ? state[10].GetDouble() : 0.0;

                                            sb.AppendLine($"[{callsign}] ID: {icao24} | 위치: ({latitude:F4}, {longitude:F4}) | 방향: {trueTrack}도");

                                            flight_list.Add(new DTO_flight
                                            {
                                                icao24 = icao24,
                                                Callsign = callsign,
                                                Latitude = latitude,
                                                Longitude = longitude,
                                                TrueTrack = trueTrack
                                            });
                                            break;

                                        default:
                                            sb.AppendLine($"[데이터 누락] ID : {icao24} | 위치 정보 없음");
                                            break;
                                    }
                                }

                                // 디버깅이나 로그 출력용 
                                //Console.WriteLine(sb.ToString());
                                // 모든 데이터 처리가 끝난 후(루프 외부) 최종 출력 및 이벤트 발행
                                Dictionary<string, DTO_flight> flight_Dict = flight_list.ToDictionary(f => f.icao24, f => f);
                                OnFlightDataUpdated?.Invoke(flight_Dict);

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

                // while과 연동, 10초 대기 후 다음 주기 실행
                await Task.Delay(10000);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }



}