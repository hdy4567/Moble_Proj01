namespace Moble_Proj01
{
    partial class treeviewtest
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
            btn_show = new Button();
            btn_add = new Button();
            btb_expand = new Button();
            btn_delete = new Button();
            ntn_collapse = new Button();
            tree_view = new TreeView();
            text_box = new TextBox();
            SuspendLayout();
            // 
            // btn_show
            // 
            btn_show.Location = new Point(374, 80);
            btn_show.Name = "btn_show";
            btn_show.Size = new Size(100, 39);
            btn_show.TabIndex = 0;
            btn_show.Text = "보기";
            btn_show.UseVisualStyleBackColor = true;
            btn_show.Click += btn_show_Click;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(374, 136);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(100, 39);
            btn_add.TabIndex = 1;
            btn_add.Text = "추가";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btb_expand
            // 
            btb_expand.Location = new Point(374, 256);
            btb_expand.Name = "btb_expand";
            btb_expand.Size = new Size(100, 39);
            btb_expand.TabIndex = 3;
            btb_expand.Text = "확장";
            btb_expand.UseVisualStyleBackColor = true;
            btb_expand.Click += btb_expand_Click;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(374, 193);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(100, 39);
            btn_delete.TabIndex = 2;
            btn_delete.Text = "삭제";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // ntn_collapse
            // 
            ntn_collapse.Location = new Point(374, 313);
            ntn_collapse.Name = "ntn_collapse";
            ntn_collapse.Size = new Size(100, 39);
            ntn_collapse.TabIndex = 7;
            ntn_collapse.Text = "축소";
            ntn_collapse.UseVisualStyleBackColor = true;
            ntn_collapse.Click += ntn_collapse_Click;
            // 
            // tree_view
            // 
            tree_view.Location = new Point(12, 12);
            tree_view.Name = "tree_view";
            tree_view.Size = new Size(340, 409);
            tree_view.TabIndex = 8;
            // 
            // text_box
            // 
            text_box.Location = new Point(374, 40);
            text_box.Name = "text_box";
            text_box.Size = new Size(100, 23);
            text_box.TabIndex = 9;
            text_box.Text = "-";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(text_box);
            Controls.Add(tree_view);
            Controls.Add(ntn_collapse);
            Controls.Add(btb_expand);
            Controls.Add(btn_delete);
            Controls.Add(btn_add);
            Controls.Add(btn_show);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_show;
        private Button btn_add;
        private Button btb_expand;
        private Button btn_delete;
        private Button ntn_collapse;
        private TreeView tree_view;
        private TextBox text_box;
    }
}