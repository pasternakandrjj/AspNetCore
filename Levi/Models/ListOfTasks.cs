using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Models
{
    public class ListOfTasks : IEnumerable
    {
        public List<MyTask> myTasks { get; set; }

        public string name { get; set; }

        public ListOfTasks() { }

        public ListOfTasks(List<MyTask> myTasks, string name)
        {
            this.myTasks = myTasks;
            this.name = name;
        }

        public IEnumerator GetEnumerator()
        {
            return myTasks.GetEnumerator();
        }
    }
}
