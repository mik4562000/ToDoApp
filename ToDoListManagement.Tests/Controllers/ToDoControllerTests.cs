using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Moq;
using toDoListManagement.Controllers;
using toDoListManagement.Models;
using toDoListManagement.Services.Contracts;

namespace ToDoListManagement.Tests.Controllers
{
    public class ToDoControllerTests
    {
        private readonly Mock<ILogger<ToDoController>> _mockLogger;

        public ToDoControllerTests() 
        {
            _mockLogger = new Mock<ILogger<ToDoController>>();
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
            var mockService = new Mock<IToDoService>();
            mockService
                .Setup(service => service.GetAllToDoItems())
                .Returns(stubList.ToList);
            var controller = new ToDoController(mockService.Object);
            //act
            var result = controller.GetAllToDoItems();
            //assert
            Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(result);
            Assert.NotNull(result);
            Assert.Equal(stubList, result);
        }
    }
}