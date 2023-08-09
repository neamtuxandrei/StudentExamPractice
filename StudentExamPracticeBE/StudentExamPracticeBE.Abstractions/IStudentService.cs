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
        Task UpdateStudent(Guid id, string firstName, string lastName, string emailAddress);
        Student GetStudentById(Guid id);
        Task<Student?> GetStudentByEmail(string email);
        Task RemoveStudentById(Guid id);
        Task<IEnumerable<Student>> GetAllStudents();
        Task InsertStudent(string firstName, string lastName, string emailAddress);
        Task<bool> SaveChangesAsync();
    }
}
