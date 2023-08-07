using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Abstractions
{
    public interface ITaskRepository
    {
        Task<List<ExamTask>> GetAllTasks();

        Task<bool> SaveChangesAsync();

        void AddTask(ExamTask task);

        Task<ExamTask?> GetTaskById(Guid id);

        Task<ExamTask?> GetTaskByTitle(string title);

        void RemoveTask(ExamTask task);

        void UpdateTask(ExamTask task);

        bool TaskExists(string title);

    }
}
