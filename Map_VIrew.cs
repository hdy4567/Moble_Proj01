using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moble_Proj01
{
    public partial class MapView : Form
    {
        private GMapOverlay markerOverlay;
        private Map_Data dataForm;

        public MapView()
        {
            InitializeComponent();

            // User 정보 명시 (구글 맵 차단 방지)
            //GMap.NET.MapProviders.GMapProvider.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
            // 서버 통신 모드
            //GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            gMapControl2.Position = new PointLatLng(36.5, 127.5); // 대한민국 중심 좌표로 초기 위치 설정
            gMapControl2.Zoom = 7; // 한국 전역이 보이도록 줌 설정

            // 마커 오버레이 초기화 및 추가
            markerOverlay = new GMapOverlay("flights");
            gMapControl1.Overlays.Add(markerOverlay);

            // 이벤트 구독
            Map_Data.OnFlightDataUpdated += Map_Data_OnFlightDataUpdated;
        }

        private void Map_Data_OnFlightDataUpdated(List<Flight> flights)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Map_Data_OnFlightDataUpdated(flights)));
                return;
            }

            markerOverlay.Markers.Clear();

            foreach (var flight in flights)
            {
                PointLatLng point = new PointLatLng(flight.Latitude, flight.Longitude);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);
                marker.ToolTipText = $"Callsign: {flight.Callsign}\nID: {flight.Icao24}\nTrack: {flight.TrueTrack}°";
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                markerOverlay.Markers.Add(marker);
            }

            gMapControl1.Refresh();
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            // Map_Data 폼을 생성하여 백그라운드 데이터 수신 구동
            dataForm = new Map_Data();
            dataForm.Show();
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //    // 더블클릭 시, 우선 10% 줌 인, 수치를 모르겠으므로 임시 설정.
            //    gMapControl1.Zoom = gMapControl1.Zoom * 10 / 100;
            //}

            //     @ 마우스 롤 아웃 시 휠 인식마다 10% 증가 
            //     @ 드래그 시, 파랑색 생기는 윈도 API

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (tbNode.Text == "")
            //{
            //    MessageBox.Show("텍스트 박스에 입력하세요.");
            //    return;
            //}

            //if (treeView1.SelectedNode != null)
            //{ //선택된 노드 아래에 노드추가
            //    treeView1.SelectedNode.Nodes.Add(tbNode.Text);
            //    tbNode.Text = "";
            //}
            //else
            //{
            //    treeView1.Nodes.Add(tbNode.Text); //전체 노드 아래에 노드추가
            //    tbNode.Text = "";
            //}


            // @ 이 문제는 아님. 윈폼에서 마커들을 화면에 그리려면 반드시 '오버레이' 레이어가 필요합니다.
            //GMapOverlay markerOverlay;
            //private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
            //{

            //    if (e.Button == MouseButtons.Left)
            //    {
            //        // 클릭한 윈폼 UI의 화면 픽셀 좌표(X, Y)를 실제 지도의 위도/경도로 변환
            //        PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

            //        // 윈폼 전용 작은 빨간색 구글 마커 생성
            //        GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);

            //        // 오버레이 공책에 마커를 추가하여 화면에 즉시 렌더링
            //        markerOverlay.Markers.Add(marker);
            //    }
            //}

            //gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            //gMapControl1.MapProvider = GMap.NET.MapProviders.OpenCycleTransportMapProvider.Instance;
            //gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;

            // 프로퍼티
            //gMapControl1.ShowCenter = false;
            //gMapControl1.MapProvider = GMapProviders.GoogleMap;

        }



        private void gMapControl1_Load(object sender, EventArgs e)
        {
        }
    }
}
