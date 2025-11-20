using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    public class TaskItem
    {
        public int Id { get; }
        public string Description { get; }
        public bool IsDone { get; private set; }

        // NEW: optional due date for the task
        public DateTime? DueDate { get; }

        public TaskItem(int id, string description, DateTime? dueDate = null)
        {
            if (description == null)
            {
                throw new ArgumentNullException("description");
            }

            Id = id;
            Description = description;
            IsDone = false;
            DueDate = dueDate;  // store the due date (can be null)
        }

        public void MarkDone()
        {
            IsDone = true;
        }

        public override string ToString()
        {
            string status = IsDone ? "[X]" : "[ ]";

            
            string dueText = DueDate.HasValue
                ? $" (Due: {DueDate.Value:yyyy-MM-dd})"
                : string.Empty;

            return string.Format("{0} {1}: {2}{3}", status, Id, Description, dueText);
        }
    }
}
