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
            MyTaskController myTaskController = new MyTaskController(new TaskService());

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
            MyTaskController myTaskController = new MyTaskController(new TaskService());

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
            MyTaskController myTaskController = new MyTaskController(new TaskService());

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
            MyTaskController myTaskController = new MyTaskController(new TaskService());

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
            MyTaskController myTaskController = new MyTaskController(new TaskService());

            MyTask expected = new MyTask("title1", "description1", Importance.normal, DateTime.Today, false);

            // Act
            var actual = myTaskController.FindTask(new MyTask()
            { title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false }).Value;

            // Assert   
            //Assert.Equal(expected, actual);
            //Assert.NotStrictEqual(actual, expected);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_CreateList()
        {
            // Arrange  
            MyTaskController myTaskController = new MyTaskController(new TaskService());

            ListOfTasks expected = new ListOfTasks(
                new List<MyTask>(){
                    new MyTask() {
                        title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                    new MyTask() {
                        title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } },
                "List");

            // Act
            var actual = myTaskController.CreateList(
                new List<MyTask>() {
                    new MyTask() {
                        title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                    new MyTask() {
                        title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } },
                "List");

            // Assert   
            //Assert.Equal(expected, actual);
            Assert.NotStrictEqual(expected, actual);
            //actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_GetTaskFromList()
        {
            // Arrange  
            MyTaskController myTaskController = new MyTaskController(new TaskService());
            List<MyTask> expected = new List<MyTask>() {
                new MyTask() {
                    title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                new MyTask() {
                    title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } };

            // Act
            var actual = myTaskController.GetTasksFromList(
                new ListOfTasks(new List<MyTask>() {
                    new MyTask() {
                        title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                    new MyTask() {
                        title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } }, "List")).Value;

            // Assert   
            //Assert.Equal(expected, actual);
            Assert.NotStrictEqual(expected, actual);
            //actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_RenameList()
        {
            // Arrange  
            MyTaskController myTaskController = new MyTaskController(new TaskService());

            ListOfTasks expected = new ListOfTasks(
                new List<MyTask>(){
                    new MyTask() {
                        title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                    new MyTask() {
                        title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } },
                "renamed");

            ListOfTasks list = new ListOfTasks(
                 new List<MyTask>(){
                    new MyTask() {
                        title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                    new MyTask() {
                        title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } },
                 "List");

            // Act
            var actual = myTaskController.RenameList(list, "renamed").Value;
            // Assert   
            Assert.Equal(expected.name, actual.name);
            //Assert.NotStrictEqual(expected, actual);
            //actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_DeleteList()
        {
            // Arrange  
            MyTaskController myTaskController = new MyTaskController(new TaskService());

            ListOfTasks expected = new ListOfTasks(new List<MyTask>() { }, "");

            ListOfTasks list = new ListOfTasks(
                 new List<MyTask>(){
                    new MyTask() {
                        title = "title1", description = "description1", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
                    new MyTask() {
                        title = "title2", description = "description2", Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false } },
                 "List");

            // Act
            var actual = myTaskController.DeleteList(list).Value;

            // Assert   
            Assert.Equal(expected.myTasks, actual.myTasks);
            Assert.Equal(expected.name, actual.name);
            //Assert.NotStrictEqual(expected, actual);
            //actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_ReturnSortedImportance()
        {
            // Arrange  
            MyTaskController myTaskController = new MyTaskController(new TaskService());

            List<MyTask> expected = new List<MyTask>() {
            new MyTask() { title = "title2", description = "description2",  Importance = Importance.low,DateTime = DateTime.Today, IsDone = true },
            new MyTask() { title = "title1", description = "description1",  Importance = Importance.normal,DateTime = DateTime.Today, IsDone = false },
            new MyTask() { title = "title3", description = "description3",  Importance = Importance.high,DateTime = DateTime.Today, IsDone = false }
            };

            // Act
            var actual = myTaskController.GetSortedImportance().Value;

            // Assert   
            //Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_ReturnSortedAlphabetically()
        {
            // Arrange  
            MyTaskController myTaskController = new MyTaskController(new TaskService());

            List<MyTask> expected = new List<MyTask>() {
            new MyTask() { title = "title1", description = "description1",  Importance = Importance.normal, DateTime = DateTime.Today, IsDone = false },
            new MyTask() { title = "title2", description = "description2",  Importance = Importance.low, DateTime = DateTime.Today, IsDone = true },
            new MyTask() { title = "title3", description = "description3",  Importance = Importance.high, DateTime = DateTime.Today, IsDone = false }
            };

            // Act
            var actual = myTaskController.GetSortedAlphabetically().Value;

            // Assert   
            //Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task TaskController_ReturnSortedComplete()
        {
            // Arrange  
            MyTaskController myTaskController = new MyTaskController(new TaskService());

            List<MyTask> expected = new List<MyTask>() {
            new MyTask() { title = "title1", description = "description1",  Importance = Importance.normal, DateTime = DateTime.Today.Date, IsDone = false },
            new MyTask() { title = "title3", description = "description3",  Importance = Importance.high, DateTime = DateTime.Today.Date, IsDone = false },
            new MyTask() { title = "title2", description = "description2",  Importance = Importance.low, DateTime = DateTime.Today.Date, IsDone = true }

            };

            // Act
            var actual = myTaskController.GetSortedComplete().Value;

            // Assert    
            //Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
