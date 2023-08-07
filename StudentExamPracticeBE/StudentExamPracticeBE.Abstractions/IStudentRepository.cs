using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Abstractions
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task<bool> SaveChangesAsync();
        void AddStudent(Student student);
        Task<Student?> GetStudentById(Guid id);
        Task<Student?> GetStudentByEmail(string email);
        bool StudentExists(string email);
        void RemoveStudent(Student student);
        void UpdateStudent(Student student);

    }
}
