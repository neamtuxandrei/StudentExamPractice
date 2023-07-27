using StudentExamPracticeBE.Abstractions;


namespace StudentExamPracticeBE.ApplicationServices
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository; 
        }
    }
}
