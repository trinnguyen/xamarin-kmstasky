using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasky.Core.BL.Managers
{
    public class TaskManager
    {
        static TaskManager()
        {
        }

        public static Task GetTask(int id)
        {
            return DAL.TaskyManager.GetTask(id);
        }

        public static IList<Task> GetTasks()
        {
            return new List<Task>(DAL.TaskyManager.GetTasks());
        }

        public static int SaveTask(Task item)
        {
            return DAL.TaskyManager.SaveTask(item);
        }

        public static int DeleteTask(int id)
        {
            return DAL.TaskyManager.DeleteTask(id);
        }
    }
}
