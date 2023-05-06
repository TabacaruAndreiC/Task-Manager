using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public class TaskObject
    {
        public string taskName;
        public string taskDescription;
        DateTime taskDeadline = DateTime.Today;
        public enum TaskPriorityEnum
        {
            Low,
            Medium,
            High
        }


        public TaskObject()
        {
            TaskSubCollection = new List<TaskObject>();
            TaskName = "Default Task Name";
            TaskDescription = "Default Task Description";
            IsCompleted = false;
            TaskDeadline = DateTime.Today;
            TaskPriority = TaskPriorityEnum.Low.ToString();
        }
        public List<TaskObject> TaskSubCollection { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public string TaskPriority { get; set; }
        public DateTime TaskDeadline
        {
            get { return taskDeadline; }
            set
            {
                if (value > DateTime.Now)
                {
                    taskDeadline = value;
                }
            }
        }

    }
}
