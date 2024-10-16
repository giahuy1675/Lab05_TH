namespace GUI
{
    partial class Form2
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
            this.dgv_Student = new System.Windows.Forms.DataGridView();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.cmb_Major = new System.Windows.Forms.ComboBox();
            this.btn_DangKi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Student
            // 
            this.dgv_Student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Student.Location = new System.Drawing.Point(370, 29);
            this.dgv_Student.Name = "dgv_Student";
            this.dgv_Student.Size = new System.Drawing.Size(418, 387);
            this.dgv_Student.TabIndex = 0;
            this.dgv_Student.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Student_CellContentClick);
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(62, 45);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(174, 21);
            this.cmbFaculty.TabIndex = 1;
            this.cmbFaculty.SelectedIndexChanged += new System.EventHandler(this.cmbFaculty_SelectedIndexChanged);
            // 
            // cmb_Major
            // 
            this.cmb_Major.FormattingEnabled = true;
            this.cmb_Major.Location = new System.Drawing.Point(62, 89);
            this.cmb_Major.Name = "cmb_Major";
            this.cmb_Major.Size = new System.Drawing.Size(174, 21);
            this.cmb_Major.TabIndex = 2;
            this.cmb_Major.SelectedIndexChanged += new System.EventHandler(this.cmb_Major_SelectedIndexChanged);
            // 
            // btn_DangKi
            // 
            this.btn_DangKi.Location = new System.Drawing.Point(62, 139);
            this.btn_DangKi.Name = "btn_DangKi";
            this.btn_DangKi.Size = new System.Drawing.Size(85, 30);
            this.btn_DangKi.TabIndex = 3;
            this.btn_DangKi.Text = "Đăng kí";
            this.btn_DangKi.UseVisualStyleBackColor = true;
            this.btn_DangKi.Click += new System.EventHandler(this.btn_DangKi_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_DangKi);
            this.Controls.Add(this.cmb_Major);
            this.Controls.Add(this.cmbFaculty);
            this.Controls.Add(this.dgv_Student);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Student)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Student;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.ComboBox cmb_Major;
        private System.Windows.Forms.Button btn_DangKi;
    }
}