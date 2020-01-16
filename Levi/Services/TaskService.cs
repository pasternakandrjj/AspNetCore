using Levi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Services
{
    public class TaskService : ITaskServices
    {
        private readonly List<MyTask> myTasks;

        public TaskService()
        {
            this.myTasks = new List<MyTask>() {
            new MyTask() { title = "title1", description = "description1", DateTime = DateTime.Now, Importance = Importance.normal, IsDone = false },
            new MyTask() { title = "title2", description = "description2", DateTime = DateTime.Now, Importance = Importance.low, IsDone = false },
            new MyTask() { title = "title3", description = "description3", DateTime = DateTime.Now, Importance = Importance.high, IsDone = false }
            };
        }

        public List<MyTask> GetTasks()
        {
            return myTasks;
        }

        //Change here
        public MyTask AddTask(MyTask mytask)
        {
            mytask.title = "added";
            mytask.description = "descadd";
            mytask.DateTime = DateTime.Now;
            mytask.Importance = Importance.normal;
            mytask.IsDone = false;

            myTasks.Add(mytask);
            return mytask;
        }

        //Change here
        public MyTask UpdateTask(MyTask mytask)
        {
            MyTask taskToUpdate = null;
            foreach (var item in myTasks)
            {
                if (item.title == mytask.title)
                {
                    item.title = "updated";
                    taskToUpdate = item;

                }
            }
            return taskToUpdate;
        }

        public MyTask DeleteTask(MyTask mytask)
        {
            MyTask taskToDelete = null;

            foreach (var item in myTasks)
            {
                if (item.title == mytask.title)
                {
                    taskToDelete = item;
                    myTasks.Remove(item);
                }
            }
            return taskToDelete;
        }

        public MyTask[] DeleteTasks(MyTask[] mytasks)
        {
            MyTask[] tasksToDelete = null;

            foreach (var item in myTasks)
            {
                if (myTasks.Contains(item))
                {
                    tasksToDelete.Append<MyTask>(item);
                    myTasks.Remove(item);
                }
            }
            return tasksToDelete;
        }
    }
}
