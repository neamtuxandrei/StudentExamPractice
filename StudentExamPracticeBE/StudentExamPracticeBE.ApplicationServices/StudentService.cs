using Microsoft.AspNetCore.Http;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Domain;

namespace StudentExamPracticeBE.ApplicationServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task DeleteById(Guid id)
        {
            var student = _studentRepository.GetStudentById(id) ?? throw new Exception("Student not found");
            _studentRepository.RemoveStudent(student);
            await _studentRepository.SaveChanges();
            // log : deleted student with id: {id} 
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();
            return students;
        }

        public Student GetStudent(Guid id)
        {
            var student = _studentRepository.GetStudentById(id) ?? throw new Exception("Student not found");
            return student;
        }

        public async Task InsertStudent(string firstName,string lastName,string emailAddress,IEnumerable<ExamTask> tasks)
        {
            var student = await _studentRepository.GetFirstOrDefault(i => i.EmailAddress.ToUpper() == emailAddress.ToUpper());
            if (student is not null) throw new Exception("Student already exists");

            var studentToInsert = Student.Create(firstName, lastName, emailAddress);
            foreach(var task in tasks)
            {
                studentToInsert.AddTask(task.Title, task.Description, task.Status);
            }
            _studentRepository.AddStudent(studentToInsert);
            await _studentRepository.SaveChanges();
            // log : inserted student with id ... 
        }
    }
}
