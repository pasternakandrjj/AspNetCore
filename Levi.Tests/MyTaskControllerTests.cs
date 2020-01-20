using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using Levi.Controllers;
using Levi.Services;
using Microsoft.Extensions.Logging;
using Levi.Models;
using FluentAssertions;

namespace Levi.Tests
{
    public class MyTaskControllerTests
    {
        [Fact]
        public async Task TaskController_ReturnTasks()
        {
            // Arrange 
            TaskService taskService = new TaskService();
            MyTaskController myTaskController = new MyTaskController(taskService);

            List<MyTask> expected = new List<MyTask>() {
            new MyTask() { title = "title1", description = "description1",  Importance = Importance.normal,DateTime = DateTime.Today, IsDone = false },
            new MyTask() { title = "title3", description = "description3",  Importance = Importance.high,DateTime = DateTime.Today, IsDone = false }
            };

            // Act
            var actual = myTaskController.GetTasks().Value;

            // Assert   
            //Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_ReturnAddedTask()
        {
            // Arrange 
            TaskService taskService = new TaskService();
            MyTaskController myTaskController = new MyTaskController(taskService);

            MyTask expected = new MyTask("title1", "description1", Importance.normal, DateTime.Today, false);
            // Act
            var actual = myTaskController.AddTask(
                new MyTask() { title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false })
                .Value;

            // Assert   
            //Assert.Equal(expected, actual);
            //Assert.NotStrictEqual(actual, expected);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_UpdateTask()
        {
            // Arrange 
            TaskService taskService = new TaskService();
            MyTaskController myTaskController = new MyTaskController(taskService);

            MyTask expected = new MyTask("updated", "description1", Importance.normal, DateTime.Today, false);
            // Act
            var actual = myTaskController.UpdateTask(new MyTask()
            { title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false }).Value;

            // Assert   
            //Assert.Equal(expected, actual);
            //Assert.NotStrictEqual(actual, expected);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_DeleteTask()
        {
            // Arrange 
            TaskService taskService = new TaskService();
            MyTaskController myTaskController = new MyTaskController(taskService);

            MyTask expected = new MyTask("title1", "description1", Importance.normal, DateTime.Today, false);

            // Act
            var actual = myTaskController.DeleteTask(new MyTask()
            { title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false }).Value;

            // Assert   
            //Assert.Equal(expected, actual);
            //Assert.NotStrictEqual(actual, expected);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_FindTask()
        {
            // Arrange 
            TaskService taskService = new TaskService();
            MyTaskController myTaskController = new MyTaskController(taskService);

            MyTask expected = new MyTask("title1", "description1", Importance.normal, DateTime.Today, false);

            // Act
            var actual = myTaskController.FindTask(new MyTask()
            { title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false }).Value;

            // Assert   
            //Assert.Equal(expected, actual);
            //Assert.NotStrictEqual(actual, expected);
            actual.Should().BeEquivalentTo(expected);
        }

        //FIX
        [Fact]
        public async Task TaskController_CreateList()
        {
            // Arrange 
            TaskService taskService = new TaskService();
            MyTaskController myTaskController = new MyTaskController(taskService);

            ListOfTasks expected = new ListOfTasks(
                new List<MyTask>(){
                    new MyTask(){
                        title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                    new MyTask() {
                        title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } },
                "List");

            // Act
            var actual = myTaskController.CreateList(new List<MyTask>() {
                new MyTask()
                {
                    title = "title1",
                    description = "description1",
                    Importance = Importance.normal,
                    DateTime = DateTime.Today,
                    IsDone = false
                },
                new MyTask()
                {
                    title = "title2",
                    description = "description2",
                    Importance = Importance.normal,
                    DateTime = DateTime.Today,
                    IsDone = false
                } }, "null");

            // Assert   
            //Assert.Equal(expected, actual);
            //Assert.NotStrictEqual(actual, expected);
            actual.Should().BeEquivalentTo(expected);
        }

    }
}
