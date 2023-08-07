using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Domain
{
    public class ExamTask
    {
        [Key]
        public Guid Id { get; private set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Created";
        private List<Student> _students = new List<Student>();
        [IgnoreDataMember]
        public ICollection<Student> Students => _students;
        private ExamTask()
        {

        }
        public static ExamTask Create(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("The name must not be empty", "firstName");

            var task = new ExamTask();
            task.Title = title;
            task.Id = Guid.NewGuid();
            task.Description = description;
            return task;
        }
        public void AddStudent(string firstName, string lastName, string emailAddress)
        {
            var student = Student.Create(firstName, lastName, emailAddress);
            _students.Add(student);
        }

    }
}
