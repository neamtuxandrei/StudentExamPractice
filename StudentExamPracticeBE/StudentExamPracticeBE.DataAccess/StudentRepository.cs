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
        public void AddTaskToStudent(ExamTask task,Guid studentId)
        {
            var student = _context.Students.Where(std => std.Id.Equals(studentId)).First();
            student.AddTask(task.Title,task.Description,task.Status);
            _context.SaveChanges();
        }

        public void DeleteTask(Guid id)
        {
            var task = _context.Students.Where(ts => ts.Id.Equals(id))
                .First();
            _context.Students.Remove(task);
            _context.SaveChanges();
        }

        public Student GetStudentById(Guid id)
        {
            var student = _context.Students.Where(st => st.Id.Equals(id)).First();
            return student;
        }

        public IEnumerable<ExamTask> GetTasksForStudent(Guid studentId)
        {
            var student = _context.Students.Where(st => st.Id.Equals(studentId)).First();
            return student.Tasks.AsEnumerable();
        }
    }
}
