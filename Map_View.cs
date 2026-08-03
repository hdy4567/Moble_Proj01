using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moble_Proj01
{
    public partial class Map_View : Form
    {
        public Map_View(GMapControl gMapControl1) //  public Map_View()
        {
            // 기본 세팅 
            InitializeComponent();
            this.gMapControl1 = gMapControl1;
            this.gMapControl1.MapProvider = GMapProviders.GoogleMap;

            gMapControl1.Position = new PointLatLng(37.5665, 126.9780);
            gMapControl1.MaxZoom = 24;
            // FormBorderStyle을 None
            //WindowState를 Maximized(최대화)

            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.DragButton = MouseButtons.Left;

            // 가장 중앙점 이름 재활용과 부모 자원을 지원받으면서, 인자만 바꾸고 싶음.
            //gMapControl1.CenterPen = new Pen(Color.Red, 3);
            // 레이다


            button1.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderSize = 3;
            button3.FlatAppearance.BorderSize = 3;
            button4.FlatAppearance.BorderSize = 3;





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

        private void Move (ref double longitude, ref double latitude)
        {

        }
        

        private void Map_View_KeyDown(object sender, KeyEventArgs e)
        {


            gMapControl1.Position = new PointLatLng(Latitude, Longitude);

            if (e.KeyCode == Keys.Right)
            {
                gMapControl1.Position.Lat += 0.5;
                button4.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                currentLat = gMapControl1.Position.Lat - 0.5;
                button3.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                currentLng = gMapControl1.Position.Lng + 0.5;
                button1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                currentLng = gMapControl1.Position.Lng - 0.5;
                button2.Focus();
            }
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void Map_View_Load(object sender, EventArgs e)
        {

        }
    }
}