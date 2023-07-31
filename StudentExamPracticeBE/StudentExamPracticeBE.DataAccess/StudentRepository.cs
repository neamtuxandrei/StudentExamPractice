using Microsoft.EntityFrameworkCore;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.DataAccess
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public Task<List<Student>> GetAllStudents()
        {
            return _context.Students.Include(task => task.Tasks).ToListAsync();
        }
        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public Student GetStudentById(Guid id)
        {
            var student = _context.Students.Include(task => task.Tasks).First(std => std.Id == id);
            return student;
        }

        public void RemoveStudent(Student student)
        {
           _context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Update(student);
        }
        public Task<Student?> GetFirstOrDefault(System.Linq.Expressions.Expression<Func<Student, bool>> filter)
        {
            return _context.Students.Where(filter).FirstOrDefaultAsync();
        }
    }
}
