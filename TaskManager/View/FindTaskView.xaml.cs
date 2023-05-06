using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManager.Model;
using TaskManager.ViewModel;

namespace TaskManager.View
{
    /// <summary>
    /// Interaction logic for FindTaskView.xaml
    /// </summary>
    public partial class FindTaskView : Window
    {
        public FindTaskView()
        {
            InitializeComponent();
        }

       

        public FindTaskView(TaskListTreeViewModel taskCategory)
        {
            TaskTree = taskCategory;
            SearchText= "";
            SearchedTasks= new ObservableCollection<TaskObject>();
            InitializeComponent();
        }

        public TaskListTreeViewModel TaskTree { get; }
        string SearchText { get; set; }
        public ObservableCollection<TaskObject> SearchedTasks { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(TaskTree.SearchText);
            SearchedTasks.Clear();
            foreach (TaskCategory category in TaskTree.CategoryCollection)
            {
                foreach(TaskObject task in category.TaskCollection)
                {
                    if (task.TaskName.Contains(SearchText))
                    {
                        SearchedTasks.Add(task);
                    }
                }
            }
        }

        private void lbTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
