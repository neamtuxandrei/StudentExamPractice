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
        public async Task RemoveTaskById(Guid id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null) throw new Exception("Task not found");

            _taskRepository.RemoveTask(task);
            await _taskRepository.SaveChangesAsync();
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

        public ExamTask GetTaskById(Guid id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null) throw new Exception("Task not found");
            return task;
        }
        

        public async Task InsertTask(string title, string description)
        {

            var taskToInsert = ExamTask.Create(title, description);
            _taskRepository.AddTask(taskToInsert);
            await _taskRepository.SaveChangesAsync();

            // log : inserted student with id ... 
        }

        public async Task UpdateTask(Guid id, string title, string description)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task is null) throw new Exception("Task doesn't exists");

            task.Title = title;
            task.Description = description;
            _taskRepository.UpdateTask(task);
            await _taskRepository.SaveChangesAsync();

            // _logger.LogInformation($"Updated student with id: {id} ");
        }
    }
}
