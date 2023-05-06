using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModel;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
    internal class TaskObjectViewModel : BaseViewModel
    {
        public string taskName;
        public string taskDescription;
        public TaskObject taskObject;

        public TaskObjectViewModel()
        {
            taskObject = new TaskObject();
            taskName = "Default Task Name";
            taskDescription = "Default Task Description";
        }

        public TaskObjectViewModel(TaskObject taskObject)
        {
            this.taskObject = taskObject;
            this.taskName=taskObject.taskName;
            this.taskDescription=taskObject.taskDescription;
        }

        public string TaskName
        {
            get
            {
                return taskName;
            }
            set
            {
                taskName = value;
                NotifyPropertyChanged("TaskName");
            }
        }
    }

}
