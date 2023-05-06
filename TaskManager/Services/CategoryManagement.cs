using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;
using TaskManager.Utilities;
using TaskManager.ViewModel;

namespace TaskManager.Services
{
    public class CategoryManagement
    {
        private TaskCategory category;
        

        public CategoryManagement(TaskCategory category)
        {
            this.category = category;
        }

        public void AddSubCategory(TaskCategory subCategory)
        {
            category.SubCategoryCollection.Add(subCategory);
        }
        
        public void AddTask()
        {
            TaskObject task = new TaskObject();
            category.TaskCollection.Add(task);
        }

        public void RemoveSubCategory(TaskCategory subCategory)
        {
            category.SubCategoryCollection.Remove(subCategory);
        }

        public void RemoveTask(TaskObject task)
        {
            category.TaskCollection.Remove(task); 
        }

        public void AddSubCategory()
        {
            TaskCategory subCategory = new TaskCategory();
            category.SubCategoryCollection.Add(subCategory);
        }
    }
}
