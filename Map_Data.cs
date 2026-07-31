using OpenSky;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moble_Proj01
{
    public partial class Map_Data : Form
    {   // 클라이언트 객체 생성
        private static readonly HttpClient httpClient = new HttpClient();
        public async Task Syn_CallApi()
        { // root url 
            string url = "https://opensky-network.org/api";
            //httpClient.DefaultRequestHeaders.Add("User")

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
        }



        public Map_Data()
        {
            InitializeComponent();
        }



        public async Task GetFlightDataAsync()
        {
            OpenSkyStates states = null;

            try
            {
                Syn_CallApi();
                foreach ( var str in response) { 
                    textBox1.Text = "OpenSky API 호출 중 (한국 상공)...\r\n";

                OpenSkyClient client = new OpenSkyClient();

                // 💡 [핵심 수정] 전 세계 데이터가 아니라 '한국 상공' 지역만 딱 잘라서 요청합니다.
                OpenSkyRegion koreaRegion = new OpenSkyRegion
                {
                    MinLatitude = 33.0f,
                    MaxLatitude = 38.5f,
                    MinLongitude = 124.5f,
                    MaxLongitude = 131.5f
                };

                // 지역 조건을 파라미터로 넣어줍니다.
                states = await client.GetStatesAsync(region : koreaRegion);

                if (states != null && states.States != null)
                {
                    int totalFlights = states.States.Count();
                    textBox1.AppendText($"현재 상공의 총 항공기 수: {totalFlights}대\r\n\r\n");

                    // StringBuilder로 텍스트를 모읍니다.
                    StringBuilder sb = new StringBuilder();

                    foreach (var state in states.States)
                    {
                        string icao24 = state.Icao24;
                        string callsign = state.Callsign?.Trim() ?? "N/A";
                        double? Latitude = state.Latitude;
                        double? Longitude = state.Longitude;
                        float? TrueTrack = state.TrueTrack;
                        
                        if (Latitude.HasValue && Longitude.HasValue)
                        {
                            // 💡 AppendLine으로 한 줄씩 차곡차곡 누적시킵니다.
                            sb.AppendLine($"[{callsign}] ID: {icao24} | 위치: ({Latitude:F4}, {Longitude:F4}) | 방향: {TrueTrack}도");
                        }
                    }

                    // 모아둔 텍스트를 한 번에 텍스트박스에 이어 붙입니다.
                    textBox1.AppendText(sb.ToString());
                }
                else
                {
                    textBox1.AppendText("현재 조회된 항공기 데이터가 없습니다.\r\n");
                }
            }
            catch (Exception e)
            {
                // 에러 메시지도 텍스트박스에 띄워서 원인을 바로 볼 수 있게 합니다.
                textBox1.AppendText($"\r\n[에러 발생]: {e.Message}\r\n");
            }
        }
    }
}