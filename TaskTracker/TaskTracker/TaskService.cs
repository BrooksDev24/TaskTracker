using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    public class TaskService
    {

        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        private int nextId = 1;

        public TaskItem AddTask(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            var task = new TaskItem(nextId++, description);
            _tasks.Add(task);
            return task;
        }

        public IReadOnlyList<TaskItem> GetAllTasks()
        {
            return _tasks.AsReadOnly();
        }

        public bool MarkTaskDone(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            
            task.MarkDone();
            return true;
        }


    }
}
