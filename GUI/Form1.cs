using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        public Form1()
        {
            InitializeComponent();
        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbChuyenNganh.SelectedValue is int majorId)
            {
                var filteredStudents = studentService.GetAll()
                    .Where(s => s.MajorID == majorId).ToList();
                BindGrid(filteredStudents);
            }
        }

        private void pictureAvatar_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                StudentID = txtMSSV.Text.Trim(),
                FullName = txtHoten.Text.Trim(),
                AverageScore = double.TryParse(txtDTB.Text.Trim(), out var score) ? score : 0,
                FacultyID = (int)cbbChuyenNganh.SelectedValue,
                // Thêm các thuộc tính khác nếu cần
            };

            studentService.InsertUpdate(student);
            BindGrid(studentService.GetAll());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTableSV.CurrentRow != null)
            {
                string studentId = dgvTableSV.CurrentRow.Cells[0].Value.ToString();
                var student = studentService.FindById(studentId);
                if (student != null)
                {
                    studentService.Delete(student); // Phương thức Delete cần được định nghĩa trong StudentService
                    BindGrid(studentService.GetAll());
                }
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    pictureAvatar.Image = Image.FromFile(openFileDialog.FileName);
                    // Xử lý lưu tên file hoặc thông tin cần thiết khác
                }
            }
        }

        private void dgvTableSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvTableSV.Rows[e.RowIndex];
                txtMSSV.Text = selectedRow.Cells[0].Value.ToString();
                txtHoten.Text = selectedRow.Cells[1].Value.ToString();
                
                txtDTB.Text = selectedRow.Cells[3].Value.ToString();
                // Lấy ảnh đại diện và các thông tin khác nếu cần
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var listStudents = new List<Student>();
            if (this.checkBox1.Checked)
                listStudents = studentService.GetAllHasNoMajor();
            else
                listStudents = studentService.GetAll();
            BindGrid(listStudents);
        }

        private void FillFalcultyCombobox(List<Faculty> listFacultys)
        {
            listFacultys.Insert(0, new Faculty());
            this.cbbChuyenNganh.DataSource = listFacultys;
            this.cbbChuyenNganh.DisplayMember = "FacultyName";
            this.cbbChuyenNganh.ValueMember = "FacultyID";
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvTableSV.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvTableSV.Rows.Add();
                dgvTableSV.Rows[index].Cells[0].Value = item.StudentID;
                dgvTableSV.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                    dgvTableSV.Rows[index].Cells[2].Value =
                    item.Faculty.FacultyName;
                dgvTableSV.Rows[index].Cells[3].Value = item.AverageScore +
                "";
                if (item.MajorID != null)
                    dgvTableSV.Rows[index].Cells[4].Value = item.Major.Name +
                    "";
                ShowAvatar(item.Avatar);
            }
        }


        private void ShowAvatar(string ImageName)
        {
            if (string.IsNullOrEmpty(ImageName))
            {
                pictureAvatar.Image = null;
            }
            else
            {
                try
                {
                    string parentDirectory =
                        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imagePath = Path.Combine(parentDirectory, "Images", ImageName);
                    pictureAvatar.Image = Image.FromFile(imagePath);
                    pictureAvatar.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}");
                }
            }
        }



        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvTableSV);
                var listFacultys = facultyService.GetAll();
                var listStudents = studentService.GetAll();
                FillFalcultyCombobox(listFacultys);
                BindGrid(listStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();  
            form2.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
