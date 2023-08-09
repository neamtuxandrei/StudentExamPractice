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
    public class TaskRepository : ITaskRepository
    {
        private readonly StudentDbContext _context;
        public TaskRepository(StudentDbContext context)
        {
            _context = context;
        }
        public Task<List<ExamTask>> GetAllTasks()
        {
            return _context.ExamTasks.ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void AddTask(ExamTask task)
        {
            _context.ExamTasks.Add(task);
        }
        public ExamTask? GetTaskById(Guid id)
        {
            var task = _context.ExamTasks
                .Where(i => i.Id == id)
                .FirstOrDefault();
            return task;
        }
        public void RemoveTask(ExamTask task)
        {
            _context.ExamTasks.Remove(task);
        }
        public void UpdateTask(ExamTask task)
        {
            _context.Update(task);
        }
    }
}
