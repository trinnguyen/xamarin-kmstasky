using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tasky.Core.BL;
using Tasky.Core.DL;

namespace Tasky.Core.DAL
{
    public class TaskyManager
    {
        DL.TaskyDatabase _db = null;
        protected static string _dbLocation;
        protected static TaskyManager _me;

        static TaskyManager()
        {
            _me = new TaskyManager();
        }

        protected TaskyManager()
        {
            // set the db location
            //_dbLocation = Path.Combine (NSBundle.MainBundle.BundlePath, "Library/TaskDB.db3");
            _dbLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TaskDB.db3");
            // instantiate the database	
            this._db = new TaskyDatabase(_dbLocation);
        }

        public static Task GetTask(int id)
        {
            return _me._db.GetTask(id);
        }

        public static IEnumerable<Task> GetTasks()
        {
            return _me._db.GetTasks();
        }

        public static int SaveTask(Task item)
        {
            return _me._db.SaveTask(item);
        }

        public static int DeleteTask(int id)
        {
            return _me._db.DeleteTask(id);
        }
    }
}
