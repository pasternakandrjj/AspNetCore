using Levi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Levi
{
    public class TaskComparerImportance : IComparer<MyTask>
    {
        public int Compare(MyTask x, MyTask y)
        {
            if (x.Importance > y.Importance)
                return 1;
            else if (x.Importance < y.Importance)
                return -1;
            else
                return 0;
        }
    }
}