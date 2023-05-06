  using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TaskManager.Model;

namespace TaskManager.Utilities
{
    internal class Writer
    {
        internal void CategoryWriter(ObservableCollection<TaskCategory> CategoryCollection)
        {
            string path = "D:\\An2\\sem2\\MVP\\TaskManagerMVP2\\TaskManager\\TaskManager\\tasks.xml"; 
            File.Delete(path);

            XElement rootElement = new XElement("categories");

            foreach (TaskCategory category in CategoryCollection)
            {
                XElement categoryElement = new XElement("category");
                categoryElement.SetAttributeValue("name", category.CategoryName);

                XElement categoryDescriptionElement = new XElement("description");
                categoryDescriptionElement.SetValue(category.CategoryDescription);
                categoryElement.Add(categoryDescriptionElement);

                XElement tasksElement = new XElement("tasks");

                foreach (TaskObject task in category.TaskCollection)
                {
                    XElement taskElement = new XElement("task");
                    taskElement.SetAttributeValue("name", task.TaskName);
                    taskElement.SetAttributeValue("priority", task.TaskPriority.ToString());

                    XElement taskDescriptionElement = new XElement("description");
                    taskDescriptionElement.SetValue(task.TaskDescription);
                    taskElement.Add(taskDescriptionElement);

                    XElement deadlineElement = new XElement("deadline");
                    deadlineElement.SetValue(task.TaskDeadline.ToString("yyyy-MM-dd"));
                    taskElement.Add(deadlineElement);

                    tasksElement.Add(taskElement);
                }

                categoryElement.Add(tasksElement);

                if (category.subCategoryCollection.Count > 0)
                {
                    XElement subcategoriesElement = new XElement("subcategories");

                    foreach (TaskCategory subcategory in category.subCategoryCollection)
                    {
                        XElement subcategoryElement = new XElement("subcategory");
                        subcategoryElement.SetAttributeValue("name", subcategory.CategoryName);

                        XElement subcategoryDescriptionElement = new XElement("description");
                        subcategoryDescriptionElement.SetValue(subcategory.CategoryDescription);
                        subcategoryElement.Add(subcategoryDescriptionElement);

                        XElement subcategoryTasksElement = new XElement("tasks");

                        foreach (TaskObject task in subcategory.TaskCollection)
                        {
                            XElement taskElement = new XElement("task");
                            taskElement.SetAttributeValue("name", task.TaskName);
                            taskElement.SetAttributeValue("priority", task.TaskPriority.ToString());

                            XElement taskDescriptionElement = new XElement("description");
                            taskDescriptionElement.SetValue(task.TaskDescription);
                            taskElement.Add(taskDescriptionElement);

                            XElement deadlineElement = new XElement("deadline");
                            deadlineElement.SetValue(task.TaskDeadline.ToString("yyyy-MM-dd"));
                            taskElement.Add(deadlineElement);

                            subcategoryTasksElement.Add(taskElement);
                        }

                        subcategoryElement.Add(subcategoryTasksElement);
                        subcategoriesElement.Add(subcategoryElement);
                    }

                    categoryElement.Add(subcategoriesElement);
                }

                rootElement.Add(categoryElement);
            }

            rootElement.Save(path);
        }

    }
}
