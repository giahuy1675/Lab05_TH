using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentService
    {
        public List<Student> GetAll()
        {
            Model1 context = new Model1();
            return context.Students.ToList();

        }
        public List<Student> GetAllHasNoMajor()
        {
            Model1 context = new Model1();
            return context.Students.Where(p => p.MajorID == null).ToList();
        }

        public List<Student> GetAllHasNoMajor(int facultyID)
        {
            Model1 context = new Model1();
            return context.Students.Where(p => p.MajorID == null && p.FacultyID == facultyID).ToList();
        }

           public Student FindById(string studentID)
        {
            Model1 context = new Model1();
            return context.Students.FirstOrDefault(p => p.StudentID == studentID);
        }

        public void Delete(Student s)
        {
            using (Model1 context = new Model1())
            {
                context.Students.Remove(s);
                context.SaveChanges();
            }
        }

        public void InsertUpdate(Student s)
        {
            using (Model1 context = new Model1())
            {
                context.Students.AddOrUpdate(s);
                context.SaveChanges();
            }
        }


    }
}
