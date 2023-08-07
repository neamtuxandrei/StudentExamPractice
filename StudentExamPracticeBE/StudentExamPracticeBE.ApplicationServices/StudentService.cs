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

        public void DeleteStudent(Student student)
        {
            _studentRepository.RemoveStudent(student);
            // log : deleted student with id: {id} 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _studentRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudents();
            return students;
        }

        public async Task<Student?> GetStudentById(Guid id)
        {
            var student = await _studentRepository.GetStudentById(id);
            return student;
        }
        public async Task<Student?> GetStudentByEmail(string email)
        {
            var student = await _studentRepository.GetStudentByEmail(email);
            return student;
        }

        public void InsertStudent(string firstName, string lastName, string emailAddress, IEnumerable<ExamTask> tasks)
        {
            if (_studentRepository.StudentExists(emailAddress))
                throw new Exception("Student already exists");
            var studentToInsert = Student.Create(firstName, lastName, emailAddress);
            foreach (var task in tasks)
            {
                studentToInsert.AddTask(task.Title, task.Description);
            }
            _studentRepository.AddStudent(studentToInsert);
            // log : inserted student with id ... 
        }
    }
}
