using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
    class CategoryWindowViewModel
    {
        public TaskCategory Category { get; set; }

        public CategoryWindowViewModel(TaskCategory category)
        {
            Category = category;
        }
    }
}
