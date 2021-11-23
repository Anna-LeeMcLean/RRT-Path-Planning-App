
namespace UI_Layout
{
    partial class UI_pathfinding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI_pathfinding));
            this.path_window = new System.Windows.Forms.PictureBox();
            this.lbl_path_window = new System.Windows.Forms.Label();
            this.btn_generate_path = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_select_pt = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_end = new System.Windows.Forms.Button();
            this.btn_rectangle = new System.Windows.Forms.Button();
            this.btn_circle = new System.Windows.Forms.Button();
            this.btn_remove_obsatcle = new System.Windows.Forms.Button();
            this.lbl_usr_obstacle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.path_window)).BeginInit();
            this.SuspendLayout();
            // 
            // path_window
            // 
            this.path_window.Image = ((System.Drawing.Image)(resources.GetObject("path_window.Image")));
            this.path_window.Location = new System.Drawing.Point(12, 12);
            this.path_window.Name = "path_window";
            this.path_window.Size = new System.Drawing.Size(604, 300);
            this.path_window.TabIndex = 0;
            this.path_window.TabStop = false;
            // 
            // lbl_path_window
            // 
            this.lbl_path_window.AutoSize = true;
            this.lbl_path_window.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_path_window.Location = new System.Drawing.Point(12, 315);
            this.lbl_path_window.Name = "lbl_path_window";
            this.lbl_path_window.Size = new System.Drawing.Size(184, 17);
            this.lbl_path_window.TabIndex = 1;
            this.lbl_path_window.Text = "Display Window for Path";
            // 
            // btn_generate_path
            // 
            this.btn_generate_path.AutoSize = true;
            this.btn_generate_path.BackColor = System.Drawing.SystemColors.Desktop;
            this.btn_generate_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generate_path.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_generate_path.Location = new System.Drawing.Point(255, 375);
            this.btn_generate_path.Name = "btn_generate_path";
            this.btn_generate_path.Size = new System.Drawing.Size(140, 30);
            this.btn_generate_path.TabIndex = 2;
            this.btn_generate_path.Text = "Generate Path";
            this.btn_generate_path.UseVisualStyleBackColor = false;
            // 
            // btn_reset
            // 
            this.btn_reset.AutoSize = true;
            this.btn_reset.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_reset.Location = new System.Drawing.Point(541, 375);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 30);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_select_pt
            // 
            this.btn_select_pt.AutoSize = true;
            this.btn_select_pt.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_select_pt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_select_pt.Location = new System.Drawing.Point(634, 40);
            this.btn_select_pt.Name = "btn_select_pt";
            this.btn_select_pt.Size = new System.Drawing.Size(137, 30);
            this.btn_select_pt.TabIndex = 4;
            this.btn_select_pt.Text = "Select a Point";
            this.btn_select_pt.UseVisualStyleBackColor = false;
            this.btn_select_pt.Click += new System.EventHandler(this.btn_select_pt_Click);
            // 
            // btn_start
            // 
            this.btn_start.AutoSize = true;
            this.btn_start.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_start.Location = new System.Drawing.Point(664, 101);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 30);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_end
            // 
            this.btn_end.AutoSize = true;
            this.btn_end.BackColor = System.Drawing.Color.Tomato;
            this.btn_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_end.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_end.Location = new System.Drawing.Point(664, 137);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(75, 30);
            this.btn_end.TabIndex = 6;
            this.btn_end.Text = "End";
            this.btn_end.UseVisualStyleBackColor = false;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // btn_rectangle
            // 
            this.btn_rectangle.AutoSize = true;
            this.btn_rectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rectangle.Location = new System.Drawing.Point(664, 231);
            this.btn_rectangle.Name = "btn_rectangle";
            this.btn_rectangle.Size = new System.Drawing.Size(103, 30);
            this.btn_rectangle.TabIndex = 7;
            this.btn_rectangle.Text = "Rectangle";
            this.btn_rectangle.UseVisualStyleBackColor = true;
            // 
            // btn_circle
            // 
            this.btn_circle.AutoSize = true;
            this.btn_circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_circle.Location = new System.Drawing.Point(664, 260);
            this.btn_circle.Name = "btn_circle";
            this.btn_circle.Size = new System.Drawing.Size(103, 30);
            this.btn_circle.TabIndex = 8;
            this.btn_circle.Text = "Circle";
            this.btn_circle.UseVisualStyleBackColor = true;
            // 
            // btn_remove_obsatcle
            // 
            this.btn_remove_obsatcle.AutoSize = true;
            this.btn_remove_obsatcle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove_obsatcle.Location = new System.Drawing.Point(625, 296);
            this.btn_remove_obsatcle.Name = "btn_remove_obsatcle";
            this.btn_remove_obsatcle.Size = new System.Drawing.Size(167, 30);
            this.btn_remove_obsatcle.TabIndex = 9;
            this.btn_remove_obsatcle.Text = "Remove Obstacle";
            this.btn_remove_obsatcle.UseVisualStyleBackColor = true;
            // 
            // lbl_usr_obstacle
            // 
            this.lbl_usr_obstacle.AutoSize = true;
            this.lbl_usr_obstacle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_usr_obstacle.Location = new System.Drawing.Point(622, 211);
            this.lbl_usr_obstacle.Name = "lbl_usr_obstacle";
            this.lbl_usr_obstacle.Size = new System.Drawing.Size(139, 13);
            this.lbl_usr_obstacle.TabIndex = 10;
            this.lbl_usr_obstacle.Text = "User Input for Obstacle";
            // 
            // UI_pathfinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.lbl_usr_obstacle);
            this.Controls.Add(this.btn_remove_obsatcle);
            this.Controls.Add(this.btn_circle);
            this.Controls.Add(this.btn_rectangle);
            this.Controls.Add(this.btn_end);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_select_pt);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_generate_path);
            this.Controls.Add(this.lbl_path_window);
            this.Controls.Add(this.path_window);
            this.Name = "UI_pathfinding";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.path_window)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox path_window;
        private System.Windows.Forms.Label lbl_path_window;
        private System.Windows.Forms.Button btn_generate_path;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_select_pt;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button btn_rectangle;
        private System.Windows.Forms.Button btn_circle;
        private System.Windows.Forms.Button btn_remove_obsatcle;
        private System.Windows.Forms.Label lbl_usr_obstacle;
    }
}

