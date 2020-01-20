using Levi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Comparers
{
    public class TaskComparerComplete : IComparer<MyTask>
    {
        public int Compare(MyTask x, MyTask y)
        {
            if (x.IsDone & !y.IsDone)
                return 1;
            else if (!x.IsDone & y.IsDone)
                return -1;
            else
                return 0;
        }
    }
}