namespace Moble_Proj01.Form
{
    partial class Preview
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
            pictureBox1 = new PictureBox();
            btn_next = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Api썸네;
            pictureBox1.Location = new Point(404, 50);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(634, 163);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btn_next
            // 
            btn_next.Font = new Font("맑은 고딕", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btn_next.Location = new Point(533, 295);
            btn_next.Margin = new Padding(2, 2, 2, 2);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(71, 82);
            btn_next.TabIndex = 34;
            btn_next.Text = "▶";
            btn_next.TextAlign = ContentAlignment.BottomCenter;
            btn_next.UseVisualStyleBackColor = true;
            btn_next.Click += btn_next_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Architecture;
            pictureBox2.Location = new Point(11, -58);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(360, 551);
            pictureBox2.TabIndex = 35;
            pictureBox2.TabStop = false;
            // 
            // Preview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 475);
            Controls.Add(pictureBox2);
            Controls.Add(btn_next);
            Controls.Add(pictureBox1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Preview";
            Text = "Preview";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button btn_next;
        private PictureBox pictureBox2;
    }
}