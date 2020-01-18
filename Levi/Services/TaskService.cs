using Levi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Levi.Services
{
    public class TaskService : ITaskServices
    {
        private readonly List<MyTask> myTasks;

        private List<MyTask> importantTasks = new List<MyTask>();

        private List<MyTask> todayTasks = new List<MyTask>();

        private ListOfTasks ListOfTasks = new ListOfTasks();

        public TaskService()
        {
            this.myTasks = new List<MyTask>() {
            new MyTask() { title = "title1", description = "description1", DateTime = DateTime.Now, Importance = Importance.normal, IsDone = false },
            new MyTask() { title = "title2", description = "description2", DateTime = DateTime.Now, Importance = Importance.low, IsDone = true },
            new MyTask() { title = "title3", description = "description3", DateTime = DateTime.Now, Importance = Importance.high, IsDone = false }
            };

            foreach (var item in myTasks)
            {
                if (item.Importance == Importance.high)
                    importantTasks.Add(item);
                if (item.DateTime == DateTime.Today)
                    todayTasks.Add(item);
            }
        }

        public List<MyTask> GetTasks()
        {
            List<MyTask> returnNotCompleted = new List<MyTask>();
            foreach (var item in myTasks)
            {
                if (item.IsDone == false)
                    returnNotCompleted.Add(item);
            }
            return returnNotCompleted;
        }

        public List<MyTask> GetImportantTasks()
        {
            List<MyTask> returnNotCompleted = new List<MyTask>();
            foreach (var item in importantTasks)
            {
                if (item.IsDone == false)
                    returnNotCompleted.Add(item);
            }
            return returnNotCompleted;
        }

        //Change here
        public MyTask AddTask(MyTask mytask)
        {
            if (mytask.Importance == Importance.high)
                importantTasks.Add(mytask);
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
                    if (mytask.Importance == Importance.high)
                        importantTasks.Remove(mytask);
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

        public MyTask FindTask(MyTask myTask)
        {
            MyTask taskToFind = null;
            foreach (var item in myTasks)
            {
                if (item.title == myTask.title)
                    taskToFind = item;
            }
            return taskToFind;
        }

        //Change here ,only 1 list available
        public ListOfTasks CreateList(List<MyTask> myTasks, string name)
        {
            foreach (var item in myTasks)
            {
                if (item.title == "")
                { }
                else
                {
                    ListOfTasks.myTasks = myTasks;
                    ListOfTasks.name = name;
                }
            }
            return ListOfTasks;
        }

        public List<MyTask> GetTasksFromList(/*ListOfTasks listOfTasks*/)
        {
            List<MyTask> myTasks = new List<MyTask>();
            foreach (var item in ListOfTasks.myTasks)
            {
                myTasks.Add(item);
            }
            return myTasks;
        }

        public ListOfTasks RenameList(ListOfTasks listOfTasks, string name)
        {
            listOfTasks.name = name;
            return listOfTasks;
        }
    }
}
