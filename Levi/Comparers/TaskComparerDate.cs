using Levi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Comparers
{
    public class TaskComparerDate : IComparer<MyTask>
    {
        public int Compare(MyTask x, MyTask y)
        {
            if (x.DateTime.Day > y.DateTime.Day)
                return 1;
            else if (x.DateTime.Day < y.DateTime.Day)
                return -1;
            else
                return 0;
        }
    }
}
