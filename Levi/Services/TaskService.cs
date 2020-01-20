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
        private readonly ListOfTasks listOfTasks;

        private readonly List<MyTask> importantTasks = new List<MyTask>();
        private readonly ListOfTasks listOfImportantTasks;

        private readonly List<MyTask> todayTasks = new List<MyTask>();
        private readonly ListOfTasks listOfTodayTasks;

        private readonly ListOfTasks ListOfTasks = new ListOfTasks();

        public TaskService()
        {
            this.myTasks = new List<MyTask>() {
            new MyTask() { title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
            new MyTask() { title = "title2", description = "description2",  Importance = Importance.low, DateTime = DateTime.Today, IsDone = true },
            new MyTask() { title = "title3", description = "description3", Importance = Importance.high, DateTime = DateTime.Today, IsDone = false }
            };

            this.listOfTasks = new ListOfTasks(myTasks, "listofall");

            foreach (var item in myTasks)
            {
                if (item.Importance == Importance.high)
                    importantTasks.Add(item);
                if (item.DateTime == DateTime.Today)
                    todayTasks.Add(item);
            }

            this.listOfImportantTasks = new ListOfTasks(importantTasks, "important");
            this.listOfTodayTasks = new ListOfTasks(todayTasks, "today");
        }

        public List<MyTask> GetTasks()
        {
            List<MyTask> returnNotCompleted = new List<MyTask>();
            foreach (var item in listOfTasks.myTasks)
            {
                if (item.IsDone == false)
                    returnNotCompleted.Add(item);
            }
            return returnNotCompleted;
        }

        public List<MyTask> GetImportantTasks()
        {
            List<MyTask> returnNotCompleted = new List<MyTask>();
            foreach (var item in listOfImportantTasks.myTasks)
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
                listOfImportantTasks.myTasks.Add(mytask);
            listOfTasks.myTasks.Add(mytask);
            return mytask;
        }

        //Change here
        public MyTask UpdateTask(MyTask mytask)
        {
            MyTask taskToUpdate = null;
            foreach (var item in listOfTasks.myTasks)
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
            foreach (var item in listOfTasks.myTasks)
            {
                if (item.title == mytask.title)
                {
                    taskToDelete = item;
                    listOfTasks.myTasks.Remove(item);
                    break;
                }
            }
            return taskToDelete;
        }

        public MyTask[] DeleteTasks(MyTask[] mytasks)
        {
            MyTask[] tasksToDelete = null;

            foreach (var item in listOfTasks.myTasks)
            {
                if (myTasks.Contains(item))
                {
                    tasksToDelete.Append<MyTask>(item);
                    listOfTasks.myTasks.Remove(item);
                }
            }
            return tasksToDelete;
        }

        public MyTask FindTask(MyTask myTask)
        {
            MyTask taskToFind = null;
            foreach (var item in listOfTasks.myTasks)
            {
                if (item.title == myTask.title)
                    taskToFind = item;
            }
            return taskToFind;
        }

        //Change here ,only 1 custom list available
        public ListOfTasks CreateList(List<MyTask> myTasks, string name)
        {
            ListOfTasks.name = name;
            foreach (var item in myTasks)
            {
                if (item.title == "") { }
                else
                {
                    ListOfTasks.myTasks = myTasks;
                }
            }
            return ListOfTasks;
        }

        public List<MyTask> GetTasksFromList()
        {
            List<MyTask> myTasks = new List<MyTask>();
            foreach (var item in ListOfTasks.myTasks)
            {
                myTasks.Add(item);
            }
            return myTasks;
        }

        public ListOfTasks RenameList(string name)
        {
            ListOfTasks.name = name;
            return ListOfTasks;
        }
    }
}
