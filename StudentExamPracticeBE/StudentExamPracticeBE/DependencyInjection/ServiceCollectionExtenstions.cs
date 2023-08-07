using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.ApplicationServices;
using StudentExamPracticeBE.DataAccess;

namespace StudentExamPracticeBE.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
