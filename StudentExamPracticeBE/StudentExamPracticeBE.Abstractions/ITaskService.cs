using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Abstractions
{
    public interface ITaskService
    {
        public void DeleteTask(ExamTask task);

        Task<bool> SaveChangesAsync();

        Task<IEnumerable<ExamTask>> GetAllTasks();

        Task<ExamTask?> GetTaskById(Guid id);
        Task<ExamTask?> GetTaskByTitle(string title);

        void InsertTask(string title, string description);


    }
}
