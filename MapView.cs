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
    public partial class MapView : Form
    {
        public MapView() //  public Map_View()
        {
            //// 기본 세팅 
            InitializeComponent();
            
            gMapControl2.MapProvider = GMapProviders.GoogleMap;
            gMapControl2.Position = new PointLatLng(37.5665, 126.9780);
            gMapControl2.MaxZoom = 24;






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

        //private void Move(ref double longitude, ref double latitude)
        //{

        //}


        private void Map_View_KeyDown(object sender, KeyEventArgs e)
        {


            //gMapControl1.Position = new PointLatLng(Latitude, Longitude);

            //if (e.KeyCode == Keys.Right)
            //{
            //    gMapControl1.Position.Lat += 0.5;
            //    button4.Focus();
            //}
            //if (e.KeyCode == Keys.Left)
            //{
            //    currentLat = gMapControl1.Position.Lat - 0.5;
            //    button3.Focus();
            //}
            //if (e.KeyCode == Keys.Up)
            //{
            //    currentLng = gMapControl1.Position.Lng + 0.5;
            //    button1.Focus();
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    currentLng = gMapControl1.Position.Lng - 0.5;
            //    button2.Focus();
            //}
        }




        // 마커 생성하는 기법()
        // 기존 픽처박스 1개의 이미지 주소 참조해서 마커 생성하는 방법 
        // 정중앙 마커 위치 기반으로 시점이 이동돼는 기법 
        // 방향키 기반으로 정중앙 마커가 이동하는 기능

        //private double Move(double latitude, double longitude)
        //{

        //}

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void Map_View_Load(object sender, EventArgs e)
        {

        }
    }
}