namespace Moble_Proj01
{
    partial class Map_VIrew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            gMapControl2 = new GMap.NET.WindowsForms.GMapControl();
            SuspendLayout();
            // 
            // gMapControl1
            // 
            gMapControl1.Bearing = 0F;
            gMapControl1.CanDragMap = true;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.EmptyTileColor = Color.Navy;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new Point(0, 0);
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 2;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.Name = "gMapControl1";
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RetryLoadTile = 0;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl1.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Size = new Size(800, 450);
            gMapControl1.TabIndex = 0;
            gMapControl1.Zoom = 0D;
            // 
            // gMapControl2
            // 
            gMapControl2.Bearing = 0F;
            gMapControl2.CanDragMap = true;
            gMapControl2.EmptyTileColor = Color.Navy;
            gMapControl2.GrayScaleMode = false;
            gMapControl2.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl2.LevelsKeepInMemory = 5;
            gMapControl2.Location = new Point(0, 0);
            gMapControl2.MarkersEnabled = true;
            gMapControl2.MaxZoom = 2;
            gMapControl2.MinZoom = 2;
            gMapControl2.MouseWheelZoomEnabled = true;
            gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl2.Name = "gMapControl2";
            gMapControl2.NegativeMode = false;
            gMapControl2.PolygonsEnabled = true;
            gMapControl2.RetryLoadTile = 0;
            gMapControl2.RoutesEnabled = true;
            gMapControl2.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl2.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl2.ShowTileGridLines = false;
            gMapControl2.Size = new Size(225, 225);
            gMapControl2.TabIndex = 1;
            gMapControl2.Zoom = 0D;
            // 
            // Map_VIrew
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gMapControl2);
            Controls.Add(gMapControl1);
            Name = "Map_VIrew";
            Text = "Map_VIrew";
            ResumeLayout(false);
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private GMap.NET.WindowsForms.GMapControl gMapControl2;
    }
}