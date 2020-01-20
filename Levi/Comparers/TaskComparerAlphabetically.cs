using Levi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Comparers
{
    public class TaskComparerAlphabetically : IComparer<MyTask>
    {
        public int Compare(MyTask x, MyTask y)
        {
            if (x.title.Length > y.title.Length)
                return 1;
            else if (x.title.Length < y.title.Length)
                return -1;
            else
                return 0;
        }
    }
}
