using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Moq;
using toDoListManagement.Controllers;
using toDoListManagement.Models;
using toDoListManagement.Services;
using toDoListManagement.Services.Contracts;

namespace ToDoListManagement.Tests.Controllers
{
    public class ToDoControllerTests
    {
        private readonly Mock<IToDoService> _mockService;

        public ToDoControllerTests() 
        {
            _mockService = new Mock<IToDoService>();
        }
        [Fact]
        public void GetAllToDoItems_shouldReturnIEnumerableToDoItem()
        {
            //arrange
            var stubList = new[]
            {
                new ToDoItem
                {
                    Id = 1,
                    Name = "Foo",
                    Status = new StatusInfo
                    {
                        Id = 2,
                        Name = "Bar"
                    }
                }
            };
            _mockService
                .Setup(service => service.GetAllToDoItems())
                .Returns(stubList.ToList);
            var controller = new ToDoController(_mockService.Object);
            //act
            var result = controller.GetAllToDoItems();
            //assert
            Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(result);
            Assert.NotNull(result);
            Assert.Equal(stubList, result);
        }
        [Fact]
        public void GetCompletedToDoItems_shouldReturnIEnumerableToDoItem()
        {
            //arrange
            var stubList = new[]
            {
                new ToDoItem
                {
                    Id = 1,
                    Name = "Foo",
                    Status = new StatusInfo
                    {
                        Id = 2,
                        Name = "Bar"
                    }
                }
            };
            _mockService
                .Setup(service => service.GetCompletedToDoItems())
                .Returns(stubList.ToList);
            var controller = new ToDoController(_mockService.Object);
            //act
            var result = controller.GetCompletedToDoItems();
            //assert
            Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(result);
            Assert.NotNull(result);
            Assert.Equal(stubList, result);
        }
    }
}