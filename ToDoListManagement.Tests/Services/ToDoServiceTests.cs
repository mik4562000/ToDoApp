using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoListManagement.Models;
using toDoListManagement.Repositories.Contracts;
using toDoListManagement.Services;

namespace ToDoListManagement.Tests.Services
{
    public class ToDoServiceTests
    {
        private ToDoService _toDoService;
        private Mock<IToDoRepository> _toDoRepositoryMock;

        public ToDoServiceTests()
        {
            _toDoRepositoryMock = new Mock<IToDoRepository>();
            _toDoService = new ToDoService(_toDoRepositoryMock.Object);
        }

        [Fact]
        public void GetAllToDoItems_ShouldCallRepositoryMethodAndReturnExpectedList()
        {
            // Arrange
            var expectedToDoList = new[]
            {
                new ToDoItem
                {
                    Id = 1,
                    Name = "Item 1",
                    Status = new StatusInfo
                    {
                        Id = 2,
                        Name = "Status 1"
                    }
                },
                new ToDoItem
                {
                    Id = 2,
                    Name = "Item 2",
                    Status = new StatusInfo
                    {
                        Id = 2,
                        Name = "Status 2"
                    }
                }
            };

            _toDoRepositoryMock
                .Setup(service => service.GetToDoItems(0))
                .Returns(expectedToDoList.ToList);
            
            // Act
            var result = _toDoService.GetAllToDoItems();

            // Assert
            Assert.Equal(expectedToDoList, result);
            _toDoRepositoryMock.Verify(repository => repository.GetToDoItems(0), Times.Once);
        }

        [Fact]
        public void AddToDoItem_ShouldCallRepositoryMethodAndReturnExpectedToDoItem()
        {
            // Arrange
            string itemName = "New Item";
            var expectedToDoItem = new ToDoItem
            {
                Id = 1,
                Name = "New Item",
                Status = new StatusInfo
                {
                    Id = 2,
                    Name = "Status 1"
                }
            };

            _toDoRepositoryMock
                .Setup(repository => repository.AddToDoItem(itemName))
                .Returns(expectedToDoItem);

            // Act
            var result = _toDoService.AddToDoItem(itemName);

            // Assert
            Assert.Equal(expectedToDoItem, result);
            _toDoRepositoryMock.Verify(repository => repository.AddToDoItem(itemName), Times.Once);
        }

        [Fact]
        public void ChangeToDoItem_ShouldCallRepositoryMethodWithCorrectParameters()
        {
            // Arrange
            int itemId = 1;
            string newName = "Updated Name";

            // Act
            _toDoService.ChangeToDoItem(itemId, newName);

            // Assert
            _toDoRepositoryMock.Verify(repository => repository.ChangeToDoItem(itemId, newName), Times.Once);
        }

        [Fact]
        public void GetCompletedToDoItems_ShouldCallRepositoryMethodAndReturnExpectedList()
        {
            // Arrange
            var expectedToDoList = new[]
            {
                new ToDoItem
                {
                    Id = 1,
                    Name = "Item 1",
                    Status = new StatusInfo
                    {
                        Id = 2,
                        Name = "Status 1"
                    }
                },
                new ToDoItem
                {
                    Id = 2,
                    Name = "Item 2",
                    Status = new StatusInfo
                    {
                        Id = 2,
                        Name = "Status 2"
                    }
                }
            };

            _toDoRepositoryMock
                .Setup(repository => repository.GetToDoItems(2))
                .Returns(expectedToDoList.ToList);

            // Act
            var result = _toDoService.GetCompletedToDoItems();

            // Assert
            Assert.Equal(expectedToDoList, result);
            _toDoRepositoryMock.Verify(repository => repository.GetToDoItems(2), Times.Once);
        }

        [Fact]
        public void GetDeletedToDoItems_ShouldCallRepositoryMethodAndReturnExpectedList()
        {
            // Arrange
            var expectedToDoList = new[]
            {
                new ToDoItem
                {
                    Id = 1,
                    Name = "Item 1",
                    Status = new StatusInfo
                    {
                        Id = 3,
                        Name = "Status 1"
                    }
                },
                new ToDoItem
                {
                    Id = 2,
                    Name = "Item 2",
                    Status = new StatusInfo
                    {
                        Id = 3,
                        Name = "Status 2"
                    }
                }
            };

            _toDoRepositoryMock
                .Setup(repository => repository.GetToDoItems(3))
                .Returns(expectedToDoList.ToList);

            // Act
            var result = _toDoService.GetDeletedToDoItems();

            // Assert
            Assert.Equal(expectedToDoList, result);
            _toDoRepositoryMock.Verify(repository => repository.GetToDoItems(3), Times.Once);
        }

        [Fact]
        public void RemoveToDoItem_ShouldCallRepositoryMethodWithCorrectParameter()
        {
            // Arrange
            int id = 1;

            // Act
            _toDoService.RemoveToDoItemForGood(id);

            // Assert
            _toDoRepositoryMock.Verify(repository => repository.RemoveToDoItemForGood(id), Times.Once);
        }

        [Fact]
        public void CompleteToDoItem_ShouldCallRepositoryMethodAndReturnExpectedStatusInfo()
        {
            // Arrange
            int id = 1;
            var expectedStatusInfo = new StatusInfo
            {
                Id = 1,
                Name = "Status 1"
            };

            _toDoRepositoryMock
                .Setup(repository => repository.CompleteToDoItem(id))
                .Returns(expectedStatusInfo);

            // Act
            var result = _toDoService.CompleteToDoItem(id);

            // Assert
            Assert.Equal(expectedStatusInfo, result);
            _toDoRepositoryMock.Verify(repository => repository.CompleteToDoItem(id), Times.Once);
        }

        [Fact]
        public void DeleteToDoItem_ShouldCallRepositoryMethodAndReturnExpectedStatusInfo()
        {
            // Arrange
            int id = 1;
            var expectedStatusInfo = new StatusInfo
            {
                Id = 1,
                Name = "Status 1",
            };

            _toDoRepositoryMock
                .Setup(repository => repository.DeleteToDoItem(id))
                .Returns(expectedStatusInfo);

            // Act
            var result = _toDoService.DeleteToDoItem(id);

            // Assert
            Assert.Equal(expectedStatusInfo, result);
            _toDoRepositoryMock.Verify(repository => repository.DeleteToDoItem(id), Times.Once);
        }
    }
}
