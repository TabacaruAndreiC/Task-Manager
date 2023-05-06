using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModel;

namespace TaskManager.Model
{
    internal class TaskListTree
    {
        public string name;
        public List<TaskObject> taskCollection;


        //CONSTRUSTORI
        public TaskListTree()
        {
            name = "Default";
            taskCollection = new List<TaskObject>();
        }

        public TaskListTree(string name)
        {
            this.name = name;
            taskCollection = new List<TaskObject>();
        }

        /*
        //MANIPULARE TASKURI
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            tasks.Remove(task);
        }

        public void RemoveTask(string taskName)
        {
            foreach (Task task in tasks)
            {
                if (task.getName() == taskName)
                {
                    tasks.Remove(task);
                    break;
                }
            }
        }
        */

    }
}
