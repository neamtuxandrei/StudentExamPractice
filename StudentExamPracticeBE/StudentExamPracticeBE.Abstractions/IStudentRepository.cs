using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Abstractions
{
    public interface IStudentRepository
    {
        IEnumerable<ExamTask> GetTasksForStudent(Guid studentId);
        Student GetStudentById(Guid id);
        public void AddTaskToStudent(ExamTask task, Guid studentId);
        void DeleteTask(Guid id);
    }
}
