using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasky.DL.SQLite;
using Tasky.Core.BL;
using Tasky.Core.BL;

namespace Tasky.Core.DL
{
    public class TaskyDatabase : SQLiteConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public TaskyDatabase(string path)
            : base(path)
        {
            // create the tables
            CreateTable<Task>();
        }

        //TODO: make these methods generic, Add<T>(item), etc.

        public IEnumerable<Task> GetTasks()
        {
            return (from i in this.Table<Task>() select i);
        }

        public Task GetTask(int id)
        {
            return (from i in Table<Task>()
                    where i.ID == id
                    select i).FirstOrDefault();
        }

        public int SaveTask(Task item)
        {
            if (item.ID != 0)
            {
                base.Update(item);
                return item.ID;
            }
            else
            {
                return base.Insert(item);
            }
        }

        public int DeleteTask(int id)
        {
            return base.Delete<Task>(new Task() { ID = id });
        }
    }
}
