using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moble_Proj01.Form
{
    public partial class README : System.Windows.Forms.Form
    {
        private int form_Index = 0;

        public README()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += README_KeyDown;
        }

        public README(int index) : this()
        {
            this.form_Index = index;
        }

        private void README_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                Program.Forms[1].Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // 디자이너 파일에 버튼 이벤트 이미지 사진 클릭 이벤트에 바인딩 
        private void btn_github_Click_1(object sender, EventArgs e)
        {
            // Github link open
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/hdy4567/Moble_Proj01",
                UseShellExecute = true
            });
        }

        private void btn_notion_Click(object sender, EventArgs e)
        {
            // Notion link open
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://gregarious-hare-5ed.notion.site/Moble_FP1-layer1_-3b83f0c4452280a5ab78d4b678a8a4b4?source=copy_link",
                UseShellExecute = true
            });

        }

        private void btn_figma_Click(object sender, EventArgs e)
        {
            // Figma link open
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.figma.com/board/ZSxVAAqxZhkMninAvKdKdy/Moble_Proj01?node-id=0-1&t=x5fy5d9hlG7vWbOH-1",
                UseShellExecute = true
            });
        }

        private void README_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_next, "Enter나 화살표 클릭으로 넘어갈 수 있습니다.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.None;

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Program.Forms[1].Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_hambuger_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.Forms[0].Show();

            this.Hide();
        }

        private void preViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Forms[1].Show();

            this.Hide();
        }

        private void mapViewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mapViewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Program.Forms[2].Show();

            this.Hide();
        }

        private void ctm_hamburgerBtn_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btn_hamburger_Click(object sender, EventArgs e)
        {
            ctm_hamburgerBtn.Show();
        }
    }
}
