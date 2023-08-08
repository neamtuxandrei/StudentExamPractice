using Microsoft.VisualBasic.FileIO;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Domain;

namespace StudentExamPracticeBE.ImportMembers
{
    public class StudentsCSVImporter : IStudentImporter
    { 
        public List<Student> ImportStudents(string filePath)
        {
            List<Student> students = new();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                // Set the delimiter for the CSV file (e.g., comma ',' or semicolon ';')
                parser.SetDelimiters(",");

                // Skip the header row if present
                if (!parser.EndOfData)
                {
                    parser.ReadLine();
                }

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length >= 3) // Make sure you have at least FirstName, LastName, and EmailAddress
                    {
                        var student = Student.Create(fields[0], fields[1], fields[2]);
                        students.Add(student);
                    }
                }
            }
            return students;
        }
    }
}

