using StudentExamPracticeBE.Domain;

namespace StudentExamPracticeBE.Abstractions
{
    public interface IStudentImporter
    {
        List<Student> ImportStudents(string filePath);
    }
}
