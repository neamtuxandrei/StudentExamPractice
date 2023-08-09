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

        ExamTask? GetTaskById(Guid id);

        void RemoveTask(ExamTask task);

        void UpdateTask(ExamTask task);

    }
}
