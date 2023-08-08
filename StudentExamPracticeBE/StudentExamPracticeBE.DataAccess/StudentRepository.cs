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
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public Student? GetStudentById(Guid id)
        {
            var student = _context.Students.Include(task => task.Tasks)
                .Where(i=> i.Id == id)
                .FirstOrDefault();
            return student;
        }
        public async Task<Student?> GetStudentByEmail(string email)
        {
            var student = await _context.Students.Include(task => task.Tasks)
                .Where(e=> e.EmailAddress == email)
                .FirstOrDefaultAsync();
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
        public bool StudentExists(string email)
        {
            var exists = _context.Students.FirstOrDefault(std => std.EmailAddress.ToUpper() == email.ToUpper());
            if (exists is null)
                return false;
            return true;
        }
    }
}
