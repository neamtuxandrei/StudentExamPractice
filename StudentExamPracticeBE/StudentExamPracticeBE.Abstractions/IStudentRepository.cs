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
        Task SaveChanges();
        void AddStudent(Student student);
        Student GetStudentById(Guid id);
        void RemoveStudent(Student student);
        void UpdateStudent(Student student);
        Task<Student?> GetFirstOrDefault(System.Linq.Expressions.Expression<Func<Student, bool>> filter);
    }
}
