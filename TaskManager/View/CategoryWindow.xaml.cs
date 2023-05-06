using System;
using System.Collections.Generic;
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
using TaskManager.Services;
using TaskManager.Utilities;
using TaskManager.ViewModel;

namespace TaskManager.View
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public TaskCategory taskCategory;
        public CategoryManagement management;
        Writer writer = new Writer();
        public TaskCategory TaskCategory { get; set; }

        public CategoryWindow(TaskCategory TransferCategory)
        {
            InitializeComponent();
            DataContext = new TaskCategoryViewModel(TransferCategory);
            management = new CategoryManagement(TransferCategory);
            TaskCategory = TransferCategory;
        }

        public CategoryWindow()
        {
            InitializeComponent();
        }

        private void btn_AddTask_Click(object sender, RoutedEventArgs e)
        {
            management.AddTask();
            
        }

        private void btn_DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            management.RemoveTask(lbTasks.SelectedItem as TaskObject);
        }

        private void btn_AddCategory_Click(object sender, RoutedEventArgs e)
        {
            management.AddSubCategory();
        }

        private void btn_DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            management.RemoveSubCategory(lbSubCategorys.SelectedItem as TaskCategory);
        }

        private void txtNume_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
