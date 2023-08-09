using ClosedXML.Excel;
using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Domain;

namespace StudentExamPracticeBE.ExcelImporter
{
    public class StudentsExcelImporter : IStudentImporter
    {
        public List<Student> ImportStudents(string filePath)
        {
            List<Student> students = new List<Student>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);

                var rows = worksheet.RowsUsed();

                foreach (var row in rows.Skip(1))
                {
                    string firstName = row.Cell(1).Value.ToString();
                    string lastName = row.Cell(2).Value.ToString();
                    string emailAddress = row.Cell(3).Value.ToString();

                    if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(emailAddress))
                    {
                        var student = Student.Create(firstName, lastName, emailAddress);
                        students.Add(student);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data in row {row.RowNumber()}");
                    }
                }
            }
            return students;
        }
    }
}
