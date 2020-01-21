using Levi.Comparers;
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
         
        public TaskService()
        {
            myTasks = new List<MyTask>() {
            new MyTask() { title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
            new MyTask() { title = "title2", description = "description2",  Importance = Importance.low, DateTime = DateTime.Today, IsDone = true },
            new MyTask() { title = "title3", description = "description3", Importance = Importance.high, DateTime = DateTime.Today, IsDone = false }
            };

            listOfTasks = new ListOfTasks(myTasks, "listofall");

            foreach (var item in myTasks)
            {
                if (item.Importance == Importance.high)
                    importantTasks.Add(item);
                if (item.DateTime == DateTime.Today)
                    todayTasks.Add(item);
            }

            listOfImportantTasks = new ListOfTasks(importantTasks, "important");
            listOfTodayTasks = new ListOfTasks(todayTasks, "today");
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

        public List<MyTask> GetTodayTasks()
        {
            List<MyTask> returnNotCompleted = new List<MyTask>();
            foreach (var item in listOfTodayTasks.myTasks)
            {
                if (item.DateTime.Day == DateTime.Today.Day)
                    returnNotCompleted.Add(item);
            }
            return returnNotCompleted;
        }
         
        public MyTask AddTask(MyTask mytask)
        {
            if (mytask.Importance == Importance.high)
                listOfImportantTasks.myTasks.Add(mytask);
            if (mytask.DateTime.Day == DateTime.Today.Day)
                listOfTodayTasks.myTasks.Add(mytask);
            listOfTasks.myTasks.Add(mytask);
            return mytask;
        }
         
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
                if (item.DateTime.Day == DateTime.Now.Day)
                    listOfTodayTasks.myTasks.Remove(item);
                if (item.Importance == Importance.high)
                    listOfImportantTasks.myTasks.Remove(item);
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

        public ListOfTasks CreateList(List<MyTask> myTasks, string name)
        {
            return new ListOfTasks() { myTasks = myTasks, name = name };
        }

        public List<MyTask> GetTasksFromList(ListOfTasks listOfTasks)
        {
            List<MyTask> myTasks = new List<MyTask>();

            foreach (var item in listOfTasks.myTasks)
                myTasks.Add(item);
            return myTasks;
        }

        public ListOfTasks RenameList(ListOfTasks listOfTasks, string name)
        {
            listOfTasks.name = name;
            return listOfTasks;
        }

        public ListOfTasks DeleteList(ListOfTasks listOfTasks)
        {
            listOfTasks.myTasks.Clear();
            listOfTasks.name = "";
            return listOfTasks;
        }

        public List<MyTask> GetSortedImportance()
        {
            myTasks.Sort(new TaskComparerImportance());
            return myTasks;
        }

        public List<MyTask> GetSortedAplhabetically()
        {
            myTasks.Sort(new TaskComparerAlphabetically());
            return myTasks;
        }

        public List<MyTask> GetSortedDate()
        {
            myTasks.Sort(new TaskComparerDate());
            return myTasks;
        }

        public List<MyTask> GetSortedComplete()
        {
            myTasks.Sort(new TaskComparerComplete());
            return myTasks;
        }
    }
}
