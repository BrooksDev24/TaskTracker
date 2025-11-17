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

        public TaskItem(int id, string description)
        {
            if (description == null)
            {
                throw new ArgumentNullException("description");
            }

            Id = id;
            Description = description;
            IsDone = false;
        }

        public void MarkDone()
        {
            IsDone = true;
        }

        public override string ToString()
        {
            string status = IsDone ? "[X]" : "[ ]";
            return string.Format("{0} {1}: {2}", status, Id, Description);
        }
    }
}
