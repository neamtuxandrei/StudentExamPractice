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

        public async Task<ExamTask?> GetTaskById(Guid id)
        {
            var task = await _context.ExamTasks
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
            return task;
        }
        public async Task<ExamTask?> GetTaskByTitle(string title)
        {
            var task = await _context.ExamTasks
                .Where(e => e.Title == title)
                .FirstOrDefaultAsync();
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
        public bool TaskExists(string title)
        {
            var exists = _context.ExamTasks.FirstOrDefault(std => std.Title.ToUpper() == title.ToUpper());
            if (exists is null)
                return false;
            return true;
        }
    }
}
