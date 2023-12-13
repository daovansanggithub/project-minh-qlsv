namespace QLSV333
{
    partial class nguoidung
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
            this.dataGridViewtim = new System.Windows.Forms.DataGridView();
            this.btnTim = new System.Windows.Forms.Button();
            this.txttim = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.lbltb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtim)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewtim
            // 
            this.dataGridViewtim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewtim.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewtim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewtim.Location = new System.Drawing.Point(12, 183);
            this.dataGridViewtim.Name = "dataGridViewtim";
            this.dataGridViewtim.RowHeadersWidth = 51;
            this.dataGridViewtim.RowTemplate.Height = 24;
            this.dataGridViewtim.Size = new System.Drawing.Size(991, 359);
            this.dataGridViewtim.TabIndex = 0;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTim.Location = new System.Drawing.Point(805, 119);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 23);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tìm Kiếm Thông TIn";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txttim
            // 
            this.txttim.Location = new System.Drawing.Point(493, 120);
            this.txttim.Name = "txttim";
            this.txttim.Size = new System.Drawing.Size(306, 22);
            this.txttim.TabIndex = 2;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.back.Location = new System.Drawing.Point(12, 13);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 3;
            this.back.Text = "Trở Lại ";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnreset.Location = new System.Drawing.Point(911, 120);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(92, 23);
            this.btnreset.TabIndex = 4;
            this.btnreset.Text = "Load Lại";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // lbltb
            // 
            this.lbltb.AutoSize = true;
            this.lbltb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltb.Location = new System.Drawing.Point(418, 164);
            this.lbltb.Name = "lbltb";
            this.lbltb.Size = new System.Drawing.Size(381, 16);
            this.lbltb.TabIndex = 5;
            this.lbltb.Text = "Thông báo: Bạn cần nhập dữ liệu vào đây để tìm kiếm sinh viên";
            this.lbltb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nguoidung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1015, 554);
            this.Controls.Add(this.lbltb);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.back);
            this.Controls.Add(this.txttim);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dataGridViewtim);
            this.Name = "nguoidung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Người Dùng";
            this.Load += new System.EventHandler(this.nguoidung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewtim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txttim;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Label lbltb;
    }
}