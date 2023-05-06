using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
    internal class TaskCategoryViewModel:BaseViewModel
    {
        public TaskCategory TaskCategory { get; set; }

        //TOATE DECLARARILE DE SUB SUNT PROBABIL OPTIONALE
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ObservableCollection<TaskObject> TaskCollection { get; set; }
        public ObservableCollection<TaskCategory> SubCategoryCollection { get; set; }
        
        

        public TaskCategoryViewModel(TaskCategory taskCategory)
        {
            this.TaskCategory = taskCategory;
            CategoryName = taskCategory.CategoryName;
            CategoryDescription = taskCategory.CategoryDescription;
            SubCategoryCollection = taskCategory.SubCategoryCollection;

        }
    }
}
