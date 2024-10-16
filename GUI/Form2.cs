using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{

    public partial class Form2 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();
        public Form2()
        {
            InitializeComponent();
        }



        private void BindGrid(List<Student> listStudent)
        {
            dgv_Student.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgv_Student.Rows.Add();
                dgv_Student.Rows[index].Cells[0].Value = false; // Cột checkbox, mặc định không chọn
                dgv_Student.Rows[index].Cells[1].Value = item.StudentID;
                dgv_Student.Rows[index].Cells[2].Value = item.FullName;
                dgv_Student.Rows[index].Cells[3].Value = item.Faculty?.FacultyName ?? "";
                dgv_Student.Rows[index].Cells[4].Value = item.AverageScore;
                dgv_Student.Rows[index].Cells[5].Value = item.Major?.Name ?? "";
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeDataGridView(); // Thêm vào phương thức khởi tạo cột
                var listFacultys = facultyService.GetAll();
                FillFalcultyCombobox(listFacultys);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFalcultyCombobox(List<Faculty> listFacultys)
        {
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }


        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty selectedFaculty = cmbFaculty.SelectedItem as Faculty;
            if (selectedFaculty != null)
            {
                var listMajor = majorService.GetAllByFaculty(selectedFaculty.FacultyID);
                FillMajorCombobox(listMajor);

                // Cập nhật danh sách sinh viên không có chuyên ngành
                var listStudents = studentService.GetAllHasNoMajor(selectedFaculty.FacultyID);
                BindGrid(listStudents);
            }
        }


        private void FillMajorCombobox(List<Major> listMajors)
        {
            this.cmb_Major.DataSource = listMajors;
            this.cmb_Major.DisplayMember = "Name"; // Thay "Name" bằng tên thuộc tính thực tế
            this.cmb_Major.ValueMember = "MajorID"; // Thay "MajorID" bằng tên thuộc tính thực tế
        }

        private void dgv_Student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_Student.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Kiểm tra cột checkbox
                {
                    string studentId = row.Cells[1].Value.ToString(); // Sử dụng cột StudentID
                    var student = studentService.FindById(studentId);
                    if (student != null && cmb_Major.SelectedValue is int majorId)
                    {
                        student.MajorID = majorId;
                        try
                        {
                            studentService.InsertUpdate(student);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi: {ex.Message}");
                        }
                    }
                }
            }

            MessageBox.Show("Đăng ký thành công!");
            BindGrid(studentService.GetAll());
        }
        private void InitializeDataGridView()
        {
            dgv_Student.Columns.Clear(); // Xóa cột cũ nếu có
            dgv_Student.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Select",
                HeaderText = "Chọn",
                Width = 50,
                FalseValue = false,
                TrueValue = true
            });
            dgv_Student.Columns.Add("StudentID", "Mã Sinh Viên");
            dgv_Student.Columns.Add("FullName", "Họ Tên");
            dgv_Student.Columns.Add("FacultyName", "Tên Khoa");
            dgv_Student.Columns.Add("AverageScore", "Điểm Trung Bình");
            dgv_Student.Columns.Add("MajorName", "Tên Chuyên Ngành");
        }
        private void cmb_Major_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Major.SelectedValue is int majorId)
            {
                var listStudents = studentService.GetAll()
                    .Where(s => s.MajorID == majorId).ToList();
                BindGrid(listStudents);
            }
        }
    }
    
    }
