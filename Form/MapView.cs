using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Moble_Proj01.Data; // 데이터 폴더 참조
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Moble_Proj01.Form
{
    public partial class MapView : System.Windows.Forms.Form
    {
        private GMapOverlay markerOverlay;
        private Map_Data dataForm;
        private Dictionary<string, DTO_flight> flight_Dict = new Dictionary<string, DTO_flight>();



        //private Bitmap others_png = new Bitmap(@"C:\Users\moble\source\repos\hdy4567\Moble_Proj01\assets\main.png");
        //private Bitmap main_png = new Bitmap(@"C:\Users\함동윤\source\repos\hdy4567\Moble_Proj01\assets\main.png");
        //C:\Users\moble\source\repos\hdy4567\Moble_Proj01\Resources\others.png

        // 상대 경로로 수정.
        private Bitmap others = Properties.Resources.others;
        private Bitmap main = Properties.Resources.others;
        

        







        private PointLatLng center = new PointLatLng(37.5665, 126.9780);

        private int form_Index = 2;

        // 방향 데이터 저장 전역변수
        private float mainAngle = 0f;
        // 점수 전역 
        private int score = 0;


        //  파괴된 비행기 ID를 보관
        private HashSet<string> destroyedFlights = new HashSet<string>();

        private int Score
        {
            get => score;
            set
            {
                score = value;
                if (label2 != null)
                {
                    label2.Text = $"Score: {score}";
                }
            }
        }

        public MapView()
        {
            InitializeComponent();






            this.gMapControl1.MapProvider = CartoDBDarkMatterProvider.Instance;
            this.gMapControl1.Position = center;
            this.gMapControl1.MaxZoom = 24;
            this.gMapControl1.Zoom = 7;

            this.gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.DragButton = MouseButtons.Left;

            // 개발 단계 확인용: 프로젝트 폴더 하위의 Properties\MapCache를 가리키도록 설정
            string cachePath = System.IO.Path.Combine(Application.StartupPath, "..", "..", "..", "Properties", "MapCache");
            if (!System.IO.Directory.Exists(cachePath))
            {
                System.IO.Directory.CreateDirectory(cachePath);
            }
            this.gMapControl1.CacheLocation = cachePath;
            // 로컬 캐시가 이미 존재한다면 인터넷 다운로드 없이 캐시 타일을 먼저 사용하도록 설정
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            // 프로그램 종료 시, 

            // 에러를 유발하는 구글 맵 스타일 코드 제거




            // 가장 중앙점 이름 재활용과 부모 자원을 지원받으면서, 인자만 바꾸고 싶음.
            //gMapControl1.CenterPen = new Pen(Color.Red, 3);

            // 레이다

            // 마커 오버레이 초기화 및 추가
            markerOverlay = new GMapOverlay("flights");
            this.gMapControl1.Overlays.Add(markerOverlay);

            // 이벤트 구독, 실시간 데이터 수신용
            Map_Data.OnFlightDataUpdated += Map_Data_OnFlightDataUpdated;

            this.KeyPreview = true;
            this.KeyDown += Map_View_KeyDown;
        }

        public MapView(int index) : this()
        {
            this.form_Index = index;

            // 버튼 테두리 설정 
            button1.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderSize = 3;
            button3.FlatAppearance.BorderSize = 3;
            button4.FlatAppearance.BorderSize = 3;



            // @ 이 문제는 아님. 윈폼에서 마커들을 화면에 그리려면 근본적으로 반드시 '오버레이' 레이어가 필요함. 
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

        /// <summary>
        /// Map_Data 폼에서 실시간으로 업데이트되는 비행기 데이터를 받아와서 마커를 갱신하는 이벤트 핸들러
        /// </summary>
        /// <param name="flight_Dict"></param>
        private void Map_Data_OnFlightDataUpdated(Dictionary<string, DTO_flight> flight_Dict)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => Map_Data_OnFlightDataUpdated(flight_Dict)));
                return;
            }

            // 참조 주소 보관
            this.flight_Dict = flight_Dict;

            markerOverlay.Markers.Clear();

            foreach (var flight in flight_Dict.Values)
            {
                //  이미 파괴된 블랙리스트 비행기는 API로 새로 들어와도 그리거나 딕셔너리에 넣지 않고 패스!
                if (destroyedFlights.Contains(flight.icao24)) continue;

                PointLatLng point = new PointLatLng(flight.Latitude, flight.Longitude);

                // OpenSky API의 침로(TrueTrack) 각도를 회전 각도로 전달하여 사용자 지정 회전 마커 생성
                GMapMarker marker = new GMapMarkerRotated(point, others, (float)flight.TrueTrack);

                // 충돌 감지 식별용 태그
                marker.Tag = flight.icao24;

                marker.ToolTipText = $"Callsign: {flight.Callsign}\nID: {flight.icao24}\nTrack: {flight.TrueTrack}°";
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;

                markerOverlay.Markers.Add(marker);
            }

            gMapControl1.Refresh();
        }





        // 3개 형태로 데이터 받아와서 성능비교.

        // 객체 할당 Didctionary 자료구조로,
        //private double ()
        // 객체 할당 list 자료구조로,

        // 객체할당 MySQL DB로, 



        // 마커 생성하는 기법()
        // 기존 픽처박스 1개의 이미지 주소 참조해서 마커 생성하는 방법 
        // 정중앙 마커 위치 기반으로 시점이 이동돼는 기법 
        // 방향키 기반으로 정중앙 마커가 이동하는 기능

        //private double Move(double latitude, double longitude)
        //{

        //}


        private void Move(ref double latitude, ref double longitude)
        {

        }



        /// <summary>
        /// 시스템 명령키를 사전에 가로채서 방향키 입력이 버튼 포커스 전환에 씹히지 않도록 강제 매핑합니다.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & Keys.KeyCode;
            if (key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right)
            {
                // 방향키 입력 시 KeyDown 핸들러를 수동으로 바로 실행시킵니다.
                Map_View_KeyDown(this, new KeyEventArgs(keyData));
                return true; // OS 단의 포커스 전환 기능을 무력화
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 구조체이므로, 값 타입이라 1초에 수십 번 객체 생성 파괴돼지 않으므로, 클래스와 사용법이 다름 
        /// </summary>
        private void Map_View_KeyDown(object sender, KeyEventArgs e)
        {
            // 줌 레벨에 따라 쾌적하게 미끄러지듯 스크롤되도록 동적 밸런싱 스텝 공식 적용
            // (step_size가 3이나 10처럼 크면 한 번에 330km를 순간이동하므로 지도가 로딩되지 않아 멈춘 것처럼 보입니다.)
            double step_size = 0.03 / Math.Pow(2, gMapControl1.Zoom - 7);

            if (e.KeyCode == Keys.Right)
            {
                gMapControl1.Position = new PointLatLng(gMapControl1.Position.Lat, gMapControl1.Position.Lng + step_size);
                button4.Focus();
                mainAngle = 90f; // 동쪽 회전
                e.Handled = true;
                gMapControl1.Refresh(); // 함수로 업데이트 값 UI 반영 
            }
            if (e.KeyCode == Keys.Left)
            {
                gMapControl1.Position = new PointLatLng(gMapControl1.Position.Lat, gMapControl1.Position.Lng - step_size);
                button3.Focus();
                mainAngle = 270f; // 서쪽 회전
                e.Handled = true;
                gMapControl1.Refresh();
            }
            if (e.KeyCode == Keys.Up)
            {
                gMapControl1.Position = new PointLatLng(gMapControl1.Position.Lat + step_size, gMapControl1.Position.Lng);
                button1.Focus();
                mainAngle = 0f; // 북쪽 회전
                e.Handled = true;
                gMapControl1.Refresh();
            }
            if (e.KeyCode == Keys.Down)
            {
                gMapControl1.Position = new PointLatLng(gMapControl1.Position.Lat - step_size, gMapControl1.Position.Lng);
                button2.Focus();
                mainAngle = 180f; // 남쪽 회전
                e.Handled = true;
                gMapControl1.Refresh();
            }

            // 폼 전환 처리 (방향키와 겹치지 않게 Enter / Backspace 키 적용)
            if (e.KeyCode == Keys.Enter)
            {
                Program.Forms[2].Show();
                this.Hide();
            }
            else if (e.KeyCode == Keys.Back)
            {
                Program.Forms[0].Show();
                this.Hide();
            }

            // 기체에 라운드 값 주고, 이동 시 즉각 경량 충돌 검사 수행
            Bumffercar();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void MapView_Load(object sender, EventArgs e)
        {
            dataForm = new Map_Data();

            // 전투기 배경 누끼따기 (흰색 배경 제거), 
            // 흰색 배경을 투명처리 해주는 함수이므로, 누끼 따주는 작업 필수임. 그레이색이여도 아마 안됌
            others.MakeTransparent(Color.White);
            main.MakeTransparent(Color.White);

            // 비트맵 매인 객체 창 크기 기준 가로 50%, 세로 50%의 정확한 정중앙이라는 중심축 배치
            gMapControl1.Paint += (s, pe) =>
            {
                float flight_x = gMapControl1.Width / 2f;
                float flight_y = gMapControl1.Height / 2f;

                // 1. 0.3도 거리를 현재 줌 레벨에 맞는 화면 픽셀 범위로 계산 (시각화 목적)
                PointLatLng mainPos = gMapControl1.Position;
                PointLatLng offsetPos = new PointLatLng(mainPos.Lat, mainPos.Lng + 0.3);
                GPoint p1 = gMapControl1.FromLatLngToLocal(mainPos);
                GPoint p2 = gMapControl1.FromLatLngToLocal(offsetPos);
                float pixelRange = (float)Math.Abs(p2.X - p1.X);

                pe.Graphics.TranslateTransform(flight_x, flight_y); // 중심축

                // 2. 0.3 범위 반경 원 그리기 (반투명 빨간색)
                using (Pen rangePen = new Pen(Color.FromArgb(100, Color.Red), 2))
                {
                    pe.Graphics.DrawEllipse(rangePen, -pixelRange, -pixelRange, pixelRange * 2, pixelRange * 2);
                }

                pe.Graphics.RotateTransform(mainAngle);  // e.ketcode 키보드 입력값에 따라 방향 회전
                pe.Graphics.DrawImage(main, -main.Width / 2f, -main.Height / 2f); // 이미지의 중심을 (cx, cy)에 맞춤
                pe.Graphics.ResetTransform();   // 지도가 삐뚤어지기 전으로 회복

                // 3. 제거한 기체 점수(Score) 화면 좌측 상단에 렌더링
                label2.Text = $"Count: {Score}";
            };
        }

        /// <summary>
        /// 위도/경도 오차 범위 0.3도 내에 들어오는 항공기 를 식별하여 맵과 딕셔너리에서 영구 제거
        /// </summary>
        private void Bumffercar()
        {
            double mainLat = gMapControl1.Position.Lat;
            double mainLng = gMapControl1.Position.Lng;
            double range = 0.3;

            List<string> toRemoveKeys = new List<string>();

            // 1. 딕셔너리에 저장된 비행기 좌표 중 위도/경도 오차가 0.3도 미만인 기체 검색
            foreach (var kvp in flight_Dict)
            {
                var flight = kvp.Value;
                if (Math.Abs(flight.Latitude - mainLat) < range && Math.Abs(flight.Longitude - mainLng) < range)
                {
                    toRemoveKeys.Add(kvp.Key);
                }
            }

            // 2. 충돌한 기체가 없으면 즉시 종료 (얼리 리턴으로 연산 낭비 차단)
            if (toRemoveKeys.Count == 0) return;

            // 3. 일치하는 기체 제거 및 점수 누적
            foreach (var key in toRemoveKeys)
            {
                flight_Dict.Remove(key);
            }
            Score += toRemoveKeys.Count; //  프로퍼티 호출 score 누적 

            // 4. 마커 동기화 및 화면 갱신
            markerOverlay.Markers.Clear();
            foreach (var flight in flight_Dict.Values)
            {
                PointLatLng point = new PointLatLng(flight.Latitude, flight.Longitude);
                GMapMarker marker = new GMapMarkerRotated(point, others, (float)flight.TrueTrack);
                marker.Tag = flight.icao24;
                marker.ToolTipText = $"Callsign: {flight.Callsign}\nID: {flight.icao24}\nTrack: {flight.TrueTrack}°";
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                markerOverlay.Markers.Add(marker);
            }
            gMapControl1.Refresh();
        }





        private void gMapControl2_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //    // 더블클릭 시, 우선 10% 줌 인, 수치를 모르겠으므로 임시 설정.
            //    gMapControl1.Zoom = gMapControl1.Zoom * 10 / 100;
            //}

            //     @ 마우스 롤 아웃 시 휠 인식마다 10% 증가 
            //     @ 드래그 시, 파랑색 생기는 윈도 API
        }
    }

    /// <summary>
    /// 실제 비행 침로 각도(Angle)를 반영하여 회전 드로잉을 수행하는 커스텀 GMap 마커 클래스입니다.
    /// </summary>
    public class GMapMarkerRotated : GMapMarker
    {
        private Bitmap bitmap;
        public float Angle { get; set; }

        public GMapMarkerRotated(PointLatLng pos, Bitmap others, float angle) : base(pos)
        {
            this.bitmap = others;
            this.Angle = angle;

            // 마커 사이즈 지정
            Size = new Size(others.Width, others.Height);
            Offset = new Point(-Size.Width / 2, -Size.Height / 2);
        }

        public override void OnRender(Graphics g)
        {
            // 1. 도화지 축을 마커의 화면 픽셀 좌표 중심으로 이동
            g.TranslateTransform(LocalPosition.X + Size.Width / 2f, LocalPosition.Y + Size.Height / 2f);

            // 2. 비행 방향 침로 각도만큼 회전
            g.RotateTransform(Angle);

            // 3. 축 원점에 맞게 이미지 출력
            g.DrawImage(bitmap, -Size.Width / 2f, -Size.Height / 2f);

            // 4. 도화지 원점 매트릭스 리셋
            g.ResetTransform();
        }
    }

    /// <summary>
    /// CartoDB Dark Matter 타일 맵을 요청하는 커스텀 GMap 프로바이더 클래스입니다.
    /// </summary>
    public class CartoDBDarkMatterProvider : GMapProvider
    {
        public static readonly CartoDBDarkMatterProvider Instance;

        static CartoDBDarkMatterProvider()
        {
            Instance = new CartoDBDarkMatterProvider();
        }

        private CartoDBDarkMatterProvider()
        {
            RefererUrl = "https://carto.com/";
        }

        public override Guid Id { get; } = new Guid("9E4E2C7B-647C-4C67-AF21-DC814E7374CC");

        public override string Name { get; } = "CartoDarkMyMap";

        public override PureProjection Projection => MercatorProjection.Instance;

        public override GMapProvider[] Overlays => new GMapProvider[] { this };

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            // CartoDB Dark Matter 스타일의 타일 리소스 URL
            // {s} 위치는 부하 분산을 위해 a, b, c, d 서버 중 하나를 임의 지정합니다.
            string sub = "abcd"[(int)((pos.X + pos.Y) % 4)].ToString();
            string url = $"https://{sub}.basemaps.cartocdn.com/rastertiles/dark_all/{zoom}/{pos.X}/{pos.Y}.png";

            return GetTileImageUsingHttp(url);
        }
    }
}