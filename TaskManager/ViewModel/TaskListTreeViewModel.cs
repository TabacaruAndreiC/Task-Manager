using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model;
using System.Xml;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using TaskManager.Utilities;

namespace TaskManager.ViewModel
{
    public class TaskListTreeViewModel : BaseViewModel
    {
        public ICommand TreeViewSelectClick { get; }
        Writer writer = new Writer();
        

        public TaskListTreeViewModel()
        {
            
            SelectedCategory = new TaskCategory();
            SelectedCategory.PropertyChanged += (s, e) => {NotifyPropertyChanged("SelectedCategory"); };
            SelectedTask = new TaskObject();
            SelectedCategory.CategoryName = "Default";
            SearchTaskText = "";


            ObservableCollection<TaskCategory> categories = new ObservableCollection<TaskCategory>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\An2\\sem2\\MVP\\TaskManagerMVP2\\TaskManager\\TaskManager\\tasks.xml");

            XmlNodeList categoryNodes = xmlDoc.GetElementsByTagName("category");

            foreach (XmlNode categoryNode in categoryNodes)
            {
                TaskCategory category = new TaskCategory();
                category.CategoryName = categoryNode.Attributes["name"].Value;
                category.CategoryDescription = categoryNode.SelectSingleNode("description").InnerText;

                // citirea subcategoriilor
                XmlNodeList subcategoryNodes = categoryNode.SelectNodes("subcategories/subcategory");
                foreach (XmlNode subcategoryNode in subcategoryNodes)
                {
                    TaskCategory subcategory = new TaskCategory();
                    subcategory.CategoryName = subcategoryNode.Attributes["name"].Value;
                    subcategory.CategoryDescription = subcategoryNode.SelectSingleNode("description").InnerText;
                    category.SubCategoryCollection.Add(subcategory);

                    // citirea task-urilor pentru subcategorie
                    XmlNodeList taskNodess = subcategoryNode.SelectNodes("tasks/task");
                    foreach (XmlNode taskNode in taskNodess)
                    {
                        TaskObject task = new TaskObject();
                        task.TaskName = taskNode.Attributes["name"].Value;
                        task.TaskDescription = taskNode.SelectSingleNode("description").InnerText;
                        task.TaskPriority = taskNode.Attributes["priority"].Value;
                        DateTime deadline;
                        DateTime.TryParse(taskNode.SelectSingleNode("deadline").InnerText, out deadline);
                        task.TaskDeadline = deadline;
                        subcategory.TaskCollection.Add(task);
                    }
                }

                // citirea task-urilor pentru categorie
                XmlNodeList taskNodes = categoryNode.SelectNodes("tasks/task");
                foreach (XmlNode taskNode in taskNodes)
                {
                    TaskObject task = new TaskObject();
                    task.TaskName = taskNode.Attributes["name"].Value;
                    task.TaskDescription = taskNode.SelectSingleNode("description").InnerText;
                    task.TaskPriority = taskNode.Attributes["priority"].Value;
                    DateTime deadline;
                    DateTime.TryParse(taskNode.SelectSingleNode("deadline").InnerText, out deadline);
                    task.TaskDeadline = deadline;
                    category.TaskCollection.Add(task);
                }

                CategoryCollection.Add(category);
            }
            
        }

        private void ExecuteCategorySelectedCommand(TaskCategory clicked)
        {
            this.SelectedCategory = clicked;
        }
        
        public RelayCommand TreeItemClikedCommand { get; set; }
        public ObservableCollection<TaskCategory> CategoryCollection { get; set; } = new ObservableCollection<TaskCategory>();
            
        public ObservableCollection<TaskObject> SearchedTasks { get; set; } = new ObservableCollection<TaskObject>();
        public TaskObject SelectedTask { get; set; }

        public string SearchTaskText { get; set; }

        private TaskCategory selectedCategory;
        public TaskCategory SelectedCategory 
        {
            get
            {
                return selectedCategory; 
            }
            set
            {
                selectedCategory = value;
                NotifyPropertyChanged("SelectedCategory");
            }
        }

        private string collectionName;

        public string CollectionName
        {
            get
            {
                return collectionName;
            }
            set
            {
                collectionName = value;
            }

        }

        public string SearchText { get; internal set; }
    }

   
}
