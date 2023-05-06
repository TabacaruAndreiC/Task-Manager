using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Model;
using TaskManager.Services;
using TaskManager.Utilities;
using TaskManager.ViewModel;

namespace TaskManager.View
{
    /// <summary>
    /// Interaction logic for TaskManager.xaml
    /// </summary>
    public partial class TaskManager : UserControl
    {
        CategoryManagement management { get; set; }
        Writer writer = new Writer();

        public TaskManager()
        {
            InitializeComponent();
            //management = new CategoryManagement((this.DataContext as TaskCategoryViewModel).SubCategoryCollection);
            var taskCategory = (TaskListTreeViewModel)DataContext;
            writer.CategoryWriter((this.DataContext as TaskListTreeViewModel).CategoryCollection);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TaskCategory newCategory = new TaskCategory();
            (this.DataContext as TaskListTreeViewModel).CategoryCollection.Add(newCategory);
            var window = new CategoryWindow(newCategory);
            window.ShowDialog();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                var window = new CategoryWindow(treeView.SelectedItem as TaskCategory);
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("A category must be selected");
            }
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TaskCategory categoryForMoving = (TaskCategory)treeView.SelectedItem;
                var index= (this.DataContext as TaskListTreeViewModel).CategoryCollection.IndexOf(categoryForMoving);
                if (index < (this.DataContext as TaskListTreeViewModel).CategoryCollection.Count - 1)
                {
                    (this.DataContext as TaskListTreeViewModel).CategoryCollection.Move(index, index + 1);
                }
            }
            else
            {
                MessageBox.Show("A category must be selected");
            }
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TaskCategory categoryForMoving = (TaskCategory)treeView.SelectedItem;
                var index = (this.DataContext as TaskListTreeViewModel).CategoryCollection.IndexOf(categoryForMoving);
                if (index > 0)
                {
                    (this.DataContext as TaskListTreeViewModel).CategoryCollection.Move(index, index - 1);
                }
            }
            else
            {
                MessageBox.Show("A category must be selected");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (treeView.SelectedItem != null)
            {
                TaskCategory categoryForDeleting = (TaskCategory)treeView.SelectedItem;
                (this.DataContext as TaskListTreeViewModel).CategoryCollection.Remove(categoryForDeleting);
            }
            else
            {
                MessageBox.Show("A category must be selected");
            }
        }

        private void btnSearchTask(object sender, RoutedEventArgs e)
        {
            var taskCategory = (TaskListTreeViewModel)DataContext;
            var window = new FindTaskView(taskCategory);
            window.ShowDialog();
        }

        private void DaGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            writer.CategoryWriter((DataContext as TaskListTreeViewModel).CategoryCollection);
        }
    }
}
