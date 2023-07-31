using Microsoft.EntityFrameworkCore;
using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.DataAccess
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<ExamTask> ExamTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
        }
    }

    public static class SeedDataHelper
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region students
            var student1 = Student.Create("Andrei", "Neamtu", "neamtuandrei26@yahoo.com");
            var student2 = Student.Create("Gabriel", "Motoc", "motoc212@yahoo.com");
            var student3 = Student.Create("Vlad", "Lupu", "vlad.lupu@gmail.com");
            var student4 = Student.Create("Mihnea", "Sanda", "mihnea.sanda@gmail.com");
            var student5 = Student.Create("Aurel", "Dicu", "dicu_aurel9@yahoo.com");
            var student6 = Student.Create("Andrei", "Ionescu", "ionescu@gmail.com");
            var student7 = Student.Create("Mihai", "Toncea", "tonceamihai99@yahoo.com");
            var student8 = Student.Create("Claudiu", "Anita", "anitaclaudiu@gmail.com");
            var student9 = Student.Create("Majon", "Andrei", "andrei89@yahoo.com");
            var student10 = Student.Create("Andrei", "Baranescu", "baranescu@yahoo.com");

            var studentList = new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 };
            #endregion

            #region tasks
            var task1 = ExamTask.Create("Quicksort", "Efectuare comparatii pentru a sorta n elemente", "Created");
            var task2 = ExamTask.Create("BubbleSort", "Parcurge in mod repetat lista element cu element comparand cu precedentul", "Created");
            var task3 = ExamTask.Create("OOP design", "Creati 3 clase respectand principiile OOP.", "Created");

            var taskList = new List<ExamTask>() { task1, task2, task3 };
            #endregion

            #region studentTask
            var studentTask = new List<object> {
                new { ExamTaskId = task1.Id, StudentId = student1.Id },
                new { ExamTaskId = task2.Id, StudentId = student1.Id },
                new { ExamTaskId = task3.Id, StudentId = student1.Id },
                new { ExamTaskId = task1.Id, StudentId = student2.Id },
                new { ExamTaskId = task3.Id, StudentId = student2.Id },
                new { ExamTaskId = task2.Id, StudentId = student3.Id },
                new { ExamTaskId = task2.Id, StudentId = student4.Id },
                new { ExamTaskId = task3.Id, StudentId = student5.Id },
                new { ExamTaskId = task3.Id, StudentId = student6.Id },
                new { ExamTaskId = task3.Id, StudentId = student7.Id },
                new { ExamTaskId = task1.Id, StudentId = student8.Id },
                new { ExamTaskId = task2.Id, StudentId = student9.Id },
            };
            #endregion

            modelBuilder.Entity<Student>().HasData(studentList);
            modelBuilder.Entity<ExamTask>().HasData(taskList);
            modelBuilder.Entity<Student>().HasMany(p => p.Tasks).WithMany(m => m.Students)
                .UsingEntity("StudentTask",
                            l => l.HasOne(typeof(ExamTask)).WithMany().HasForeignKey("ExamTaskId").HasPrincipalKey(nameof(ExamTask.Id)),
                             r => r.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentId").HasPrincipalKey(nameof(Student.Id)),
                             j => j.HasKey("ExamTaskId", "StudentId"));
            modelBuilder.Entity<Student>().HasMany(p => p.Tasks).WithMany(m => m.Students).UsingEntity(j => j.HasData(studentTask));

        }
    }
}
