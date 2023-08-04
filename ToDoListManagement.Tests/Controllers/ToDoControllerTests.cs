using Moq;
using toDoListManagement.Controllers;
using toDoListManagement.Models;
using toDoListManagement.Services.Contracts;

namespace ToDoListManagement.Tests.Controllers
{
    public class ToDoControllerTests
    {
        private readonly ToDoController _controller;
        private readonly Mock<IToDoService> _toDoServiceMock;

        public ToDoControllerTests() 
        {
            _toDoServiceMock = new Mock<IToDoService>();
            _controller = new ToDoController(_toDoServiceMock.Object);
        }

        [Fact]
        public void GetAllToDoItems_ShouldCallServiceMethodAndReturnExpectedList()
        {
            //Arrange
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
            _toDoServiceMock
                .Setup(service => service.GetAllToDoItems())
                .Returns(expectedToDoList.ToList);
            //Act
            var result = _controller.GetAllToDoItems();
            //Assert
            Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedToDoList, result);
        }
        [Fact]
        public void GetCompletedToDoItems_ShouldCallServiceMethodAndReturnExpectedList()
        {
            //Arrange
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
            _toDoServiceMock
                .Setup(service => service.GetCompletedToDoItems())
                .Returns(expectedToDoList.ToList);
            //Act
            var result = _controller.GetCompletedToDoItems();
            //Assert
            Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedToDoList, result);
        }
        [Fact]
        public void GetDeletedToDoItems_ShouldCallServiceMethodAndReturnExpectedList()
        {
            //Arrange
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
            _toDoServiceMock
                .Setup(service => service.GetDeletedToDoItems())
                .Returns(expectedToDoList.ToList);
            //Act
            var result = _controller.GetDeletedToDoItems();
            //Assert
            Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedToDoList, result);
        }
        [Fact]
        public void AddToDoItem_ShouldCallServiceMethodAndReturnExpectedToDoItem()
        {
            //Arrange
            var itemName = "New Item";
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
            _toDoServiceMock
                .Setup(service => service.AddToDoItem(itemName))
                .Returns(expectedToDoItem);
            //Act
            var result = _controller.AddToDoItem(itemName);
            //Assert
            Assert.IsAssignableFrom<ToDoItem>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedToDoItem, result);
        }

        [Fact]
        public void ChangeToDoItem_ShouldCallServiceMethodWithCorrectParameters()
        {
            // Arrange
            int id = 1;
            string name = "New Name";

            // Act
            _controller.ChangeToDoItem(id, name);

            // Assert
            _toDoServiceMock.Verify(service => service.ChangeToDoItem(id, name), Times.Once);
        }

        [Fact]
        public void RemoveToDoItem_ShouldCallServiceMethodWithCorrectParameter()
        {
            // Arrange
            int id = 1;

            // Act
            _controller.RemoveToDoItem(id);

            // Assert
            _toDoServiceMock.Verify(service => service.RemoveToDoItemForGood(id), Times.Once);
        }

        [Fact]
        public void CompleteToDoItem_ShouldCallServiceMethodAndReturnExpectedStatusInfo()
        {
            // Arrange
            int id = 1;
            var expectedStatusInfo = new StatusInfo {
                Id = 1,
                Name = "Status 1"
            };

            _toDoServiceMock
                .Setup(service => service.CompleteToDoItem(id))
                .Returns(expectedStatusInfo);

            // Act
            var result = _controller.CompleteToDoItem(id);

            // Assert
            Assert.Equal(expectedStatusInfo, result);
            _toDoServiceMock.Verify(service => service.CompleteToDoItem(id), Times.Once);
        }

        [Fact]
        public void DeleteToDoItem_ShouldCallServiceMethodAndReturnExpectedStatusInfo()
        {
            // Arrange
            int id = 1;
            var expectedStatusInfo = new StatusInfo
            {
                Id = 1,
                Name = "Status 1",
            };

            _toDoServiceMock
                .Setup(service => service.DeleteToDoItem(id))
                .Returns(expectedStatusInfo);

            // Act
            var result = _controller.DeleteToDoItem(id);

            // Assert
            Assert.Equal(expectedStatusInfo, result);
            _toDoServiceMock.Verify(service => service.DeleteToDoItem(id), Times.Once);
        }
    }
}