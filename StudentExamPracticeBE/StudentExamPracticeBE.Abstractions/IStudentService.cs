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
        Student GetStudent(Guid id);
        Task DeleteById(Guid id);
        Task<IEnumerable<Student>> GetAllStudents();
        Task InsertStudent(string firstName, string lastName, string emailAddress, IEnumerable<ExamTask> tasks);
    }
}
