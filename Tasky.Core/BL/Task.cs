using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasky.DL.SQLite;

namespace Tasky.Core.BL
{
    public class Task
    {
        public Task()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
