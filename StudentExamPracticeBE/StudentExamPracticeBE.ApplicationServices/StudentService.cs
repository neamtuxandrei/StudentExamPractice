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

        public async Task RemoveStudentById(Guid id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null) throw new Exception("Student not found");

            _studentRepository.RemoveStudent(student);
            await _studentRepository.SaveChangesAsync();
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

        public Student GetStudentById(Guid id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null) throw new Exception("Student not found");
            return student;
        }
        public async Task<Student?> GetStudentByEmail(string email)
        {
            var student = await _studentRepository.GetStudentByEmail(email);
            return student;
        }

        public async Task InsertStudent(string firstName, string lastName, string emailAddress)
        {
            if (_studentRepository.StudentExists(emailAddress))
                throw new Exception("Student already exists");
            var studentToInsert = Student.Create(firstName, lastName, emailAddress);
            _studentRepository.AddStudent(studentToInsert);
            await _studentRepository.SaveChangesAsync();

            // log : inserted student with id ... 
        }

        public async Task UpdateStudent(Guid id, string firstName, string lastName,string emailAddress)
        {
            var student =  _studentRepository.GetStudentById(id);
            if (student is null) throw new Exception("Student doesn't exists");

            student.FirstName = firstName;
            student.LastName = lastName;
            student.EmailAddress = emailAddress;
            _studentRepository.UpdateStudent(student);
            await _studentRepository.SaveChangesAsync();

            // _logger.LogInformation($"Updated student with id: {id} ");
        }
    }
}
