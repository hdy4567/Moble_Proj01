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
    public partial class Preview : System.Windows.Forms.Form
    {
        private int form_Index = 1;

        public Preview()
        {
            InitializeComponent();
        }
        public Preview(int index) : this()
        {
            this.form_Index = index;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Program.Forms[2].Show();
            this.Hide();
        }
    }
}
