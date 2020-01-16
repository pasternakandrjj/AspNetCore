using Levi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Services
{
    public interface ITaskServices
    {
        List<MyTask> GetTasks();

        MyTask AddTask(MyTask tasks);

        MyTask UpdateTask(MyTask mytask);

        MyTask DeleteTask(MyTask myTask);

        MyTask[] DeleteTasks(MyTask[] myTasks);
    }
}
