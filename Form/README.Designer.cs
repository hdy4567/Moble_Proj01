namespace Moble_Proj01.Form
{
    partial class README : System.Windows.Forms.Form
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
            components = new System.ComponentModel.Container();
            panel3 = new Panel();
            btn_figma = new Button();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            btn_notion = new Button();
            pictureBox4 = new PictureBox();
            panel1 = new Panel();
            btn_github = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            toolTip1 = new ToolTip(components);
            btn_next = new Button();
            ctm_hamburgerBtn = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            preViewToolStripMenuItem = new ToolStripMenuItem();
            mapViewToolStripMenuItem = new ToolStripMenuItem();
            btn_hamburger = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ctm_hamburgerBtn.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(btn_figma);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(25, 223);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(237, 26);
            panel3.TabIndex = 10;
            // 
            // btn_figma
            // 
            btn_figma.Dock = DockStyle.Fill;
            btn_figma.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btn_figma.ImageAlign = ContentAlignment.TopLeft;
            btn_figma.Location = new Point(29, 0);
            btn_figma.Margin = new Padding(2);
            btn_figma.Name = "btn_figma";
            btn_figma.Size = new Size(208, 26);
            btn_figma.TabIndex = 16;
            btn_figma.Text = "Figma";
            btn_figma.TextAlign = ContentAlignment.MiddleLeft;
            btn_figma.UseVisualStyleBackColor = true;
            btn_figma.Click += btn_figma_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.Window;
            pictureBox3.Dock = DockStyle.Left;
            pictureBox3.Image = Properties.Resources.피그마썸네일;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Margin = new Padding(2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(29, 26);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            pictureBox3.Click += btn_figma_Click;
            pictureBox3.MouseEnter += pictureBox3_MouseEnter;
            pictureBox3.MouseLeave += pictureBox3_MouseLeave;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(btn_notion);
            panel4.Controls.Add(pictureBox4);
            panel4.Location = new Point(25, 283);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(237, 26);
            panel4.TabIndex = 11;
            panel4.Paint += panel4_Paint;
            // 
            // btn_notion
            // 
            btn_notion.Dock = DockStyle.Fill;
            btn_notion.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btn_notion.Location = new Point(29, 0);
            btn_notion.Margin = new Padding(2);
            btn_notion.Name = "btn_notion";
            btn_notion.Size = new Size(208, 26);
            btn_notion.TabIndex = 16;
            btn_notion.Text = "Notion";
            btn_notion.TextAlign = ContentAlignment.MiddleLeft;
            btn_notion.UseVisualStyleBackColor = true;
            btn_notion.Click += btn_notion_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = SystemColors.Window;
            pictureBox4.Dock = DockStyle.Left;
            pictureBox4.Image = Properties.Resources.노션썸네일;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Margin = new Padding(2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(29, 26);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 14;
            pictureBox4.TabStop = false;
            pictureBox4.Click += btn_notion_Click;
            pictureBox4.MouseEnter += pictureBox4_MouseEnter;
            pictureBox4.MouseLeave += pictureBox4_MouseLeave;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(btn_github);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(25, 253);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 26);
            panel1.TabIndex = 12;
            // 
            // btn_github
            // 
            btn_github.Dock = DockStyle.Fill;
            btn_github.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btn_github.Location = new Point(29, 0);
            btn_github.Margin = new Padding(2);
            btn_github.Name = "btn_github";
            btn_github.Size = new Size(208, 26);
            btn_github.TabIndex = 16;
            btn_github.Text = "Github";
            btn_github.TextAlign = ContentAlignment.MiddleLeft;
            btn_github.UseVisualStyleBackColor = true;
            btn_github.Click += btn_github_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.깃허브썸네일;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 26);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += btn_github_Click_1;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaption;
            textBox1.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(25, 95);
            textBox1.Margin = new Padding(2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(271, 77);
            textBox1.TabIndex = 18;
            textBox1.Text = "▶ 프로젝트 담당자 : 함동윤\r\n▶010-5033-4000\r\n▶@gmail.com\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(25, 324);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(216, 21);
            label3.TabIndex = 24;
            label3.Text = "○ 개발기간 : 08.03 ~ 08.09";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Window;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(25, 343);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(570, 105);
            label2.TabIndex = 25;
            label2.Text = "○ 주요기술 : \r\n    - Layer1.WinForms, GMap.NET, OpenSky Api \r\n    - Layer2.\r\n    - Layer3.\r\n○ 주요기능: 10초마다, 실시간 항공기 경로 트래킹, 지도 커스텀 마커 표시 등";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.CausesValidation = false;
            label4.Font = new Font("맑은 고딕", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(25, 23);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(306, 86);
            label4.TabIndex = 26;
            label4.Text = "Portfolio";
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ActiveCaptionText;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(44, 23);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(664, 6);
            label5.TabIndex = 28;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ActiveCaptionText;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Location = new Point(25, 172);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(511, 6);
            label6.TabIndex = 29;
            label6.Text = "label6";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.CausesValidation = false;
            label8.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(25, 192);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(152, 32);
            label8.TabIndex = 31;
            label8.Text = "🚀 바로가기";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // btn_next
            // 
            btn_next.Font = new Font("맑은 고딕", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btn_next.Location = new Point(545, 260);
            btn_next.Margin = new Padding(2);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(71, 82);
            btn_next.TabIndex = 33;
            btn_next.Text = "▶";
            btn_next.TextAlign = ContentAlignment.BottomCenter;
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // ctm_hamburgerBtn
            // 
            ctm_hamburgerBtn.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
            ctm_hamburgerBtn.ImageScalingSize = new Size(24, 24);
            ctm_hamburgerBtn.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, preViewToolStripMenuItem, mapViewToolStripMenuItem });
            ctm_hamburgerBtn.Name = "contextMenuStrip1";
            ctm_hamburgerBtn.Size = new Size(224, 94);
            ctm_hamburgerBtn.Text = "목차";
            ctm_hamburgerBtn.Opening += ctm_hamburgerBtn_Opening;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(223, 30);
            toolStripMenuItem1.Text = "ㅇ I. README";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // preViewToolStripMenuItem
            // 
            preViewToolStripMenuItem.Name = "preViewToolStripMenuItem";
            preViewToolStripMenuItem.Size = new Size(223, 30);
            preViewToolStripMenuItem.Text = "ㅇ II. Preview";
            preViewToolStripMenuItem.Click += preViewToolStripMenuItem_Click;
            // 
            // mapViewToolStripMenuItem
            // 
            mapViewToolStripMenuItem.Name = "mapViewToolStripMenuItem";
            mapViewToolStripMenuItem.Size = new Size(223, 30);
            mapViewToolStripMenuItem.Text = "ㅇ III. MapView";
            mapViewToolStripMenuItem.Click += mapViewToolStripMenuItem_Click_1;
            // 
            // btn_hamburger
            // 
            btn_hamburger.ContextMenuStrip = ctm_hamburgerBtn;
            btn_hamburger.FlatAppearance.BorderSize = 0;
            btn_hamburger.FlatStyle = FlatStyle.Flat;
            btn_hamburger.ForeColor = Color.Transparent;
            btn_hamburger.Image = Properties.Resources.햄버거버튼2;
            btn_hamburger.Location = new Point(-2, 7);
            btn_hamburger.Margin = new Padding(2);
            btn_hamburger.Name = "btn_hamburger";
            btn_hamburger.Size = new Size(42, 35);
            btn_hamburger.TabIndex = 35;
            btn_hamburger.UseVisualStyleBackColor = true;
            btn_hamburger.Click += btn_hamburger_Click;
            // 
            // README
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1299, 637);
            Controls.Add(btn_hamburger);
            Controls.Add(btn_next);
            Controls.Add(label8);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Margin = new Padding(2);
            Name = "README";
            Text = "README";
            Load += README_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ctm_hamburgerBtn.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel4;
        private PictureBox pictureBox4;
        private Panel panel3;
        private PictureBox pictureBox3;
        private Button btn_notion;
        private Button btn_figma;
        private Panel panel1;
        private Button btn_github;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private ToolTip toolTip1;
        private Button btn_next;
        private ContextMenuStrip ctm_hamburgerBtn;
        private ToolStripMenuItem toolStripMenuItem1;
        private Button btn_hamburger;
        private ToolStripMenuItem preViewToolStripMenuItem;
        private ToolStripMenuItem mapViewToolStripMenuItem;
    }
}