using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModel;

namespace TaskManager.Model
{
    public class TaskCategory : BaseModel
    {
        public TaskCategory()
        {
            CategoryName = "Default Category Name";
            CategoryDescription = "Default Category Description";
            TaskCollection = new ObservableCollection<TaskObject>();
            SubCategoryCollection = new ObservableCollection<TaskCategory>();
        }

        public string categoryName;
        public string categoryDescription;
        public ObservableCollection<TaskObject> taskCollection;
        public ObservableCollection<TaskCategory> subCategoryCollection;

        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                NotifyPropertyChanged();
            }
        }
        public string CategoryDescription
        {
            get
            {
                return categoryDescription;
            }
            set
            {
                categoryDescription = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<TaskObject> TaskCollection
        {
            get
            {
                return taskCollection;
            }
            set
            {
                taskCollection = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<TaskCategory> SubCategoryCollection
        {
            get
            {
                return subCategoryCollection;
            }
            set
            {
                subCategoryCollection = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            string output = CategoryDescription + " lol lmao";
            return CategoryName;
        }
    }
}
