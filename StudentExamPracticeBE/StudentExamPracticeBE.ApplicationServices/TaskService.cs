using StudentExamPracticeBE.Abstractions;
using StudentExamPracticeBE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.ApplicationServices
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void DeleteTask(ExamTask task)
        {
            _taskRepository.RemoveTask(task);
            // log : deleted student with id: {id} 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _taskRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamTask>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return tasks;
        }

        public async Task<ExamTask?> GetTaskById(Guid id)
        {
            var task = await _taskRepository.GetTaskById(id);
            return task;
        }
        public async Task<ExamTask?> GetTaskByTitle(string title)
        {
            var task = await _taskRepository.GetTaskByTitle(title);
            return task;
        }

        public void InsertTask(string title, string description)
        {
            if (_taskRepository.TaskExists(title))
                throw new Exception("Task already exists");
            var taskToInsert = ExamTask.Create(title, description);
            _taskRepository.AddTask(taskToInsert);
            // log : inserted student with id ... 
        }
    }
}
