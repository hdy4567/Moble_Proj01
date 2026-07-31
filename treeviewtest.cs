using OpenSky;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Moble_Proj01
{
    public partial class treeviewtest : Form
    {
        public treeviewtest()
        {
            InitializeComponent();
        }







        private void btn_show_Click(object sender, EventArgs e)
        {
            tree_view.Nodes.Add("프로그래밍");
            //tree_view.SelectedNode.Nodes.Add("프로그래밍");
        }

        private void btb_expand_Click(object sender, EventArgs e)
        {
            // 루트노드, 자식노트 지칭하는 인자 이름
            // @ 루트 노드 생성- 추가하는 명령어
            // @ 자식 노드 생성-추가하는 명령어

            tree_view.Nodes.Add("C언어");

            //tree_view.SelectedNode.Nodes.Add("C++");
            //tree_view.SelectedNode.Nodes.Add("C#");

            tree_view.Nodes.Add("임베디드");
            //tree_view.SelectedNode.Nodes.Add("아두이노");
            //tree_view.SelectedNode.Nodes.Add("라즈베리파이");


            tree_view.SelectedNode.ExpandAll();
        }

        private void ntn_collapse_Click(object sender, EventArgs e)
        {
            tree_view.CollapseAll();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (tree_view.SelectedNode.Text != null)
            {
                tree_view.SelectedNode.LastNode.Remove();
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (text_box.Text != null)
            {
                tree_view.SelectedNode.Nodes.Add(text_box.Text);
            }
        }
    }

}