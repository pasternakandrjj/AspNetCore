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
        private readonly ILogger<MyTaskController> _logger;

        public MyTaskController(ITaskServices services, ILogger<MyTaskController> logger)
        {
            _services = services;
            _logger = logger;
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

    }
}