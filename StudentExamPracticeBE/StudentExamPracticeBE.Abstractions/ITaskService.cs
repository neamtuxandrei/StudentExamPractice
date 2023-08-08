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
        Task UpdateTask(Guid id, string title, string description);
        ExamTask GetTaskById(Guid id);
        Task RemoveTaskById(Guid id);
        Task<IEnumerable<ExamTask>> GetAllTasks();
        Task InsertTask(string title, string description);
        Task<bool> SaveChangesAsync();


    }
}
