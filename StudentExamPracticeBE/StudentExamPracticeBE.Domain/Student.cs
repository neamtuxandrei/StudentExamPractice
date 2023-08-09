using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Domain
{
    public class Student : Person
    {
        [Key]
        public Guid Id { get; private set; }
        private List<ExamTask> _tasks = new List<ExamTask>();
        public ICollection<ExamTask> Tasks => _tasks;
        private Student()
        {

        }
        public static Student Create(string firstName, string lastName, string emailAddress)
        {
            Student student = new Student();
            student.Id = Guid.NewGuid();
            student.SetName(firstName, lastName);
            student.SetEmailAddress(emailAddress);
            return student;

        }
        public void AddTask(string title, string description)
        {
            var task = ExamTask.Create(title, description);
            _tasks.Add(task);
        }
        public void RemoveTask(Guid itemToRemove)
        {
            var taskFound = _tasks.Where(item => item.Id == itemToRemove)
                .First();
            _tasks.Remove(taskFound);
        }
    }
}
