using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;




namespace Moble_Proj01
{
    public partial class Form1 : Form
    {

        PointLatLng start;
        PointLatLng end;




        public Form1()
        {

            InitializeComponent();
            


            // 새 정보로 다시 요청하라.
            GMap.NET.MapProviders.GMapProvider.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
            // 통행 정보
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;


            gMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            //gMapControl1.MapProvider = GMap.NET.MapProviders.OpenCycleTransportMapProvider.Instance;
            //gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;


            gMapControl1.ShowCenter = false;
            gMapControl1.Position = new PointLatLng(37.497872, 127.0275142);
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.Zoom = 12;
        }





        // @ 이 문제는 아님. User 정보
        //전 세계 자원봉사자들의 서버로 운영 User 정보나 Referer 명시해줘야함
        //GMapProvider.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) MyGMapApp/1.0";

        // @ 이 문제는 아님. 타일 서버 요청 주소
        //GMaps.Instance.Mode = AccessMode.ServerOnly;

        // @ 이 문제는 아님. 표준적인 제공
        //gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
        //GMaps.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;







        // @ 이 문제는 아님. 윈폼에서 마커들을 화면에 그리려면 반드시 '오버레이' 레이어가 필요합니다.
        GMapOverlay markerOverlay;
        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                // 클릭한 윈폼 UI의 화면 픽셀 좌표(X, Y)를 실제 지도의 위도/경도로 변환
                PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

                // 윈폼 전용 작은 빨간색 구글 마커 생성
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);

                // 오버레이 공책에 마커를 추가하여 화면에 즉시 렌더링
                markerOverlay.Markers.Add(marker);
            }
        }
    }
}

