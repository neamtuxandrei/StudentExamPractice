using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Abstractions
{
    public interface IStudentService
    {
        Task<Student?> GetStudentById(Guid id);
        Task<Student?> GetStudentByEmail(string email);
        void DeleteStudent(Student student);
        Task<IEnumerable<Student>> GetAllStudents();
        void InsertStudent(string firstName, string lastName, string emailAddress, IEnumerable<ExamTask> tasks);
        Task<bool> SaveChangesAsync();
    }
}
