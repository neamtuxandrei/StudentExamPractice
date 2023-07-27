using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Domain
{
    public class ExamTask
    {
        public Guid Id { get; private set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "Created";
        private ExamTask()
        {
            
        }
        public static ExamTask Create(string title,string description, string status)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("The name must not be empty", "firstName");

            var task = new ExamTask();
            task.Title = title;
            task.Id = Guid.NewGuid();
            task.Description = description;
            task.Status = status;
            return task;
        }

    }
}
