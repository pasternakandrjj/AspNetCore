using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Models
{
    public class ListOfTasks
    {
        public List<MyTask> myTasks { get; set; }

        public string name { get; set; }

        public ListOfTasks() { }

        public ListOfTasks(List<MyTask> myTasks, string name)
        {
            this.myTasks = myTasks;
            this.name = name;
        }
    }
}
