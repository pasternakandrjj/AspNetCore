using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Levi.Models;
using Levi.Services;
using Microsoft.Extensions.Logging;

namespace Levi.Controllers
{
    [Route("task/")]
    [ApiController]
    public class MyTaskController : ControllerBase
    {
        private readonly ITaskServices _services;

        public MyTaskController(ITaskServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("GetTasks")]
        public ActionResult<List<MyTask>> GetTasks()
        {
            var tasks = _services.GetTasks();

            if (tasks.Count == 0)
                return NotFound();
            return tasks;
        }

        [HttpGet]
        [Route("GetImportantTasks")]
        public ActionResult<List<MyTask>> GetImportantTasks()
        {
            var tasks = _services.GetImportantTasks();

            if (tasks.Count == 0)
                return NotFound();
            return tasks;
        }

        [HttpPost]
        [Route("AddTask")]
        public ActionResult<MyTask> AddTask(MyTask myTask)
        {
            var task = _services.AddTask(myTask);

            if (task == null)
                return NotFound();
            return task;
        }

        [HttpPost]
        [Route("UpdateTask")]
        public ActionResult<MyTask> UpdateTask(MyTask mytask)
        {
            var task = _services.UpdateTask(mytask);

            if (task == null)
                return NotFound();
            return task;
        }

        [HttpPost]
        [Route("DeleteTask")]
        public ActionResult<MyTask> DeleteTask(MyTask mytask)
        {
            var task = _services.DeleteTask(mytask);

            if (task == null)
                return NotFound();
            return task;
        }

        [HttpPost]
        [Route("DeleteTasks")]
        public ActionResult<MyTask[]> DeleteTasks(MyTask[] mytasks)
        {
            var task = _services.DeleteTasks(mytasks);

            if (task == null)
                return NotFound();
            return task;
        }

        [HttpGet]
        [Route("FindTask")]
        public ActionResult<MyTask> FindTask(MyTask mytask)
        {
            var task = _services.FindTask(mytask);

            if (task == null)
                return NotFound();
            return task;
        }

        [HttpPost]
        [Route("CreateList")]
        public ActionResult<ListOfTasks> CreateList(List<MyTask> myTasks, string name)
        {
            var listToCreate = _services.CreateList(myTasks, name);

            if (listToCreate == null)
                return NotFound();
            return listToCreate;
        }

        [HttpGet]
        [Route("GetTasksFromList")]
        public ActionResult<List<MyTask>> GetTasksFromList(/*ListOfTasks listOfTasks*/)
        {
            var listToGetTasks = _services.GetTasksFromList(/*listOfTasks*/);

            if (listToGetTasks == null)
                return NotFound();
            return listToGetTasks;
        }

        [HttpPost]
        [Route("RenameList")]
        public ActionResult<ListOfTasks> RenameList(string name)
        {
            var listRenamed = _services.RenameList(name);

            if (listRenamed == null)
                return NotFound();
            return listRenamed;
        }

        [HttpGet]
        [Route("GetSortedImportance")]
        public ActionResult<List<MyTask>> GetSortedImportance()
        {
            var tasks = _services.GetSortedImportance();

            if (tasks.Count == 0)
                return NotFound();
            return tasks;
        }
    }
}